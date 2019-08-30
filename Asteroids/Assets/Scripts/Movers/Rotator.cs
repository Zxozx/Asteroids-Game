using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Rotator : MonoBehaviour
    {
        public float speed;

        void Start()
        {

        }

        void Update()
        {
            transform.Rotate(new Vector3(0, 0, speed));
        }
    }
}