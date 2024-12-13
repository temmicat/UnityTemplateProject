using JetBrains.Annotations;
using UnityEngine;

namespace LastTrain.Core
{
    public class DollGrab : MonoBehaviour
    {
        [SerializeField] [NotNull] private GameObject dollWorld, dollPlayer, numWorld, numPlayer;
        [SerializeField] private PickUpObject bam;
        
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
                    
                    Destroy(gameObject);
                    Destroy(this);
                }
            }
        }
    }
}