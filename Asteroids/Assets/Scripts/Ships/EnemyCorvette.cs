using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyCorvette : MonoBehaviour
    {
        public EnemyShip corvette;
        public StraightMover straightMover;
        private Rigidbody2D rb;
        private GameController gameController;
        private AudioManager audioManager;
        
        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            gameController = FindObjectOfType<GameController>();
            corvette.currentHealth = corvette.maxHealth;
            rb = GetComponent<Rigidbody2D>();
            straightMover.AddVelocity(rb);
        }

        void Update()
        {
            if (corvette.Health <= 0)
            {
                gameController.Score(corvette.reward);
                DestroyShip();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PlayerBullet")
            {
                if (other.GetComponent<TransmitValue>() != null)
                    corvette.Health = -other.GetComponent<TransmitValue>().value;
            }
            if (other.tag == "Player")
                DestroyShip();
        }

        void DestroyShip()
        {
            PlayAudio("Explosion");
            Instantiate(corvette.explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
                audioManager.Play(soundName);
        }
    }
}