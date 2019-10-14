using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.GroupHandling.Individual;
using GameLogic.Movement;
using ResourceHandling;
using UnityEngine;

namespace GameLogic.GroupHandling
{
    class NeutralGroup : Group
    {
        [SerializeField] private int NEUTRAL_COUNT = 3;

        protected override Color32 MaterialColor => Color.white;


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
            Actor act;
            for (int i = 0; i < NEUTRAL_COUNT; i++)
            {
                act = ModelLoader.LoadModel<Actor>(actType);
                AddActor(act);
                SetRandomPosition(act);
            }
        }

        private void SetRandomPosition(Actor act)
        {
            act.SetRandom();
        }
    }
}
