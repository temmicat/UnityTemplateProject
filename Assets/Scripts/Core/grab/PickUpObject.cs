using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LastTrain.Core
{
    public class PickUpObject : MonoBehaviour
    {
        [SerializeField] private GameObject objectOnPlayer;
        [SerializeField] private GameObject objectWorld;
        [SerializeField] private Transform tpObject;
        public bool hasObject { get; private set; }
        private PickUpObject[] scripts;

        // Start is called before the first frame update
        void Start()
        {
            objectOnPlayer.SetActive(false);
        }
        
        private void Update()
        {
            if (objectOnPlayer == null || objectWorld == null)
            {
                Destroy(this);
                return;
            }

            if (Input.GetKeyDown(KeyCode.E) && CursorTrigger.Instance.LookAt && CursorTrigger.Instance.ObjectName == objectWorld.name && !hasObject)
            {
                scripts = GetComponents<PickUpObject>();
                
                for (var index = 0; index < scripts.Length; index++)
                {
                    var t = scripts[index];
                    if (t.hasObject)
                    {
                        return;
                    }
                }
                
                Debug.Log("grab");
                GrabObject();
            }

            if (Input.GetKeyDown(KeyCode.T) && hasObject)
            {
                Debug.Log("drop");
                DropObject();
            }
        }

        private void GrabObject()
        {
            hasObject = true;
            
            objectWorld.SetActive(false);
            objectOnPlayer.SetActive(true);

            objectWorld.GetComponent<Rigidbody>().useGravity = false;
            
            objectWorld.transform.position = tpObject.position;
            objectWorld.transform.parent = tpObject;
        }

        private void DropObject()
        {
           hasObject = false;
            
           objectOnPlayer.SetActive(false);
           objectWorld.SetActive(true);

           objectWorld.GetComponent<Rigidbody>().useGravity = true;
           objectWorld.transform.parent = null;
        }
    }
}
