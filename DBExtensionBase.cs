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

    	// INTERNAL
	    public void Process(ExtensionEvent ev, ElysiumDatabase еlysium = null)
	    {
	    	string extensionName = this.GetType().Name;
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
		public static T GetExtension<T>() where T : class
		        => ElysiumDatabase.Instance.GetExtension<T>();

		public static T[] GetExtensions<T>() where T : class
		        => ElysiumDatabase.Instance.GetExtensions<T>();

	    public static bool TryGetExtensions<T>(out T[] extensions) where T : class
	    {
	        extensions = ElysiumDatabase.Instance.GetExtensions<T>();
	        return extensions.Length > 0;
	    }

		public static bool HasExtension<T>() where T : class
		        => ElysiumDatabase.Instance.HasExtension<T>();

		public static T AddExtension<T>() where T : DBExtensionBase, new()
		        => ElysiumDatabase.Instance.AddExtension<T>();

        protected virtual void OnInitialize(ElysiumDatabase elysium) {}
        protected virtual void OnDispose() {}
    }
}