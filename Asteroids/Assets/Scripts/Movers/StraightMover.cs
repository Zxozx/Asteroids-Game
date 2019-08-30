using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [System.Serializable]
    public class StraightMover : Mover
    {
        // Движение вперед в направлении direction, со скоростью speed
        public void AddVelocity(Rigidbody2D rb2d)
        {
            rb2d.velocity = new Vector2(direction.x, direction.y) * speed * Time.fixedDeltaTime;
        }
    }
}