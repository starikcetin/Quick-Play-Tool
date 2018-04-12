using UnityEditor;

namespace QuickPlayTool
{
    public static class EditorPrefsHelper
    {
        public static bool ShowPaths
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.ShowPaths"); }
            set { EditorPrefs.SetBool("QuickPlayTool.ShowPaths", value); }
        }

        public static bool ShowAsUtility
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.ShowAsUtility"); }
            set { EditorPrefs.SetBool("QuickPlayTool.ShowAsUtility", value); }
        }

        public static bool AllScenesFoldout
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.AllScenesFoldout"); }
            set { EditorPrefs.SetBool("QuickPlayTool.AllScenesFoldout", value); }
        }

        public static bool AutoCompact
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.AutoCompact"); }
            set { EditorPrefs.SetBool("QuickPlayTool.AutoCompact", value); }
        }

        public static bool PresetsFoldout
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.PresetsFoldout"); }
            set { EditorPrefs.SetBool("QuickPlayTool.PresetsFoldout", value); }
        }

        public static bool CloseCurrentScenesOnPresetLoad
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.CloseCurrentScenesOnPresetLoad"); }
            set { EditorPrefs.SetBool("QuickPlayTool.CloseCurrentScenesOnPresetLoad", value); }
        }

        
    }
}
