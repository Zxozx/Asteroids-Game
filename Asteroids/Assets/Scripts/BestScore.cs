using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    // Выводим на экран лучший результат игрока
    public class BestScore : MonoBehaviour
    {
        private Text bestScoreText;

        void Start()
        {
            bestScoreText = GetComponent<Text>();

            if (PlayerPrefs.HasKey("BestScore") != false)
            {
                bestScoreText.text = "BEST SCORE\n" + PlayerPrefs.GetInt("BestScore").ToString("0000000");
            }
        }
    }
}