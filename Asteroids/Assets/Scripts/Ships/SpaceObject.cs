using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    // Родительский класс для всех кораблей и астероидов
    public class SpaceObject
    {
        public float maxHealth;
        [HideInInspector]
        public float currentHealth;
        public float Health
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = currentHealth + value;
                if (currentHealth > maxHealth)
                    currentHealth = maxHealth;

                else if (currentHealth < 0)
                    currentHealth = 0;
            }
        }

        void Awake()
        {
            currentHealth = maxHealth;
        }
    }
}