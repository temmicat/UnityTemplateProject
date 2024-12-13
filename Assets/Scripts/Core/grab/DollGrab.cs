using UnityEngine;

namespace LastTrain.Core
{
    public class DollGrab : MonoBehaviour
    {
        [SerializeField] private GameObject dollWorld, dollPlayer;
        [SerializeField] private PickUpObject bam;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && CursorTrigger.Instance.LookAt && CursorTrigger.Instance.ObjectName == name)
            {
                if (bam.hasObject)
                {
                    dollPlayer.SetActive(true);
                    dollWorld.SetActive(true);
                    
                    Destroy(gameObject);
                    Destroy(this);
                }
            }
        }
    }
}