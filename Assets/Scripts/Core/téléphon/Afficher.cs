using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Afficher : MonoBehaviour
    {
        public GameObject intIcon, lightOn, lightOff, switchOn, switchOff;

        public MonoBehaviour playerActionOff;
        public bool toggle;
        public AudioSource switchSound;


        public void DisableScript()
        {
            if (playerActionOff != null)
            {
                playerActionOff.enabled = false;
                Debug.Log(playerActionOff.name + " désactivé !");
            }
            else
            {
                Debug.LogWarning("Aucun script assigné !");
            }
        }

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


                    }
                    if (toggle == false)
                    {
                        Debug.Log("Off");
                        lightOn.SetActive(false);
                        lightOff.SetActive(true);
                        switchOn.SetActive(false);
                        switchOff.SetActive(true);

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
