using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroids
{
    public class PauseOff : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public GameObject pausedGO;

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Time.timeScale = 1;
            pausedGO.SetActive(false);
        }
    }
}