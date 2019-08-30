using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    // Уничтожаем все объекты вышедшие из области видимости игрока
    public class Destroyer : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}