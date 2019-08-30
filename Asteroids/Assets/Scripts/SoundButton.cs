using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroids
{
    public class SoundButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public GameObject soundOnButton, soundOffButton;

        void Start()
        {
            SoundOnOff(AudioListener.volume);
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            SoundOnOff();
        }

        void SoundOnOff()
        {
            if (AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
                soundOffButton.SetActive(true);
                soundOnButton.SetActive(false);

            }

            else
            {
                AudioListener.volume = 1;
                soundOnButton.SetActive(true);
                soundOffButton.SetActive(false);
            }
        }
        void SoundOnOff(float volume)
        {
            if (AudioListener.volume == 1)
            {
                soundOffButton.SetActive(false);
                soundOnButton.SetActive(true);
            }
            else
            {
                soundOnButton.SetActive(false);
                soundOffButton.SetActive(true);
            }
        }
    }
}