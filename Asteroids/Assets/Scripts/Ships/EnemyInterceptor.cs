using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyInterceptor : MonoBehaviour
    {
        public EnemyShip interceptor;
        public StraightMover straightMover;
        private Rigidbody2D rb;
        private GameController gameController;
        private AudioManager audioManager;
        
        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            gameController = FindObjectOfType<GameController>();
            interceptor.currentHealth = interceptor.maxHealth;
            rb = GetComponent<Rigidbody2D>();
            straightMover.AddVelocity(rb);
        }

        void Update()
        {
            if (interceptor.Health <= 0)
            {
                gameController.Score(interceptor.reward);
                DestroyShip();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PlayerBullet")
            {
                if (other.GetComponent<TransmitValue>() != null)
                    interceptor.Health = -other.GetComponent<TransmitValue>().value;
            }
            if (other.tag == "Player")
                DestroyShip();
        }

        void DestroyShip()
        {
            PlayAudio("Explosion");
            Instantiate(interceptor.explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
                audioManager.Play(soundName);
        }
    }
}