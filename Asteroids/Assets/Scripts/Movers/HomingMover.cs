using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [System.Serializable]
    public class HomingMover : Mover
    {
        public float xSpeed;

        // Объект наводится на цель
        public void Following(Rigidbody2D rb2d, Vector2 objectPosition, GameObject target)
        {
            if (target != null)
            {
                if (objectPosition.y > target.transform.position.y + 0.2f && objectPosition.x != target.transform.position.x)
                {
                    rb2d.velocity = new Vector2(Mathf.Sign(target.transform.position.x - objectPosition.x) * xSpeed, direction.y * speed) * Time.fixedDeltaTime;
                }
                else
                {
                    return;
                }
            }
            else
            {
                rb2d.velocity = new Vector2(0, direction.y) * speed * Time.fixedDeltaTime;
            }
        }
    }
}