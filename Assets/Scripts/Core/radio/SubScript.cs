using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace LastTrain.Core
{
    public class SubScript : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private TMP_Text display;
        [SerializeField] private string[] subsText;
        [SerializeField] private float[] timeOut;
        [SerializeField] private AudioClip audio;

        private void Start()
        {
            panel.gameObject.SetActive(false);
        }

        public IEnumerator PlaySub()
        {
            panel.gameObject.SetActive(true);
            
            for (int i = 0; i < subsText.Length; i++)
            {
                display.text = subsText[i];
                yield return new WaitForSeconds(timeOut[i]);
            }
            
            panel.gameObject.SetActive(false);
        }
    }
}
