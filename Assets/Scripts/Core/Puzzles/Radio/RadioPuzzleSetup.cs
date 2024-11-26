using System.Collections;
using System.Collections.Generic;
using LTX.Singletons;
using PuzzleSystem.Core;
using UnityEngine;

namespace LastTrain.Core
{
    public class RadioPuzzleSetup : MonoSingleton<RadioPuzzleSetup>
    {
        [HideInInspector]
        public bool HasPuzzleStarted;

        public RadioPuzzleData puzzleData;
        public Pile pile;
        public Radio radio;
        
        public Puzzle puzzle;

        private void Start()
        {
            puzzle = new Puzzle(puzzleData);

            PuzzleManager.Instance.StartPuzzle(puzzle);
        }
    }
}
