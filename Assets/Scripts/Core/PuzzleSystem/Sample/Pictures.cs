using PuzzleSystem.Core;
using UnityEngine;

namespace LastTrain.Core.Core.PuzzleSystem.Sample
{
    public class Pictures : Puzzle<PictureContext>
    {
        public override void Begin(ref PictureContext context)
        {
        }

        public override bool Refresh(ref PictureContext context)
        {
            for (int i = 0; i < context.pickUps.Length; i++)
            {
                if (!context.pickUps[i].OnCadre)
                {
                    return false;
                }
            }

            return true;
        }

        public override void End(ref PictureContext context, bool isSuccess)
        {
            context.doll.SetActive(true);
        }
    }
}