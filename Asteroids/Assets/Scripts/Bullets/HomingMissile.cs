using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class HomingMissile : MonoBehaviour
    {
        public HomingMover homingMover;
        public EnemyShip missile;
        private Rigidbody2D rb;
        private GameObject target;
        private GameController gameController;
        private AudioManager audioManager;
        
        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            gameController = FindObjectOfType<GameController>();
            missile.currentHealth = missile.maxHealth;
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player");
        }
        
        void Update()
        {
            if (missile.Health <= 0)
            {
                gameController.Score(missile.reward);
                DestroyShip();
            }
        }

        void FixedUpdate()
        {
            homingMover.Following(rb, transform.position, target);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PlayerBullet")
            {
                if (other.GetComponent<TransmitValue>() != null)
                    missile.Health = -other.GetComponent<TransmitValue>().value;
            }
            if (other.tag == "Player")
            {
                DestroyShip();
            }
        }

        // Вражеский корабль уничтожен — проигрываем звук и анимацию взрыва, уничтожаем объект
        void DestroyShip()
        {
            PlayAudio("Explosion");
            Instantiate(missile.explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
                audioManager.Play(soundName);
        }
    }
}