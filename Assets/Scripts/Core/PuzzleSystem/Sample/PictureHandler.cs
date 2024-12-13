using PuzzleSystem.Core;
using UnityEngine;

namespace LastTrain.Core.Core.PuzzleSystem.Sample
{
    public class PictureHandler : MonoBehaviour, IPuzzleHandler<PictureContext>
    {
        [SerializeField] private GameObject doll;
        [SerializeField] private PickUpObject[] pickUps;
        private Pictures puzzle;
        
        private void Start()
        {
            puzzle = new Pictures();
            PuzzleManager.Instance.StartPuzzle(puzzle, this);
        }

        public PictureContext GetContext()
        {
            return new PictureContext
            {
                pickUps = pickUps,
                doll = doll,
            };
        }
    }
}