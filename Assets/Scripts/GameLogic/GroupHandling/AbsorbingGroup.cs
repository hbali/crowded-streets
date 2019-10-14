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

        }
    }
}
