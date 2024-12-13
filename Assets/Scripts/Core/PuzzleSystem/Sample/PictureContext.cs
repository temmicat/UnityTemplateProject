using PuzzleSystem.Core;
using UnityEngine;

namespace LastTrain.Core.Core.PuzzleSystem.Sample
{
    public struct PictureContext : IPuzzleContext
    {
        public PickUpObject[] pickUps;
        public GameObject doll;
    }
}