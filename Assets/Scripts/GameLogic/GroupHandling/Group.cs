using GameLogic.Movement;
using ResourceHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.GroupHandling
{
    abstract class Group : MonoBehaviour
    {
        protected string modelType;

        protected virtual Color32 MaterialColor => new Color32(255, 255, 255, 255);

        //for a lot of models, hashset will be faster, also guarantees no duplication
        protected HashSet<Transform> models;
        protected Transform leader;
        protected MovementController movement;

        protected virtual float Speed => 0.1f;

        protected Transform Parent => this.transform;

        protected virtual void Awake()
        {
            Initialize();
        }

        protected void SetMovementController(MovementController movement)
        {
            this.movement = movement;
        }

        public virtual void Initialize()
        {
            modelType = "Capsule";
            models = new HashSet<Transform>();
        }

        public void AddActor()
        {
            AddActor(modelType);
        }

        public void AddActor(string type)
        {
            Transform tr = ModelLoader.LoadModel(type);
            AddActor(tr);
        }

        public void AddActor(Transform model)
        {
            models.Add(model);
            model.SetParent(Parent, true);
            model.GetComponent<Renderer>().material.color = MaterialColor;
        }

        public void RemoveActor(Transform model)
        {
            models.Remove(model);
        }

        public virtual void Move()
        {
            foreach (Transform model in models)
            {
                model.Translate(movement.GetCurrentDirection() * Speed);
            }
        }
    }
}
