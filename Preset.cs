using System.Collections.Generic;
using UnityEngine;

namespace QuickPlayTool
{
    [System.Serializable]
    public class Preset
    {
        [SerializeField] public string Name = "New Preset";
        [SerializeField] public List<string> Scenes = new List<string>();
    }
}
