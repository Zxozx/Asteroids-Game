using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;

        // Очки уровень сложности
        private int points = 0;
        public int level = 0;
        public float levelTime, nextLevelDelay;
        private float levelTimeLeft;
        public bool gameOn = false;

        // Ссылки на текстовое поле со счетом игрока и ГеймОвер-экран
        private Text scoreText, finalScoreText, levelText;
        public GameObject scoreGO, finalScoreGO, levelGO;
        public GameObject gameOverGO;
        public GameObject playerControlPanel;

        private AudioManager audioManager;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        void Start()
        {
            scoreText = scoreGO.GetComponent<Text>();
            finalScoreText = finalScoreGO.GetComponent<Text>();
            levelText = levelGO.GetComponent<Text>();
            audioManager = FindObjectOfType<AudioManager>();

            NextLevel();
        }

        void Update()
        {
            LevelTimer();
        }

        // Гейм Овер — останавливаем все объекты
        public void GameOver()
        {
            playerControlPanel.SetActive(false);
            gameOverGO.SetActive(true);
            finalScoreText.text = "SCORE\n" + points.ToString("0000000");
            SaveBestScore();
        }

        // Считаем очки и вывдоим на экран
        public void Score(int value)
        {
            points += value;
            scoreText.text = points.ToString("0000000");
            SaveBestScore();
        }

        // Сохраняем результат
        void SaveBestScore()
        {
            if (PlayerPrefs.HasKey("BestScore") == false || PlayerPrefs.GetInt("BestScore") < points)
                PlayerPrefs.SetInt("BestScore", points);
        }

        // Отсчитываем время уровня
        void LevelTimer()
        {
            if (gameOn == true)
            {
                levelTimeLeft -= Time.deltaTime;
                if (levelTimeLeft <= 0)
                {
                    gameOn = false;
                    StartCoroutine(LevelDelay());
                }
            }
        }

        IEnumerator LevelDelay()
        {
            yield return new WaitForSeconds(nextLevelDelay);
            NextLevel();
        }

        // Начинаем следующий уровень
        void NextLevel()
        {
            level++;
            gameOn = true;
            PlayAudio("LevelUp");
            UpdateLevelText();
            UpdateLevelTime();
        }

        // Выводим на экран номер текущего уровня
        void UpdateLevelText()
        {
            levelText.text = $"level {level}";
        }

        // обновляем счетчик уровня
        void UpdateLevelTime()
        {
            levelTimeLeft = levelTime;
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
            {
                audioManager.Play(soundName);
            }
        }
    }
}