using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class RadioTrigger : MonoBehaviour
    {

        public GameObject Batterie;
        private bool hasBattery;
        public GameObject PopUp;
        private bool PlayerInRange;
        public AudioClip radioSound;
        public Material red;
        public MeshRenderer afficheRadio;
        private bool isDone;
        [SerializeField] private SubScript subs;
        [SerializeField] private AudioSource source;

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "RADIO_PILE HOLD")
            {
                hasBattery = true;
            }

            if (other.CompareTag("Player"))
            {
                PlayerInRange = true;
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.name == "RADIO_PILE HOLD")
            {
                hasBattery = false;
            }
            if (other.CompareTag("Player"))
            {
                PlayerInRange = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && !isDone)
            {
                if (hasBattery)
                {
                    isDone = true;
                    
                    Destroy(Batterie);
                    
                    //play sound
                    source.clip = radioSound;
                    source.Play();
                    StartCoroutine(subs.PlaySub());
                    
                    //L'affiche change
                    afficheRadio.sharedMaterial = red;
                }
                else if(PlayerInRange)
                {
                    StartCoroutine(DisplayText());
                }
            }
        }

        private IEnumerator DisplayText()
        {
            PopUp.SetActive(true);

            yield return new WaitForSeconds(3f);
            
            PopUp.SetActive(false);
        }
            
    }
}
