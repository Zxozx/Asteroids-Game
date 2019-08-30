using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        private static PlayerController instance;

        private Rigidbody2D rb;
        private GameController gameController;
        private GameObject playerShipGo;
        private PlayerShip1 playerShip;

        public int powerLvl = 0;

        public GameObject healthBarGo;
        private Image bar;

        public GameObject[] guns;

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
            playerShipGo = GameObject.FindGameObjectWithTag("Player");
            playerShip = playerShipGo.GetComponent<PlayerShip1>();
            audioManager = FindObjectOfType<AudioManager>();
            gameController = FindObjectOfType<GameController>();
            bar = healthBarGo.GetComponent<Image>();

            TurnOnWepons();
        }

        // Обновляем шкалу здоровья игрока
        public void UpdateHealthBar()
        {
            bar.fillAmount = playerShip.playerShip1.Health * (playerShip.playerShip1.maxHealth / 100);
        }

        // Увеличиваем мощность оружия игрока
        public void PowerUp()
        {
            powerLvl++;
            if (powerLvl < guns.Length)
                TurnOnWepons();
        }

        // При увеличении уровня мощности открываем дополнительные орудия
        void TurnOnWepons()
        {
            for (int i = 0; i < guns.Length; i++)
            {
                if (i == powerLvl)
                {
                    guns[i].SetActive(true);
                }
                else
                {
                    guns[i].SetActive(false);
                }
            }
        }
    }
}