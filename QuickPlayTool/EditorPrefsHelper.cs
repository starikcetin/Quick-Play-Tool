/*
Copyright (c) 2018 S. Tarık Çetin

This project is licensed under the terms of the MIT license.
Refer to the LICENCE file in the root folder of the project.
*/

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

        public static string QuickPlaySceneRelativePath
        {
            get { return EditorPrefs.GetString("QuickPlayTool.QuickPlayScene"); }
            set { EditorPrefs.SetString("QuickPlayTool.QuickPlayScene", value); }
        }

        public static bool AutoCompact
        {
            get { return EditorPrefs.GetBool("QuickPlayTool.AutoCompact"); }
            set { EditorPrefs.SetBool("QuickPlayTool.AutoCompact", value); }
        }
    }
}
