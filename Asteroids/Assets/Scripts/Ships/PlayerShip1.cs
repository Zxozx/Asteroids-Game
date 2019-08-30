using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerShip1 : MonoBehaviour
    {
        public PlayerShip playerShip1;
        private Rigidbody2D rb;
        private GameController gameController;
        private PlayerController playerController;

        private AudioManager audioManager;

        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            rb = GetComponent<Rigidbody2D>();
            playerShip1.currentHealth = playerShip1.maxHealth;
            gameController = FindObjectOfType<GameController>();
            playerController = FindObjectOfType<PlayerController>();

            playerShip1.currentHealth = playerShip1.maxHealth;
        }

        void Update()
        {
            DestroyShip();
        }

        void FixedUpdate()
        {
            rb.position = new Vector2(Mathf.Clamp(rb.position.x, playerShip1.xMin, playerShip1.xMax), rb.position.y);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "EnemyBullet")
            {
                if (other.GetComponent<TransmitValue>() != null)
                {
                    playerShip1.Health = -other.GetComponent<TransmitValue>().value;
                    playerController.UpdateHealthBar();
                }
            }

            if (other.tag == "Enemy")
            {
                if (other.GetComponent<TransmitValue>() != null)
                {
                    playerShip1.Health = -other.GetComponent<TransmitValue>().value;
                    playerController.UpdateHealthBar();
                }
            }

            if (other.tag == "HealthUp")
            {
                if (other.GetComponent<TransmitValue>() != null)
                {
                    PlayAudio("PowerUp");
                    playerShip1.Health = other.GetComponent<TransmitValue>().value;
                    playerController.UpdateHealthBar();
                }
            }

            if (other.tag == "PowerUp")
            {
                PlayAudio("PowerUp");
                playerController.PowerUp();
            }
        }

        void DestroyShip()
        {
            if (playerShip1.Health <= 0)
            {
                PlayAudio("GameOver");
                gameController.GameOver();
                Instantiate(playerShip1.explosionPrefab, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
                audioManager.Play(soundName);
        }
    }
}