using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuzzleSysteme.core
{
    public abstract class ConditionData : ScriptableObject
    {
        public int Length { get; internal set; }

        public abstract bool IsComplete();
       
    }
}
