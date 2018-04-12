using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace QuickPlayTool
{
    /// <summary>
    /// Project based settings for Quick Play Tool.
    /// </summary>
    public class QuickPlayToolProjectSettings
    {
        #region Save/Load and Access Infrastructure

        [NonSerialized]
        private static readonly string ProjectSettingsPathRelativeToAssets = "QuickPlayTool_ProjectSettings.json";

        [NonSerialized] private static QuickPlayToolProjectSettings _instance;

        public static QuickPlayToolProjectSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_SettingsFileExist())
                    {
                        _instance = _LoadFromSettingsFile();
                    }
                    else
                    {
                        _instance = new QuickPlayToolProjectSettings();
                        _SaveToSettingsFile(_instance);
                    }
                }

                return _instance;
            }
        }

        public static void Save()
        {
            _SaveToSettingsFile(Instance);
        }

        private static bool _SettingsFileExist()
        {
            var path = Path.Combine(Application.dataPath, ProjectSettingsPathRelativeToAssets);
            return File.Exists(path);
        }

        private static QuickPlayToolProjectSettings _LoadFromSettingsFile()
        {
            var path = Path.Combine(Application.dataPath, ProjectSettingsPathRelativeToAssets);
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<QuickPlayToolProjectSettings>(json);
        }

        private static void _SaveToSettingsFile(QuickPlayToolProjectSettings instance)
        {
            var path = Path.Combine(Application.dataPath, ProjectSettingsPathRelativeToAssets);
            var json = JsonUtility.ToJson(instance);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
        }

        #endregion Save/Load and Access Infrastructure

        [SerializeField] private string _quickPlaySceneRelativePath;
        public string QuickPlaySceneRelativePath
        {
            get
            {
                return _quickPlaySceneRelativePath;
            }
            set
            {
                _quickPlaySceneRelativePath = value;
                Save();
            }
        }

        [SerializeField] private string _presetsJson;
        public PresetsContainer Presets
        {
            get
            {
                if (string.IsNullOrEmpty(_presetsJson))
                {
                    return new PresetsContainer();
                }

                return JsonUtility.FromJson<PresetsContainer>(_presetsJson);
            }
            set
            {
                _presetsJson = JsonUtility.ToJson(value);
                Save();
            }
        }
    }
}
