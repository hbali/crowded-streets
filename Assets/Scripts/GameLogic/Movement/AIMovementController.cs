using Extensions;
using GameLogic.GroupHandling;
using GameLogic.GroupHandling.Individual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Movement
{
    class AIMovementController : MovementController
    {
        private NeutralGroup neutrals;
        private List<AbsorbingGroup> abs;
        private AbsorbingGroup current;

        public AIMovementController(NeutralGroup neutrals, List<AbsorbingGroup> abs)
        {
            this.neutrals = neutrals;
            this.abs = abs;
        }

        public void SetMyGroup(AbsorbingGroup current)
        {
            this.current = current;
            abs.Remove(current);
        }

        internal override Vector2 GetCurrentDirection()
        {
            Actor closest = Closest(neutrals.Actors);
            Actor closestEnemy = Closest(abs.Select(x => x.Leader));

            if (closestEnemy.ActorGroup.ModelCount > 0 && closestEnemy.ActorGroup.ModelCount < current.ModelCount)
            {
                closest = Vector3.Distance(current.Leader.Position, closest.Position) >
                          Vector3.Distance(current.Leader.Position, closestEnemy.Position) ?
                          closestEnemy : closest;
            }

            if (closest != null)
            {
                return (closest.Position - current.Leader.Position).normalized.ToVector2();
            }
            else
            {
                return new Vector2();
            }
        }

        private Actor Closest(IEnumerable<Actor> actors)
        {
            float min = float.MaxValue;
            Actor closest = null;
            foreach(Actor act in actors)
            {
                float dist = Vector3.Distance(current.Leader.Position, act.Position);
                if (dist < min)
                {
                    closest = act;
                    min = dist;
                }
            }
            return closest;
        }
    }
}
