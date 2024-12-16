using System;
using LTX.Singletons;
using UnityEngine;

namespace LastTrain.Core
{
    public class CursorTrigger : MonoSingleton<CursorTrigger>
    {
        
        [SerializeField] private float pickUpRange = 5f;
        [SerializeField] private GameObject cursor;
        [field : SerializeField] public bool LookAt { get; private set; }
        [field : SerializeField] public string ObjectName { get; private set; }
            
        private void Update()
        {
            RaycastHit hit;
            bool isPickUpObjectInFront = Physics.Raycast(transform.position, transform.forward,
                out hit, pickUpRange) && (hit.collider.CompareTag("canPickUp")
                                        || hit.collider.CompareTag("Tableau"));

            if (isPickUpObjectInFront)
            {
                ObjectName = hit.collider.name;
            }
            else
            {
                ObjectName = default;
            }
            
            if (ObjectName == "Tableau")
            {
                return;
            }
            
            LookAt = isPickUpObjectInFront;
            
            cursor.SetActive(LookAt);
        }
    }
}