using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuickPlayTool
{
    [System.Serializable]
    public class PresetsContainer
    {
        [SerializeField] public List<Preset> Presets = new List<Preset>();
    }
}
