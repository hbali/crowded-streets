using Extensions;
using GameLogic.GroupHandling.Individual;
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
    class PlayerGroup : AbsorbingGroup
    {
        public override float Speed => base.Speed * 1.5f;
        public override Color32 MaterialColor => new Color32(255, 0, 0, 255);

        protected override void Awake()
        {
            base.Awake();
            SetMovementController(new PlayerMovementController());
        }
    }
}
