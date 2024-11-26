using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PuzzleSystem.Core.Data;

namespace LastTrain.Core
{
    [CreateAssetMenu(menuName = "LastTrain/Puzzles/Radio")]
    public class RadioPuzzleData : PuzzleData
    {
        [SerializeField]
        private AudioClip audioClip;

        public override void Begin()
        {
            Debug.Log("Debut puzzle radio");
            RadioPuzzleSetup.Instance.HasPuzzleStarted = true;
        }

        public override void End(bool isSuccess)
        {
            
            RadioPuzzleSetup.Instance.HasPuzzleStarted = false;
            if(isSuccess)
            {
                Debug.Log("Puzzle radio reussi");
                RadioPuzzleSetup.Instance.radio.PlayClip(audioClip);
            }    
            else
            {
                Debug.Log("Puzzle radio raté");
                //Faire des trucs
            }


        }

        public override bool Refresh()
        {
            bool result = RadioPuzzleSetup.Instance.radio.HasPile();

            return result;
        }
    }
}
