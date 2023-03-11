using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class Sound
    {
        public Sound(Vector3 _pos, float _range)
        {
            pos = _pos;
            range = _range;
        }

        public readonly Vector3 pos;
        // This is the intensity of the sound
        public readonly float range;
    }
}

