using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Zoom : MonoBehaviour
    {
        public Camera ZoomCamera;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                ZoomIn();
            }

            if (Input.GetMouseButtonUp(1))
            {
                ZoomOut();
            }
        }

        void ZoomOut()
        {
            ZoomCamera.fieldOfView = 60;
        }

        void ZoomIn()
        {
            ZoomCamera.fieldOfView = 35;        
        }
    }
}
