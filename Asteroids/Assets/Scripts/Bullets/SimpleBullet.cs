using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class SimpleBullet : MonoBehaviour
    {
        public StraightMover straightMover;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            straightMover.AddVelocity(rb);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}