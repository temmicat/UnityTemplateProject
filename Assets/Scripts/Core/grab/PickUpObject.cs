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
        private bool hasObject;
        public bool OnCadre { get; private set; }
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
                
                //Debug.Log("grab");
                GrabObject();
            }

            if (Input.GetKeyDown(KeyCode.Q) && hasObject)
            {
                //Debug.Log("drop");
                DropObject();
            }

            if (Input.GetKeyDown(KeyCode.F) && hasObject && isPolaroid)
            {
                SetPicture();
            }
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
