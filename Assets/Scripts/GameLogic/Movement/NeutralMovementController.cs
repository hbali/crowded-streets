using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.GroupHandling.Individual;
using UnityEngine;

namespace GameLogic.Movement
{
    class NeutralMovementController : MovementController
    {
        private const int MOVE_CHANGE = 1000;

        internal override Vector2 GetCurrentDirection()
        {
            return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        }

        /// <summary>
        /// Generates a new direction based on the previous! 
        /// It will not change directions every frame to avoid silly movement
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        internal override Vector2 GetCurrentDirection(Actor act)
        {
            if(act.MHistory.count > MOVE_CHANGE || act.MHistory.count == 0)
            {
                act.MHistory.count = 1;
                act.MHistory.prevDir = GetCurrentDirection();
                return act.MHistory.prevDir;
            }
            else
            {                
                act.MHistory.count++;
                return act.MHistory.prevDir;
            }
        }
    }
}
