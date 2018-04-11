using System;
using UnityEditor;
using UnityEngine;

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

            GUILayout.Label(this.position.width.ToString());

            //
            // Preferences Section
            //
            var prevUtilState = EditorPrefsHelper.ShowAsUtility;

            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            EditorPrefsHelper.ShowPaths = GUILayout.Toggle(EditorPrefsHelper.ShowPaths,
                Compact(145) ? "P" : "Show Paths",
                EditorStyles.toolbarButton);

            EditorPrefsHelper.ShowAsUtility = GUILayout.Toggle(EditorPrefsHelper.ShowAsUtility,
                Compact(215) ? "U" : "Show as Utility",
                EditorStyles.toolbarButton);

            EditorPrefsHelper.CloseCurrentScenesOnPresetLoad = GUILayout.Toggle(
                EditorPrefsHelper.CloseCurrentScenesOnPresetLoad,
                Compact(340) ? "CoP" : "Close Scenes on Preset Load",
                EditorStyles.toolbarButton);

            GUILayout.FlexibleSpace();

            EditorPrefsHelper.AutoCompact = GUILayout.Toggle(EditorPrefsHelper.AutoCompact,
                Compact(400) ? "AC" : "Auto Compact",
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
            if (Compact(400))
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
                    GUILayout.Width(position.width - 250));
            }

            if (Compact(400)) EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(Compact(200) ? "Play" : "Quick Play"))
            {
                ScenePlayHelper.PlayScene(EditorPrefsHelper.QuickPlaySceneRelativePath, additive: false);
            }
            if (GUILayout.Button(Compact(200) ? "Pl Add" : "Quick Play Additive"))
            {
                ScenePlayHelper.PlayScene(EditorPrefsHelper.QuickPlaySceneRelativePath, additive: true);
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
                    if (Compact(400))
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
                            GUILayout.Width(position.width - 250));
                    }

                    if (GUILayout.Button("Play", EditorStyles.miniButtonLeft))
                    {
                        ScenePlayHelper.PlayScene(relativeScenePath, additive: false);
                    }

                    if (GUILayout.Button(Compact(200) ? "PAd" : "Play Additive", EditorStyles.miniButtonMid))
                    {
                        ScenePlayHelper.PlayScene(relativeScenePath, additive: true);
                    }

                    if (GUILayout.Button(Compact(200) ? "Set" : "Set As Quick", EditorStyles.miniButtonRight))
                    {
                        EditorPrefsHelper.QuickPlaySceneRelativePath = relativeScenePath;
                    }

                    if (Compact(400))
                    {
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.EndVertical();
                    }
                    else
                        EditorGUILayout.EndHorizontal();
                }
            }

            //
            // Presets Section
            //
            EditorGUILayout.Space();

            // begin presets foldout line
            EditorGUILayout.BeginHorizontal();

            EditorPrefsHelper.PresetsFoldout = EditorGUILayout.Foldout(EditorPrefsHelper.PresetsFoldout, "Presets", true);

            if (EditorPrefsHelper.PresetsFoldout)
            {
                var presetsContainer = EditorPrefsHelper.GetScenePresets();

                // new preset button
                if (GUILayout.Button(
                    Compact(160) ? "+" : "Add Preset",
                    EditorStyles.miniButtonRight,
                    GUILayout.Width(Compact(160) ? 30 : 92)))
                {
                    presetsContainer.Presets.Add(new Preset());
                    EditorPrefsHelper.SetScenePresets(presetsContainer);
                }

                // end presets foldout line (if foldout is open)
                EditorGUILayout.EndHorizontal();

                for (var iPreset = presetsContainer.Presets.Count - 1; iPreset >= 0; iPreset--)
                {
                    var preset = presetsContainer.Presets[iPreset];

                    // begin a preset
                    GUILayout.BeginVertical(EditorStyles.helpBox);

                    if (Compact(300))
                    {
                        // preset name
                        var name = GUILayout.TextField(preset.Name);
                        if (name != preset.Name)
                        {
                            preset.Name = name;
                            EditorPrefsHelper.SetScenePresets(presetsContainer);
                        }
                    }

                    // begin the preset's header
                    GUILayout.BeginHorizontal();

                    // add a scene to preset button
                    if (GUILayout.Button("+", EditorStyles.miniButtonLeft))
                    {
                        var selectedScene = SceneLocateHelper.OpenSceneDialog();

                        if (!string.IsNullOrEmpty(selectedScene))
                        {
                            var relativePath = SceneLocateHelper.MakeRelativePath(selectedScene);
                            preset.Scenes.Add(relativePath);
                            EditorPrefsHelper.SetScenePresets(presetsContainer);
                        }
                    }

                    if (!Compact(300))
                    {
                        // preset name
                        var name = GUILayout.TextField(preset.Name, GUILayout.Width(position.width - 130));
                        if (name != preset.Name)
                        {
                            preset.Name = name;
                            EditorPrefsHelper.SetScenePresets(presetsContainer);
                        }
                    }

                    // remove this preset button
                    if (GUILayout.Button(Compact(160) ? "R" : "Remove", EditorStyles.miniButtonMid))
                    {
                        presetsContainer.Presets.Remove(preset);
                        EditorPrefsHelper.SetScenePresets(presetsContainer);
                    }

                    // load this preset button
                    if (GUILayout.Button(Compact(160) ? "L" : "Load", EditorStyles.miniButtonRight))
                    {
                        SceneLoadHelper.LoadPreset(preset, EditorPrefsHelper.CloseCurrentScenesOnPresetLoad);
                    }

                    // end the preset's header
                    GUILayout.EndHorizontal();

                    for (var iScene = preset.Scenes.Count - 1; iScene >= 0; iScene--)
                    {
                        var scene = preset.Scenes[iScene];

                        // begin a scene
                        GUILayout.BeginHorizontal();

                        // remove this scene button
                        if (GUILayout.Button("-", EditorStyles.miniButton, GUILayout.Width(20)))
                        {
                            preset.Scenes.Remove(scene);
                            EditorPrefsHelper.SetScenePresets(presetsContainer);
                        }

                        // scene name or path
                        GUILayout.Label(SceneLocateHelper.GetNameOrPath(scene, EditorPrefsHelper.ShowPaths), EditorStyles.wordWrappedMiniLabel);

                        // end a scene
                        GUILayout.EndHorizontal();
                    }

                    GUILayout.BeginHorizontal();

                    GUILayout.EndHorizontal();

                    // end a preset
                    GUILayout.EndVertical();
                    EditorGUILayout.Space();
                }
            }
            else
            {
                // end presets foldout line (if foldout is closed)
                EditorGUILayout.EndHorizontal();
            }


            EditorGUILayout.EndVertical();
        }

        private bool Compact(int switchWidth)
        {
            return EditorPrefsHelper.AutoCompact && position.width < switchWidth;
        }
    }
}
