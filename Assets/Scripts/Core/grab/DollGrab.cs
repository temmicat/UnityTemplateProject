using UnityEngine;

namespace LastTrain.Core
{
    public class DollGrab : MonoBehaviour
    {
        [SerializeField] private GameObject dollWorld, dollPlayer, numWorld, numPlayer;
        [SerializeField] private PickUpObject bam;
        [SerializeField] private AudioClip finished;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && CursorTrigger.Instance.LookAt && CursorTrigger.Instance.ObjectName == name)
            {
                if (bam.hasObject)
                {
                    dollPlayer.SetActive(true);
                    dollWorld.SetActive(true);
                    numPlayer.SetActive(true);
                    numWorld.SetActive(true);
                    
                    AudioSource.PlayClipAtPoint(finished, transform.position);
                    
                    Destroy(gameObject);
                    Destroy(this);
                }
            }
        }
    }
}