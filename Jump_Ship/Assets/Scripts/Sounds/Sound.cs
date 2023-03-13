using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class Sound
    {
        public enum SoundType { Default = -1, Interesting, Danger }
        public Sound(Vector3 _pos, float _range)
        {
            pos = _pos;
            range = _range;
        }

        public SoundType sound_type;

        public readonly Vector3 pos;
        // This is the intensity of the sound
        public readonly float range;
    }
}

