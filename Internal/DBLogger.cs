using System;
using UnityEngine;

namespace ModuDevCore.ElysiumDB.Internal {
    public static class DBLogger
    {
        public enum ContextLevel {
            Default,
            Core,
            Hidden,
            SQLQuery,
            DBLoader,
            ExtensionProccesing,
        }

        private static bool ShouldIgnoreLog(string log, ContextLevel contextLevel = ContextLevel.Default)
        {
            var settings = ElysiumDatabase.Settings;

            if (!(settings?.showLogs ?? true))
                return true;

            switch (contextLevel)
            {
                case ContextLevel.Hidden:
                    return true;
                    break;

                case ContextLevel.SQLQuery:
                    if (!(settings?.showSqlLogs ?? true))
                        return true;
                    break;
                case ContextLevel.ExtensionProccesing:
                    if (!(settings?.showExtensionProccesingLogs ?? true))
                        return true;
                    break;

                case ContextLevel.DBLoader:
                case ContextLevel.Core:
                    if (!(settings?.showCoreLogs ?? true))
                        return true;
                    break;

                case ContextLevel.Default:
                    if (!(settings?.showDefaultLogs ?? true))
                        return true;
                    break;
                default:
                    break;
            }

            var ignores = settings?.logIgnorePatterns;

            if (ignores == null || ignores.Count == 0)
                return false;

            foreach (var pattern in ignores)
            {
                if (string.IsNullOrWhiteSpace(pattern))
                    continue;

                if (log.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static string DefaultExtensionNamePrefixColor(string prefix) => $"<color=#9575CD>[{prefix}]</color>";

        public static void Log(object message, ContextLevel contextLevel = ContextLevel.Default) {
            if(!ShouldIgnoreLog($"{message}", contextLevel))
                Debug.Log($"{message}");
        }

        public static void LogContext(string contextName, object message, ContextLevel contextLevel = ContextLevel.Default)
        {
            if(!ShouldIgnoreLog($"{DefaultExtensionNamePrefixColor(contextName)} {message}", contextLevel))
                Debug.Log($"{DefaultExtensionNamePrefixColor(contextName)} {message}");
        }
    }
}