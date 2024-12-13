using UnityEngine;

namespace LastTrain.Core
{
    public class ColorLerp : MonoBehaviour
    {
        
        [SerializeField] private float speed = 0.01f;
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;
        [SerializeField] private AudioSource BAM;
        [SerializeField] private PickUpObject pickUp;

        private float t;
        private float startTime;
        private MeshRenderer rend;
        private void Awake()
        {
            rend = GetComponent<MeshRenderer>();
        }
        
        // Start is called before the first frame update
        void Start()
        {
            startTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if (BAM.isPlaying && !pickUp.OnCadre)
            {
                t = (Time.time - startTime) * speed;
                rend.material.color = Color.Lerp(startColor, endColor, t);
            }
            else
            {
                t = 0;
                startTime = Time.time;
                rend.material.color = startColor;
            }

            if (pickUp.OnCadre)
            {
                rend.material.color = endColor;
            }
        }
    }
}
