using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [System.Serializable]
    public class Gun
    {
        public float shotDelay;
        public float shotRateFactor = 1;
        [HideInInspector]
        public float nextShot;
        
        public GameObject bullet;

        void Awake()
        {
            nextShot = shotDelay;
        }
    }
}