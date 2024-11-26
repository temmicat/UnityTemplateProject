using System.Collections;
using System.Collections.Generic;
using LTX.Singletons;
using PuzzleSystem.Core;
using UnityEngine;

namespace LastTrain.Core
{
    public class BoiteMusiqueSetup : MonoSingleton<BoiteMusiqueSetup>
    {
        [HideInInspector]
        
        public bool HasPuzzleStarted;
        public BoiteMusique boiteMusique;
        public Puzzle puzzle;
        public Photo photo;


    }
}
