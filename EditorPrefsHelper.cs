using UnityEditor;

namespace QuickPlayTool
{
    public static class EditorPrefsHelper
    {

        private static readonly string ProjectSettingsSaveFolderPath_Default = "Quick-Play-Tool Settings";
        private static readonly string ProjectSettingsSaveFileName_Default = "Quick-Play-Tool Projectwise Settings.json";

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

        public static string ProjectwiseSettingsSaveFolderPath
        {
            get
            {
                if (EditorPrefs.HasKey("QuickPlayTool.ProjectwiseSettingsSaveFolderPath"))
                {
                    var val = EditorPrefs.GetString("QuickPlayTool.ProjectwiseSettingsSaveFolderPath");
                    return val;
                }

                ProjectwiseSettingsSaveFolderPath = ProjectSettingsSaveFolderPath_Default;
                return ProjectSettingsSaveFolderPath_Default;
            }
            set
            {
                EditorPrefs.SetString("QuickPlayTool.ProjectwiseSettingsSaveFolderPath", value);
            }
        }

        public static string ProjectwiseSettingsSaveFileName
        {
            get
            {
                if (EditorPrefs.HasKey("QuickPlayTool.ProjectwiseSettingsSaveFileName"))
                {
                    var val = EditorPrefs.GetString("QuickPlayTool.ProjectwiseSettingsSaveFileName");
                    return val;
                }

                ProjectwiseSettingsSaveFileName = ProjectSettingsSaveFileName_Default;
                return ProjectSettingsSaveFileName_Default;
            }
            set
            {
                EditorPrefs.SetString("QuickPlayTool.ProjectwiseSettingsSaveFileName", value);
            }
        }
        
    }
}
