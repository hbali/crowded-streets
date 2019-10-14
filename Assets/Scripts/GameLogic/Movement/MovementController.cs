using System;
using UnityEngine;

namespace GameLogic.Movement
{
    abstract class MovementController
    {
        internal abstract Vector2 GetCurrentDirection();
    }
}