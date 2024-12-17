using System;
using System.Collections;
using System.Collections.Generic;
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
        public GameObject InputInstruction;

        private void Start()
        {
            targetClip = clipUnfinished;
        }

        private void OnEnable()
        {

            StartCoroutine(DisplayText());
            
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
        }
        
        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (source.isPlaying) return;
                source.clip = targetClip;
                source.Play();
            }
        }
        
        private IEnumerator DisplayText()
        {
            InputInstruction.SetActive(true);

            yield return new WaitForSeconds(2f);
            
            InputInstruction.SetActive(false);
        }
    }
}
