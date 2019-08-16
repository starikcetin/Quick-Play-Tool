using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace QuickPlayTool
{
    /// <summary>
    /// Project based settings for Quick Play Tool.
    /// </summary>
    public class ProjectwiseSettings
    {
        #region Save/Load and Access Infrastructure

        private static string SaveFullPath
        {
            get
            {
                return Path.Combine(
                    EditorPrefsHelper.ProjectwiseSettingsSaveFolderPath,
                    EditorPrefsHelper.ProjectwiseSettingsSaveFileName);
            }
        }

        [NonSerialized] private static ProjectwiseSettings _instance;

        public static ProjectwiseSettings Instance
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
                        _instance = new ProjectwiseSettings();
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
            var path = Path.Combine(Application.dataPath, SaveFullPath);
            return File.Exists(path);
        }

        private static ProjectwiseSettings _LoadFromSettingsFile()
        {
            var path = Path.Combine(Application.dataPath, SaveFullPath);
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<ProjectwiseSettings>(json);
        }

        private static void _SaveToSettingsFile(ProjectwiseSettings instance)
        {
            var path = Path.Combine(Application.dataPath, SaveFullPath);
            var json = JsonUtility.ToJson(instance);

            // create missing directories if any
            new FileInfo(path).Directory.Create();

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
