using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Afficher : MonoBehaviour
    {
        public GameObject interfaceUI;

        public MonoBehaviour cameraController;

        [SerializeField] private bool isVisible = false;

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                isVisible = !isVisible;


                interfaceUI.SetActive(isVisible);
                if (isVisible)
                {
                    Time.timeScale = 0f;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;


                    if (cameraController != null)
                    {
                        cameraController.enabled = false;
                    }
                }
                else
                {
                    Time.timeScale = 1f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;


                    if (cameraController != null)
                    {
                        cameraController.enabled = true;
                    }
                }
            }
        }

    }
}
