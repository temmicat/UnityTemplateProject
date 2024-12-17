using System;
using UnityEngine;

namespace LastTrain.Core
{
    public class LampInstruction : MonoBehaviour
    {
        public GameObject instructions;
        public Lampe lamp;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !lamp.toggle)
            {
                instructions.SetActive(true);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                instructions.SetActive(false);
            }
        }
    }
}