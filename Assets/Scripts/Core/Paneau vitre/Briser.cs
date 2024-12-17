using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Briser : MonoBehaviour
    {
        public GameObject intIcon, vitreOn, vitreOff, boutonOn, boutonOff;
        public bool toggle;
        public AudioSource switchSound;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                intIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (toggle == true)
                    {
                        Debug.Log("On");
                        vitreOn.SetActive(true);
                        vitreOff.SetActive(false);
                        boutonOn.SetActive(true);
                        boutonOff.SetActive(false);
                        //switchSound.Play();
                    }
                    if (toggle == false)
                    {
                        Debug.Log("Off");
                        vitreOn.SetActive(false);
                        vitreOff.SetActive(true);
                        boutonOn.SetActive(false);
                        boutonOff.SetActive(true);
                        //switchSound.Play();
                    }
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