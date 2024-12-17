using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Lampe : MonoBehaviour
    {
        public GameObject intIcon, lightOn, lightOff, switchOn, switchOff;
        public bool toggle { get; private set; }
        public PickUpObject headTorch;

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

                    headTorch.enabled = toggle;
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
