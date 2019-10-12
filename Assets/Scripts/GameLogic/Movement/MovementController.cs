using System;
using UnityEngine;

namespace GameLogic.Movement
{
    abstract class MovementController
    {
        /// <summary>
        /// Returns current normalized move direction
        /// </summary>
        /// <returns></returns>
        internal Vector2 GetCurrentDirection()
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            //because the player is fixed on the middle of the screen
            //we can make it easier to calculate the direction
            Vector2 mid = new Vector2(x, y);
            Vector2 inputPos;
#if UNITY_EDITOR
            inputPos = Input.mousePosition;
#else
            inputPos = Input.GetTouch(0).position; 
#endif
            return (inputPos - mid).normalized;
        }
    }
}