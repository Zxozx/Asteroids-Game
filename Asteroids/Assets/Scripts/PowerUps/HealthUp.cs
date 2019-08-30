﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class HealthUp : MonoBehaviour
    {
        public GameObject explosionPrefab;
        public ZigZagMover zigZagMover;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            zigZagMover.AddZigZagMove(rb);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}