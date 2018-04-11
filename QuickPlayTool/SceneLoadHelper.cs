using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace QuickPlayTool
{
    public static class SceneLoadHelper
    {
        public static void LoadPreset(Preset preset, bool closeCurrentScenes)
        {
            // Display a dialog and shortcut if the preset is empty.
            if (preset.Scenes.Count == 0)
            {
                EditorUtility.DisplayDialog(
                    "Preset is empty",
                    "Loading an empty preset is not supported. Try adding some scenes to your preset."
                    + "\n\nSelected preset: " + preset.Name,
                    "Alright");

                return;
            }

            // Prompt to save changes.
            if (closeCurrentScenes)
            {
                // That long method returns false when user presses "Cancel"
                var cancelled = ! EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

                // If user pressed cancel, we return without touching anything.
                if (cancelled) return;
            }

            // Open all scenes in preset as additive.
            foreach (var scene in preset.Scenes)
            {
                EditorSceneManager.OpenScene(scene, OpenSceneMode.Additive);
            }

            // Close scenes that were previously open.
            if (closeCurrentScenes)
            {
                for (var i = EditorSceneManager.sceneCount - 1; i >= 0; i--)
                {
                    var scene = EditorSceneManager.GetSceneAt(i);

                    if (preset.Scenes.Contains(scene.path))
                    {
                        Debug.Log("Skipping close for: " + scene.path);
                    }
                    else
                    {
                        EditorSceneManager.CloseScene(scene, true);
                    }
                }
            }
        }
    }
}
