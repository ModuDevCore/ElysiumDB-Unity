namespace ModuDevCore.ElysiumDB.Core.Data{
    public enum ElysiumStage
    {
        None,

        Initializing,
        DatabasesConnecting,
        DatabasesConnected,

        ExtensionsInitializing,
        ExtensionInitialized,

        Ready,

        Disposing,
        Disposed
    }
}