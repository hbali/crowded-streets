using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;
using GameLogic.GroupHandling.Individual;
using GameLogic.Movement;
using ResourceHandling;
using UnityEngine;

namespace GameLogic.GroupHandling
{
    class AIGroup : AbsorbingGroup
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            (movement as AIMovementController).SetMyGroup(this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void SetColor(Color color)
        {
            MaterialColor = color;
            Leader.ChangeColor(color);

            foreach (Actor act in actors)
            {
                act.ChangeColor(color);
            }
        }

        public override void Move()
        {
            Vector3 dir = movement.GetCurrentDirection().ToVector3();
            Leader.Move(dir);
            Vector3 lpos = Leader.Position;

            foreach (Actor act in actors.ToList())
            {
                if (act.Leader == this.Leader)
                {
                    dir = (lpos - act.Position).normalized;
                    act.Move(dir);
                }
            }
        }
    }
}
