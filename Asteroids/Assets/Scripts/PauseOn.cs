using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroids
{
    public class PauseOn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public GameObject pausedGO;

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            pausedGO.SetActive(true);
            Time.timeScale = 0;
        }
    }
}