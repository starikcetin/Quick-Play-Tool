/*
Copyright (c) 2018 S. Tarık Çetin

This project is licensed under the terms of the MIT license.
Refer to the LICENCE file in the root folder of the project.
*/

using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QuickPlayTool
{
    public class QuickPlayToolWindow : EditorWindow
    {
        private static bool _windowNeedsReset;

        [MenuItem("Window/Quick Play Tool")]
        private static void Init()
        {
            var instance = GetWindow<QuickPlayToolWindow>(utility: EditorPrefsHelper.ShowAsUtility);

            instance.titleContent = new GUIContent("Quick Play");
            instance.minSize = new Vector2(100, 50);
            instance.Show();
        }

        private void Update()
        {
            if (_windowNeedsReset)
            {
                Close();
                Init();
                _windowNeedsReset = false;
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            //
            // Preferences Section
            //
            var prevUtilState = EditorPrefsHelper.ShowAsUtility;

            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            EditorPrefsHelper.ShowPaths = GUILayout.Toggle(EditorPrefsHelper.ShowPaths,
                Compact(200) ? "Path" : "Show Paths",
                EditorStyles.toolbarButton);

            EditorPrefsHelper.ShowAsUtility = GUILayout.Toggle(EditorPrefsHelper.ShowAsUtility,
                Compact(200) ? "Util" : "Show as Utility",
                EditorStyles.toolbarButton);

            GUILayout.FlexibleSpace();

            EditorPrefsHelper.AutoCompact = GUILayout.Toggle(EditorPrefsHelper.AutoCompact,
                Compact(200) ? "Cmp" : "Auto Compact",
                EditorStyles.toolbarButton);

            //GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            if (prevUtilState != EditorPrefsHelper.ShowAsUtility)
            {
                _windowNeedsReset = true;
            }

            //
            // Quick Play Section
            //
            if (Compact(300))
            {
                GUILayout.Label(
                    SceneLocateHelper.GetNameOrPath(EditorPrefsHelper.QuickPlaySceneRelativePath, EditorPrefsHelper.ShowPaths),
                    EditorStyles.helpBox);
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(
                    SceneLocateHelper.GetNameOrPath(EditorPrefsHelper.QuickPlaySceneRelativePath, EditorPrefsHelper.ShowPaths),
                    EditorStyles.helpBox,
                    GUILayout.Width(position.width - 150));
            }

            if (Compact(300)) EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Quick Play"))
            {
                ScenePlayHelper.PlayScene(EditorPrefsHelper.QuickPlaySceneRelativePath);
            }
            EditorGUILayout.EndHorizontal();

            //
            // All Scenes Section
            //
            EditorGUILayout.Space();
            EditorPrefsHelper.AllScenesFoldout = EditorGUILayout.Foldout(EditorPrefsHelper.AllScenesFoldout, "All Scenes", true);
            if (EditorPrefsHelper.AllScenesFoldout)
            {
                foreach (var relativeScenePath in SceneLocateHelper.GetAllScenePaths(true))
                {
                    if (Compact(300))
                    {
                        EditorGUILayout.BeginVertical();
                        GUILayout.Label(
                            SceneLocateHelper.GetNameOrPath(relativeScenePath, EditorPrefsHelper.ShowPaths),
                            EditorStyles.helpBox);
                        EditorGUILayout.BeginHorizontal();
                    }
                    else
                    {
                        EditorGUILayout.BeginHorizontal();
                        GUILayout.Label(
                            SceneLocateHelper.GetNameOrPath(relativeScenePath, EditorPrefsHelper.ShowPaths),
                            EditorStyles.helpBox,
                            GUILayout.Width(position.width - 150));
                    }

                    if (GUILayout.Button("Play", EditorStyles.miniButton))
                    {
                        ScenePlayHelper.PlayScene(relativeScenePath);
                    }

                    if (GUILayout.Button(Compact(160) ? "Set" : "Set As Quick Play", EditorStyles.miniButton))
                    {
                        EditorPrefsHelper.QuickPlaySceneRelativePath = relativeScenePath;
                    }

                    if (Compact(300))
                    {
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.EndVertical();
                    }
                    else
                        EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndVertical();
        }

        private bool Compact(int switchWidth)
        {
            return EditorPrefsHelper.AutoCompact && position.width < switchWidth;
        }
    }
}
