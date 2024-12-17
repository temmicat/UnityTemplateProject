using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Lampe : MonoBehaviour
    {
        public GameObject intIcon, lightOn, lightOff, switchOn, switchOff;
        private bool toggle;

        public GameObject PDBH;
        public AudioSource switchSound;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                intIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    toggle = !toggle;

                    //Debug.Log("Off");
                    lightOn.SetActive(!toggle);
                    lightOff.SetActive(toggle);
                    switchOn.SetActive(!toggle);
                    switchOff.SetActive(toggle);
                    //switchSound.Play();

                }
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                intIcon.SetActive(false);
            }
        }
    }

}
