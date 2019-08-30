using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    // Родительский класс для вражеских кораблей
    [System.Serializable]
    public class EnemyShip : SpaceObject
    {
        public int reward;
        public GameObject explosionPrefab;
    }
}