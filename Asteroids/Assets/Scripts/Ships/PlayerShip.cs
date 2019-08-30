using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids {
    [System.Serializable]
    public class PlayerShip : SpaceObject
    {
        public float xMin = -2;
        public float xMax = 2;
        public GameObject explosionPrefab;
    }
}