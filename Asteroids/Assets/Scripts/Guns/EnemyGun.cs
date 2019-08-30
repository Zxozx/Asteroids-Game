using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyGun : MonoBehaviour
    {
        public Gun gun;

        void Update()
        {
            NextShotTimer();
        }

        public void NextShotTimer()
        {
            gun.nextShot -= Time.deltaTime;
            if (gun.nextShot <= 0)
            {
                Instantiate(gun.bullet, transform.position, transform.rotation);
                gun.nextShot = gun.shotDelay;
            }
        }
    }
}