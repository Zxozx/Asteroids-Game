using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    // Уничтожаем объект по истечении времени time
    public class DestroyByTime : MonoBehaviour
    {
        public float time;

        void Start()
        {
            Destroy(gameObject, time);
        }
    }
}