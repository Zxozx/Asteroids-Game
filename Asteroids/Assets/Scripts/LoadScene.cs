using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Asteroids
{
    // Загружаем сцену с именем sceneName
    public class LoadScene : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public string sceneName;

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // При выходе из игры через меню паузы, восстанавливаем время в игре
            if (Time.timeScale != 1)
                Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
        }
    }
}