using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class RandomRotator : MonoBehaviour
    {
        private float rotateAngle;

        void Start()
        {
            rotateAngle = Random.Range(-0.5f, 0.5f);
        }

        void Update()
        {
            transform.Rotate(new Vector3(0, 0, rotateAngle));
        }
    }
}