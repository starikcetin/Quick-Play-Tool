using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QuickPlayTool
{
    public static class EditorPrefsHelper
    {



        
        // editor pref
        public static bool ShowPaths
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.ShowPaths"); }
            set { EditorPrefs.SetBool("QuickPlayTool.ShowPaths", value); }
        }

        // editor pref
        public static bool ShowAsUtility
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.ShowAsUtility"); }
            set { EditorPrefs.SetBool("QuickPlayTool.ShowAsUtility", value); }
        }

        // editor pref
        public static bool AllScenesFoldout
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.AllScenesFoldout"); }
            set { EditorPrefs.SetBool("QuickPlayTool.AllScenesFoldout", value); }
        }

        // editor pref
        public static bool AutoCompact
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.AutoCompact"); }
            set { EditorPrefs.SetBool("QuickPlayTool.AutoCompact", value); }
        }

        // editor pref
        public static bool PresetsFoldout
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.PresetsFoldout"); }
            set { EditorPrefs.SetBool("QuickPlayTool.PresetsFoldout", value); }
        }

        // editor pref
        public static bool CloseCurrentScenesOnPresetLoad
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.CloseCurrentScenesOnPresetLoad"); }
            set { EditorPrefs.SetBool("QuickPlayTool.CloseCurrentScenesOnPresetLoad", value); }
        }





        // PROJECT pref
        public static string QuickPlaySceneRelativePath
        {
            get { return EditorPrefs.GetString("QuickPlayTool.QuickPlaySceneRelativePath"); }
            set { EditorPrefs.SetString("QuickPlayTool.QuickPlaySceneRelativePath", value); }
        }

        // PROJECT pref
        public static PresetsContainer GetScenePresets()
        {
            if (!EditorPrefs.HasKey("QuickPlayTool.Presets"))
            {
                return new PresetsContainer();
            }
            else
            {
                var json = EditorPrefs.GetString("QuickPlayTool.Presets");
                var presets = JsonUtility.FromJson<PresetsContainer>(json);
                return presets;
            }
        }

        // PROJECT pref
        public static void SetScenePresets(PresetsContainer presetContainer)
        {
            var json = JsonUtility.ToJson(presetContainer);
            EditorPrefs.SetString("QuickPlayTool.Presets", json);
        }





        public static string GetRawPresetJson()
        {
            return JsonHelper.FormatJson(EditorPrefs.GetString("QuickPlayTool.Presets"));
        }




    }
}
