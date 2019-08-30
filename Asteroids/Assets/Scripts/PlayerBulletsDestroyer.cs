using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    // Уничтожаем выстрелы игрока
    public class PlayerBulletsDestroyer : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PlayerBullet")
            {
                Destroy(other.gameObject);
            }
        }
    }
}