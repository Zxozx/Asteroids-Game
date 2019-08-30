using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class InstGameObj : MonoBehaviour
    {
        // Диапозон координат появления объектов
        private Vector2 instPoint;
        public float instXMin, instXMax;

        // Объект который будет создан
        public GameObject instObject;

        // Интервал между появлением объекта
        public float interval, intervalReduceFactor;
        private float instTime;
        
        private GameController gameController;

        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            instTime = interval;
        }

        void Update()
        {
            InstDelay();
        }

        void InstDelay()
        {
            if (gameController.gameOn == true)
            {
                instTime -= Time.deltaTime;
                if (instTime <= 0)
                {
                    InstObject();
                    UpdateInterval();
                }
            }
        }

        // Метод создает объект в случайном месте в диапозоне между instXMin и instXMax
        void InstObject()
        {
            instPoint = new Vector2(Random.Range(instXMin, instXMax), transform.position.y);
            Instantiate(instObject, instPoint, transform.rotation);
        }

        // Время появления объекта уменьшается в зависимости от текущего уровня
        void UpdateInterval()
        {
            instTime = interval * Mathf.Pow(intervalReduceFactor, gameController.level);
        }
    }
}