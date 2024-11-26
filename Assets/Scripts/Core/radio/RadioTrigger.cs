using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class RadioTrigger : MonoBehaviour
    {

        public GameObject Batterie;
        private bool hasBattery;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("canPickUp"))
            {
                hasBattery = true;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("canPickUp"))
            {
                hasBattery = false;
            }
        }

        // Update is called once per frame
        void Update()
        {


            if (hasBattery && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(Batterie);
            }
        }
    }
}
