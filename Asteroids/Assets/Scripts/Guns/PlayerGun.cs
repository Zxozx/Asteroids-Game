using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerGun : MonoBehaviour
    {
        private PlayerController playerController;
        public Gun gun;

        void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        void Update()
        {
            NextShotTimer(playerController.powerLvl);
        }

        // Отсчитываем время до следующего выстрела. Время между выстрелами уменьшается в зависимости от уровня мощности
        public void NextShotTimer(int multiplier)
        {
            gun.nextShot -= Time.deltaTime;
            if (gun.nextShot <= 0.1f)
            {
                Instantiate(gun.bullet, transform.position, transform.rotation);
                gun.nextShot = gun.shotDelay * Mathf.Pow(gun.shotRateFactor, multiplier);
            }
        }
    }
}