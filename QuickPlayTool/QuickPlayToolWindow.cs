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

            //
            // Presets Section
            //
            EditorGUILayout.Space();
            EditorPrefsHelper.PresetsFoldout = EditorGUILayout.Foldout(EditorPrefsHelper.PresetsFoldout, "Presets", true);
            if (EditorPrefsHelper.PresetsFoldout)
            {
                GUILayout.Label("-- Presets area begin --");

                var presetsContainer = EditorPrefsHelper.GetScenePresets();

                for (var iPreset = presetsContainer.Presets.Count - 1; iPreset >= 0; iPreset--)
                {
                    var preset = presetsContainer.Presets[iPreset];

                    // begin a preset
                    GUILayout.BeginVertical(EditorStyles.helpBox);

                    // preset name
                    var name = GUILayout.TextField(preset.Name);
                    if (name != preset.Name)
                    {
                        preset.Name = name;
                        EditorPrefsHelper.SetScenePresets(presetsContainer);
                    }

                    for (var iScene = preset.Scenes.Count - 1; iScene >= 0; iScene--)
                    {
                        var scene = preset.Scenes[iScene];

                        // begin a scene
                        GUILayout.BeginHorizontal();

                        // scene name or path
                        GUILayout.Label(scene);

                        // remove this scene button
                        EditorGUILayout.Space();
                        if (GUILayout.Button("Remove Scene", EditorStyles.miniButton))
                        {
                            preset.Scenes.Remove(scene);
                            EditorPrefsHelper.SetScenePresets(presetsContainer);
                        }

                        // end a scene
                        GUILayout.EndHorizontal();
                    }

                    EditorGUILayout.Space();
                    GUILayout.BeginHorizontal();

                    // add a scene to preset button
                    if (GUILayout.Button("Add Scene", EditorStyles.miniButton))
                    {
                        var selectedScene = SceneLocateHelper.OpenSceneDialog();

                        if (!string.IsNullOrEmpty(selectedScene))
                        {
                            var relativePath = SceneLocateHelper.MakeRelativePath(selectedScene);
                            preset.Scenes.Add(relativePath);
                            EditorPrefsHelper.SetScenePresets(presetsContainer);
                        }
                    }

                    // remove this preset button
                    if (GUILayout.Button("Remove Preset", EditorStyles.miniButton))
                    {
                        presetsContainer.Presets.Remove(preset);
                        EditorPrefsHelper.SetScenePresets(presetsContainer);
                    }

                    // load this preset button
                    if (GUILayout.Button("Load Preset", EditorStyles.miniButton))
                    {
                        SceneLoadHelper.LoadPreset(preset, true);
                    }

                    GUILayout.EndHorizontal();

                    // end a preset
                    GUILayout.EndVertical();
                    EditorGUILayout.Space();
                }

                if (GUILayout.Button("Add Preset", EditorStyles.miniButton))
                {
                    presetsContainer.Presets.Add(new Preset());
                    EditorPrefsHelper.SetScenePresets(presetsContainer);
                }

                GUILayout.Label("-- Presets area end --");

                var json = EditorPrefsHelper.GetRawPresetJson();

                GUILayout.Label(json);
            }


            EditorGUILayout.EndVertical();
        }

        private bool Compact(int switchWidth)
        {
            return EditorPrefsHelper.AutoCompact && position.width < switchWidth;
        }
    }
}
