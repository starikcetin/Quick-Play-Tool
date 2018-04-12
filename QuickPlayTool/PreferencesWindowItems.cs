using UnityEditor;
using UnityEngine;

namespace QuickPlayTool
{
    public static class PreferencesWindowItems
    {
        [PreferenceItem("Quick Play Tool")]
        public static void DrawPreferences()
        {
            EditorGUILayout.BeginVertical();

            EditorGUILayout.PrefixLabel("Project Preferences Save Path");

            EditorGUILayout.BeginHorizontal();
            GUILayout.TextField("");
            GUILayout.Button("...", EditorStyles.miniButton, GUILayout.Width(30));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }
    }
}
