using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GroupHandling.Individual
{
    abstract class Actor : MonoBehaviour
    {
        [SerializeField] protected Transform model;

        protected virtual float Speed => 20;

        public void Move(Vector3 dir)
        {
            model.Translate(dir * Speed);
        }
    }
}