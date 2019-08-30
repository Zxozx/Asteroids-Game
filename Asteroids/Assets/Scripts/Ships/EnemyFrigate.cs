﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyFrigate : MonoBehaviour
    {
        public EnemyShip frigate;
        public ZigZagMover zigZagMover;
        private Rigidbody2D rb;
        private GameController gameController;
        private AudioManager audioManager;
        
        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            gameController = FindObjectOfType<GameController>();
            rb = GetComponent<Rigidbody2D>();
            frigate.currentHealth = frigate.maxHealth;
        }

        void Update()
        {
            if (frigate.Health <= 0)
            {
                gameController.Score(frigate.reward);
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
                    frigate.Health = -other.GetComponent<TransmitValue>().value;
            }
            if (other.tag == "Player")
                DestroyShip();
        }

        void DestroyShip()
        {
            PlayAudio("Explosion");
            Instantiate(frigate.explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        void PlayAudio(string soundName)
        {
            if (audioManager != null)
                audioManager.Play(soundName);
        }
    }
}