using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        public EnemyShip asteroid;
        public StraightMover straightMover;
        private Rigidbody2D rb;
        private GameController gameController;
        private AudioManager audioManager;
        
        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            gameController = FindObjectOfType<GameController>();
            asteroid.currentHealth = asteroid.maxHealth;
            rb = GetComponent<Rigidbody2D>();
            straightMover.AddVelocity(rb);
        }

        void Update()
        {
            if (asteroid.Health <= 0)
            {
                gameController.Score(asteroid.reward);
                DestroyShip();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PlayerBullet")
            {
                if (other.GetComponent<TransmitValue>() != null)
                    asteroid.Health = -other.GetComponent<TransmitValue>().value;
            }
            if (other.tag == "Player")
                DestroyShip();
        }
        
        void DestroyShip()
        {
            PlayAudio("Explosion");
            Instantiate(asteroid.explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
                audioManager.Play(soundName);
        }
    }
}