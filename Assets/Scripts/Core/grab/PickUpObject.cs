using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace LastTrain.Core
{
    public class PickUpObject : MonoBehaviour
    {
        [SerializeField] private GameObject objectOnPlayer;
        [SerializeField] private GameObject objectWorld;
        [SerializeField] private Transform tpObject, cadre;
        [SerializeField] private AudioSource BAM;
        [SerializeField] private bool isPolaroid;
        [SerializeField] private PickUpObject bam;
        [SerializeField] private GameObject tableauInstruction;
        public bool hasObject { get; private set; }
        public bool OnCadre { get; private set; }
        private PickUpObject[] scripts;

        private Coroutine displayTableau;

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
                
                //Debug.Log("grab");
                GrabObject();
            }

            if (Input.GetKeyDown(KeyCode.Q) && hasObject)
            {
                //Debug.Log("drop");
                DropObject();
            }

            if (CursorTrigger.Instance.ObjectName == "Tableau" && isPolaroid && hasObject)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SetPicture();
                }

                if (displayTableau == null)
                    displayTableau = StartCoroutine(DisplayText());
            }
        }
        
        private IEnumerator DisplayText()
        {
            tableauInstruction.SetActive(true);

            yield return new WaitForSeconds(1f);
            
            tableauInstruction.SetActive(false);
            displayTableau = null;
        }

        private void GrabObject()
        {

            if (isPolaroid && !BAM.isPlaying) return;
                
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

           var rb = objectWorld.GetComponent<Rigidbody>();
           rb.useGravity = true;
           rb.isKinematic = false;
           
           objectWorld.transform.position = tpObject.position;
           objectWorld.transform.parent = null;
        }

        private void SetPicture()
        {
            if (!bam.hasObject) return;
            
            hasObject = false;
            OnCadre = true;
            
            objectOnPlayer.SetActive(false);
            objectWorld.SetActive(true);

            var rb = objectWorld.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;

            objectWorld.transform.position = cadre.position;
            objectWorld.transform.parent = cadre;
            objectWorld.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
        }
    }
}
