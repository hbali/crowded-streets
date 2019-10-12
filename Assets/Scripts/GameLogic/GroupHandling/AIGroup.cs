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
    class AIGroup : Group
    {
        protected override void Awake()
        {
            base.Awake();
            SetMovementController(new AIMovementController());
        }

        public override void Initialize()
        {
            base.Initialize();
            leader = ModelLoader.LoadModel(modelType);
            leader.SetParent(Parent, false);
            DestroyImmediate(leader.GetComponent<Rigidbody>());
        }
    }
}
