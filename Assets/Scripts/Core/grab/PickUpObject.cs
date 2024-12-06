using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LastTrain.Core
{
    public class PickUpObject : MonoBehaviour
    {
        
        [SerializeField] private GameObject bamOnPlayer;
        
        // Start is called before the first frame update
        void Start()
        {
            bamOnPlayer.SetActive(false);
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.E) && CursorTrigger.Instance.LookAt)
            {
                gameObject.SetActive(false);
                
                bamOnPlayer.SetActive(true);
            }
        }
    }
}
