using System;
using System.Data;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace ModuDevCore.ElysiumDB 
{
    public class DBMeta : IDisposable
    {
        public IDbConnection connection;

        private bool ShouldIgnoreLog(string log)
        {
            var ignores = ElysiumDatabase.Settings?.logIgnorePatterns;
            var showLogs = ElysiumDatabase.Settings?.showLogs??true;
            if (ignores == null || ignores.Count == 0 || !showLogs)
                return false;

            for (int i = 0; i < ignores.Count; i++)
            {
                var pattern = ignores[i];

                if (!string.IsNullOrEmpty(pattern) &&
                    (
                        log.Contains(pattern, StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    return true;
                }
            }

            return false;
        }
        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }

        public IDataReader RunCmd(
            string cmd,
            int linesToRead = 0,
            [CallerMemberName] string callerMethod = "",
            [CallerFilePath] string callerFile = "",
            [CallerLineNumber] int callerLine = 0
        )
        {
            string file = System.IO.Path.GetFileName(callerFile);

            if (!ShouldIgnoreLog(
                    $"LiteSQL request\n" +
                    $"QUERY: {cmd}\n" +
                    $"DB: {connection.ConnectionString}\n" +
                    $"CALLED FROM: {file}:{callerLine} ({callerMethod})"
                )
            )
            {
                Debug.Log(
                    $"LiteSQL request\n" +
                    $"QUERY: {cmd}\n" +
                    $"DB: {connection.ConnectionString}\n" +
                    $"CALLED FROM: {file}:{callerLine} ({callerMethod})"
                );
            }

            IDbCommand dbcmd = connection.CreateCommand();
            dbcmd.CommandText = cmd;
            IDataReader reader = dbcmd.ExecuteReader();

            for (int i = 0; i < linesToRead; i++)
                reader.Read();

            return reader;
        }
    }
}