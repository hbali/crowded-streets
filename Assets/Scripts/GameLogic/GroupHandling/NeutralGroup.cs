using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Movement;
using ResourceHandling;
using UnityEngine;

namespace GameLogic.GroupHandling
{
    class NeutralGroup : Group
    {
        private const int NEUTRAL_COUNT = 100;


        protected override void Awake()
        {
            base.Awake();
            SetMovementController(new NeutralMovementController());
        }

        public override void Initialize()
        {
            base.Initialize();            
            CreateNeutrals();
        }

        private void CreateNeutrals()
        {
            Transform model;
            for (int i = 0; i < NEUTRAL_COUNT; i++)
            {
                model = ModelLoader.LoadModel(modelType);
                SetRandomPosition(model);
                AddActor(model);
            }
        }

        private void SetRandomPosition(Transform model)
        {
            float x = UnityEngine.Random.Range(Map.Instance.MinX, Map.Instance.MaxX);
            float z = UnityEngine.Random.Range(Map.Instance.MinZ, Map.Instance.MaxZ);
            model.position = new Vector3(x, model.position.y, z);
        }
    }
}
