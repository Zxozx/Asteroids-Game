using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroids
{
    public class ControlPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public GameObject player;
        private Rigidbody2D playerRb;

        public float playerSpeed = 0.2f;

        void Start()
        {
            playerRb = player.GetComponent<Rigidbody2D>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        // Управляем позицией игрока
        public void OnDrag(PointerEventData eventData)
        {
            playerRb.position = new Vector2(playerRb.position.x + eventData.delta.x * playerSpeed * Time.fixedDeltaTime, playerRb.position.y);
        }

        public void OnEndDrag(PointerEventData eventData)
        {

        }
    }
}