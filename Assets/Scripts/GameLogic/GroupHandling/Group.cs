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
    abstract class Group
    {
        private string modelType;

        //for a lot of models, hashset will be faster, also guarantees no duplication
        protected HashSet<Transform> models;

        protected Transform parent;
        private MovementController movement;

        public Group(MovementController movement)
        {
            this.movement = movement;
            Initialize();
        }

        public void Initialize()
        {
            modelType = "Capsule";
            models = new HashSet<Transform>();
            parent = new GameObject().transform;
            AddActor();
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
            model.SetParent(parent, false);
        }

        public void RemoveActor(Transform model)
        {
            models.Remove(model);
        }
    }
}
