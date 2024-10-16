using PuzzleSysteme.core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PuzzleSystem.sample
{
    [CreateAssetMenu(menuName = "PuzzleSystem/Sample/ConditionData")]
    public class SampleConditionData : ConditionData
    {
        public override bool IsComplete()
        {
            return true;
        }
    }
}
