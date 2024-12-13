using System;
using LastTrain.Core.Core.PuzzleSystem.Sample;
using PuzzleSystem.Core;
using UnityEngine;

namespace LastTrain.Core
{
    public class BAM : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip clipUnfinished, clipFinished;
        private AudioClip targetClip;

        private void Start()
        {
            targetClip = clipUnfinished;
        }

        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStopped += OnPuzzleStopped;
        }

        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStopped -= OnPuzzleStopped;
        }
        
        private void OnPuzzleStopped(IPuzzleRunner puzzleRunner)
        {
            if (puzzleRunner.Puzzle is not Pictures) return;

            targetClip = clipFinished;
            Debug.Log("Change clip");
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (source.isPlaying) return;
                source.clip = targetClip;
                source.Play();
            }
        }
    }
}
