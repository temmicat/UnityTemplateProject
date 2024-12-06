using UnityEngine;

namespace LastTrain.Core
{
    public class PickUpPDB : MonoBehaviour
    {
        [SerializeField] private GameObject pdbOnPlayer;
        
        // Start is called before the first frame update
        void Start()
        {
            pdbOnPlayer.SetActive(false);
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.E) && CursorTrigger.Instance.LookAt)
            {
                gameObject.SetActive(false);
                
                pdbOnPlayer.SetActive(true);
            }
        }
    }
}