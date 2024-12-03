using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class RadioTrigger : MonoBehaviour
    {

        public GameObject Batterie;
        private bool hasBattery;
        public GameObject PopUp;
        private bool PlayerInRange;
        


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("canPickUp"))
            {
                hasBattery = true;
            }

            if (other.CompareTag("Player"))
            {
                PlayerInRange = true;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("canPickUp"))
            {
                hasBattery = false;
            }
            if (other.CompareTag("Player"))
            {
                PlayerInRange = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hasBattery)
                    Destroy(Batterie);
                else if(PlayerInRange)
                {
                    StartCoroutine(DisplayText());
                }
            }
        }

        private IEnumerator DisplayText()
        {
            PopUp.SetActive(true);

            yield return new WaitForSeconds(3f);
            
            PopUp.SetActive(false);
        }
            
    }
}
