#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode] // Works outside Play Mode
public class PlayerPrefsCleaner : MonoBehaviour
{
    // Adds a menu item: Tools > Clear PlayerPrefs
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void DeleteAllPlayerPrefs()
    {
        if (EditorUtility.DisplayDialog("Delete ALL PlayerPrefs?", 
                "This cannot be undone!", "Delete", "Cancel"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("<color=red>PlayerPrefs cleared!</color>");
        }
    }
}

[CustomEditor(typeof(PlayerPrefsCleaner))]
public class PlayerPrefsCleanerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Big red button for visual emphasis
        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("DELETE ALL PLAYERPREFS", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Nuclear Option", 
                    "Wipe ALL saved PlayerPrefs?", "YES, DELETE", "NO"))
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
                Debug.Log("<color=red>PlayerPrefs nuked from Inspector!</color>");
            }
        }
        GUI.backgroundColor = Color.white; // Reset
    }
}
#endif