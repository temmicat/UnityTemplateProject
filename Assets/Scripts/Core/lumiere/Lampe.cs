using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Lampe : MonoBehaviour
    {
        public GameObject intIcon, lightOn, lightOff, switchOn, switchOff;
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
                        lightOn.SetActive(true);
                        lightOff.SetActive(false);
                        switchOn.SetActive(true);
                        switchOff.SetActive(false);
                        //switchSound.Play();
                    }
                    if (toggle == false)
                    {
                        Debug.Log("Off");
                        lightOn.SetActive(false);
                        lightOff.SetActive(true);
                        switchOn.SetActive(false);
                        switchOff.SetActive(true);
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
