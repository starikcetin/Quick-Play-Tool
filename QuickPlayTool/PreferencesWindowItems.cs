using UnityEditor;
using UnityEngine;

namespace QuickPlayTool
{
    public static class PreferencesWindowItems
    {
        [PreferenceItem("Quick Play Tool")]
        public static void DrawPreferences()
        {
            var saveFolderPath = EditorPrefsHelper.ProjectSettingsSaveFolderPath;
            var saveFileName = EditorPrefsHelper.ProjectSettingsSaveFileName;

            EditorGUILayout.BeginVertical();

            GUILayout.Label("Project Preferences Save File");

            // folder
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Folder", GUILayout.Width(50));
            saveFolderPath = GUILayout.TextField(saveFolderPath, GUILayout.Width(300));
            EditorGUILayout.EndHorizontal();

            // file
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("File", GUILayout.Width(50));
            saveFileName = GUILayout.TextField(saveFileName, GUILayout.Width(300));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();

            EditorPrefsHelper.ProjectSettingsSaveFolderPath = saveFolderPath;
            EditorPrefsHelper.ProjectSettingsSaveFileName = saveFileName;
        }
    }
}
