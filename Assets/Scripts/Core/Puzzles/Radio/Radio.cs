using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Radio : MonoBehaviour
    {
        [SerializeField]
        private Pile pile;

        [SerializeField]
        private AudioSource audioSource;

        public bool HasPile()
        {
            return pile != null;
        }

        public void SetPile(Pile pileToGive)
        {
            pile = pileToGive;
        }

        public void PlayClip(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
