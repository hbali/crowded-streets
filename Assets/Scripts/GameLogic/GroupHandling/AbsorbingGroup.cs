using Extensions;
using GameLogic.GroupHandling;
using GameLogic.GroupHandling.Individual;
using ResourceHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.GroupHandling
{
    abstract class AbsorbingGroup : Group
    {
        public override void Initialize()
        {
            base.Initialize();
            Leader = ModelLoader.LoadModel<Actor>(actType);
            Leader.SetParent(Parent, false);
            Leader.SetRandom();
        }

        public override void Move()
        {
            if (Leader.ActorGroup == this)
            {
                Vector3 dir = movement.GetCurrentDirection().ToVector3();
                Leader.Move(dir);
                Leader.Rotate(dir);
                Vector3 lpos = Leader.Position;

                //collection might be modified during move collision check, so copy the list
                foreach (Actor act in actors.ToList())
                {
                    if (act.Leader == this.Leader)
                    {
                        dir = (lpos - act.Position).normalized;
                        act.Move(dir);
                        act.Rotate(dir);
                    }
                }
            }
        }
    }
}
