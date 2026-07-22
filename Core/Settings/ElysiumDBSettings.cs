#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using ModuDevCore.ElysiumDB.Extension;

namespace ModuDevCore.ElysiumDB.Core.Settings
{
    public class ElysiumDBSettings : ScriptableObject
    {
        public List<string> logIgnorePatterns = new List<string>();
        public List<string> dbPaths = new List<string>();
        [SerializeReference]
        public List<DBExtensionBase> extensions = new();
        public bool showLogs = true;
        public bool showSqlLogs = true;
        public bool showCoreLogs = true;
        public bool showDefaultLogs = true;
        public bool showExtensionProccesingLogs = true;
    } 
}