using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Stars : MonoBehaviour
    {
        private Rigidbody2D rb;
        public StraightMover straightMover;
        public Vector2 startPoint, endPoint;
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            straightMover.AddVelocity(rb);
            RelocateGO();
        }

        void RelocateGO()
        {
            if (rb.position.y <= endPoint.y)
                rb.position = startPoint;
        }
    }
}