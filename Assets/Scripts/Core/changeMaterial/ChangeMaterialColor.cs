using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class ChangeMaterialColor : MonoBehaviour
    {
        [SerializeField] private Material myMaterial;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("canPickUp"))
            {
                myMaterial.color = Color.green;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("canPickUp"))
            {
                myMaterial.color = Color.red;
            }
        }



    }
}
