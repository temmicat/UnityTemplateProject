using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

namespace LastTrain.Core
{
    public class Code : MonoBehaviour
    {
        [SerializeField] private Text Ans;

        private string Reponse = "456";

        public void Number(int number)
        {
            Ans.text += number.ToString();
        }


        public void Suppr()
        {
            if (Ans.text.Length > 0)
            {
                Ans.text = Ans.text.Substring(0, Ans.text.Length - 1);
            }
        }

        public void Execute()
        {
            if (Ans.text == Reponse)
            {
                Ans.text = "OUVERTURE EN COURS...";
            }
            else
            {
                Ans.text = "mauvais numero";
            }


        }
    }
}
