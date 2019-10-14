using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Movement
{
    class PlayerMovementController : MovementController
    {
        /// <summary>
        /// As per specification there is no 'stop state' for the user
        /// So we have to start the movement even if user isnt touching
        /// </summary>
        private Vector2 lastInputPos = new Vector2(0, 1);

        /// <summary>
        /// Returns current normalized move direction
        /// </summary>
        /// <returns></returns>
        internal override Vector2 GetCurrentDirection()
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
            //the player will move even if the user isnt touching the screen
            //always moves in the direction of the last touch
            if(Input.touchCount == 0)
            {
                inputPos = lastInputPos;
            }
            else
            {        
                inputPos = Input.GetTouch(0).position;             
                lastInputPos = inputPos;
            }
#endif
            return (inputPos - mid).normalized;
        }
    }
}
