using System;
using UnityEngine;

namespace GamePlay
{
    public static class Sounds
    {
        /// <summary>
        /// 
        /// </summary>
        

        public static void MakeSound(Sound sound)
        {
            // Check for colliders around the sound's position and range
            Collider[] col = Physics.OverlapSphere(sound.pos, sound.range);

            for (int i = 0; i < col.Length; i++)
                // If that collider has the IHear interfact
                if (col[i].TryGetComponent(out IHear hearer))
                    // Call the method RespondToSound
                    hearer.RespondToSound(sound);
        }
    }
}