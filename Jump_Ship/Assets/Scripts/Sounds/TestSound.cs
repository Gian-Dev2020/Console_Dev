using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class TestSound : MonoBehaviour
    {
        [SerializeField] AudioSource source = null;
        [SerializeField] float sound_range = 25f;

        private void OnMouseDown()
        {
            if (source.isPlaying) // If there is already a sound playing, just quit, avoids overlapping sounds
            {
                return;
            }

            source.Play();

            var sound = new Sound(transform.position, sound_range);

            Sounds.MakeSound(sound);

            Debug.Log("Sound created");
        }
    }
}

