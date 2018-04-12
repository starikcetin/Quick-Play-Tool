using UnityEditor;

namespace QuickPlayTool
{
    public static class EditorPrefsHelper
    {

        private static readonly string ProjectSettingsSaveFolderPath_Default = "Assets";
        private static readonly string ProjectSettingsSaveFileName_Default = "Quick-Play-Tool_ProjectSettings.json";

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

        public static string ProjectSettingsSaveFolderPath
        {
            get
            {
                var val = EditorPrefs.GetString("QuickPlayTool.ProjectSettingsSaveFolderPath");

                if (string.IsNullOrEmpty(val))
                {
                    ProjectSettingsSaveFolderPath = ProjectSettingsSaveFolderPath_Default;
                    return ProjectSettingsSaveFolderPath_Default;
                }

                return val;
            }
            set
            {
                EditorPrefs.SetString("QuickPlayTool.ProjectSettingsSaveFolderPath", value);
            }
        }

        public static string ProjectSettingsSaveFileName
        {
            get
            {
                var val = EditorPrefs.GetString("QuickPlayTool.ProjectSettingsSaveFileName");

                if (string.IsNullOrEmpty(val))
                {
                    ProjectSettingsSaveFileName = ProjectSettingsSaveFileName_Default;
                    return ProjectSettingsSaveFileName_Default;
                }

                return val;
            }
            set
            {
                EditorPrefs.SetString("QuickPlayTool.ProjectSettingsSaveFileName", value);
            }
        }
        
    }
}
