using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    public class Pile : MonoBehaviour
    {
        [SerializeField]
        private KeyCode keyCode;


        // Update is called once per frame
        private void Update()
        {
            if(RadioPuzzleSetup.Instance.HasPuzzleStarted)
            {
                if(Input.GetKey(keyCode))
                {
                    RadioPuzzleSetup.Instance.puzzle.SetDirty();
                    
                    RadioPuzzleSetup.Instance.radio.SetPile(this);
                }
            }
        }
    }
}
