#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

// Refresh asset database on entering play mode. Make sure to disable asset auto-refresh in Preferences.
 
public static class EnterPlayMode
{
    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        EditorApplication.playModeStateChanged += OnEnterPlayMode;
    }
 
    private static void OnEnterPlayMode(PlayModeStateChange obj)
    {
        if (obj == PlayModeStateChange.ExitingEditMode) AssetDatabase.Refresh(ImportAssetOptions.Default);
    }
}

#endif
 