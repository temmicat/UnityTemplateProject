using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace LastTrain.Core
{
    public class BAM : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip clip;
        
        // Start is called before the first frame update
        void OnEnable()
        {
            //StartCoroutine(DoRotation(150, 1.5f));
            //StartCoroutine(DoRotation(150, 1.5f));
            //StartCoroutine(DoRotation(150, 1.5f));
            /*
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DORotate(new Vector3(150, 0, 0),1.5f))
                .Append(DOVirtual.DelayedCall(1f, () => {}))
                .Append(transform.DORotate(new Vector3(150, 0, 0),1.5f))
                .Append(DOVirtual.DelayedCall(1f, () => {}))
                .Append(transform.DORotate(new Vector3(-300, 0, 0),3f));*/
        }

        //IEnumerator DoRotation(float value, float time)
        //{
            //yield return new WaitForSeconds(time);
            //transform.DORotate(new Vector3(value, 0, 0), 1.5f);
        //}

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (source.isPlaying) return;
                source.clip = clip;
                source.Play();
            }
        }
    }
}
