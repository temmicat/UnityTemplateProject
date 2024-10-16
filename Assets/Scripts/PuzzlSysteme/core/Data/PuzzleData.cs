using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuzzleSysteme.core
{
    public abstract class PuzzleData : ScriptableObject  
    {
        [field: SerializeField]
        public string PuzzleName { get; private set; }

        [field: SerializeField]
        public ConditionData[] Conditions { get; private set; }


        public abstract void Begin();
        public abstract void End(bool isSuccess);

        public bool AreAllConditionCompleted() 
        {
            for (int i = 0; i < Conditions.Length; i++)
            {
                if (!Conditions[i].IsComplete())
                    return false; 

            }        
          return true;  
        }
    }
}
