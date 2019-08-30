using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [System.Serializable]
    public class ZigZagMover : Mover
    {
        public float xMin, xMax;

        // Движение по траектории зиг-зага, в диапозоне между xMin и xMax, со скоростью speed
        public void AddZigZagMove(Rigidbody2D rb2d)
        {
            rb2d.position = new Vector2(Mathf.Clamp(rb2d.position.x, xMin - 0.01f, xMax + 0.01f), rb2d.position.y); // границы зик-зака

            if (rb2d.position.x < xMin || rb2d.position.x > xMax)
            {
                direction = new Vector2(direction.x * -1, direction.y);
            }
            rb2d.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }
}