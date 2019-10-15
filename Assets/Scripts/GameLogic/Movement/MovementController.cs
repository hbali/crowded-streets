using System;
using UnityEngine;

namespace GameLogic.Movement
{
    abstract class MovementController
    {
        internal virtual Vector2 GetCurrentDirection(GroupHandling.Individual.Actor act) { return new Vector2(); }
        internal abstract Vector2 GetCurrentDirection();
    }
}