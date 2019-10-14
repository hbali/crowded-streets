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
        protected override Color32 MaterialColor => new Color32(255, 0, 0, 255);

        protected override void Awake()
        {
            base.Awake();
            SetMovementController(new PlayerMovementController());
        }

        public override void Move()
        {
            Vector3 dir = movement.GetCurrentDirection().ToVector3();
            Leader.Move(dir);
            Leader.Rotate(dir);
            Vector3 lpos = Leader.Position;
            //refactor this to proper camera class
            Camera.main.transform.position = new Vector3(lpos.x, lpos.y + 10, lpos.z - 10);

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
