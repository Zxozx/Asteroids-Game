using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerGunSound : MonoBehaviour
    {
        private Gun playerGun;
        private AudioManager audioManager;

        float timer;
        float nextSound;

        void Start()
        {
            playerGun = GetComponent<PlayerGun>().gun;
            audioManager = FindObjectOfType<AudioManager>();
            timer = playerGun.nextShot;
        }

        void Update()
        {
            GunSound();
        }

        void GunSound()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                audioManager.Play("Shot");
                timer = playerGun.nextShot;
            }
        }
    }
}