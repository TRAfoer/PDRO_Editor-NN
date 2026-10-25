using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PDRO.Data
{
    [Serializable]
    public class MusicData
    {
        public float BPM;
        public string MusicName;
        public string ComposerName;

        public MusicData(float bpm, string musicName, string composerName)
        {
            BPM = bpm;
            MusicName = musicName;
            ComposerName = composerName;
        }
    }
}