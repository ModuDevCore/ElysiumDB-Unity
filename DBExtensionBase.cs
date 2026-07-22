using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using ModuDevCore.ElysiumDB.Internal;

namespace ModuDevCore.ElysiumDB.Extension
{
	using Core;		
	using Core.Data;	
	[Serializable]
    public class DBExtensionBase
    {
    	[HideInInspector]
    	public bool enabled = true;
    	[HideInInspector]
    	public string extensionGroup = "";
    	[HideInInspector]
    	public int extensionId = -1;
    	public string extensionName => this.GetType().Name;

    	// INTERNAL
	    public void Process(ExtensionEvent ev, ElysiumDatabase еlysium = null)
	    {
	        switch (ev)
	        {
	            case ExtensionEvent.Initialize:
	            	if(!enabled)
	            		break;

	            	DBLogger.LogContext(extensionName+"Proccesing", $"<color=#81C784>Initialize</color> → <b>{extensionName}</b>", DBLogger.ContextLevel.ExtensionProccesing);
	                OnInitialize(еlysium);
	                break;

	            case ExtensionEvent.Dispose:
	            	DBLogger.LogContext(extensionName+"Proccesing", $"Dispose → {extensionName}", DBLogger.ContextLevel.ExtensionProccesing);
	                OnDispose();
	                break;
	        }
	    }
		public T GetExtension<T>() where T : class
		        => ElysiumDatabase.GetExtension<T>();
		public T[] GetExtensions<T>() where T : class
		        => ElysiumDatabase.GetExtensions<T>();
	    public bool TryGetExtensions<T>(out T[] extensions) where T : class
	    {
	        extensions = ElysiumDatabase.GetExtensions<T>();
	        return extensions.Length > 0;
	    }
		public bool HasExtension<T>() where T : class
		        => ElysiumDatabase.HasExtension<T>();

		public T AddExtension<T>() where T : DBExtensionBase, new()
		        => ElysiumDatabase.AddExtension<T>();
		public bool RemoveExtension<T>() where T : DBExtensionBase, new()
		    => ElysiumDatabase.RemoveExtension<T>();

        protected virtual void OnInitialize(ElysiumDatabase elysium) {}
        protected virtual void OnDispose() {}
		public void Log(object message)
	    {
	    	DBLogger.LogContext(extensionName, message);
	    }
    }
}