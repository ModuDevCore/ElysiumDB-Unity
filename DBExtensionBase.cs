using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

namespace ModuDevCore.ElysiumDB.Extension
{
	using Core;	
	using Internal.Data;	
	[Serializable]
    public abstract class DBExtensionBase
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
	            	Debug.Log($"[DBExtension] Initialize → {extensionName}");
	                OnInitialize(еlysium);
	                break;

	            case ExtensionEvent.Dispose:
	            	Debug.Log($"[DBExtension] Dispose → {extensionName}");
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
	        Debug.Log($"[{extensionName}] " + message);
	    }
    }
}