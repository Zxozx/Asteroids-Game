using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyCruiser : MonoBehaviour
    {
        public EnemyShip cruiser;
        public ZigZagMover zigZagMover;
        private Rigidbody2D rb;
        private GameController gameController;
        private AudioManager audioManager;

        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            gameController = FindObjectOfType<GameController>();
            rb = GetComponent<Rigidbody2D>();
            cruiser.currentHealth = cruiser.maxHealth;
        }

        void Update()
        {
            if (cruiser.Health <= 0)
            {
                gameController.Score(cruiser.reward);
                DestroyShip();
            }
        }

        void FixedUpdate()
        {
            zigZagMover.AddZigZagMove(rb);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PlayerBullet")
            {
                if (other.GetComponent<TransmitValue>() != null)
                    cruiser.Health = -other.GetComponent<TransmitValue>().value;
            }
            if (other.tag == "Player")
                DestroyShip();
        }

        void DestroyShip()
        {
            PlayAudio("Explosion");
            Instantiate(cruiser.explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
                audioManager.Play(soundName);
        }
    }
}