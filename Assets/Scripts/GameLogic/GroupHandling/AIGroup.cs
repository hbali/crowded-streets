using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Movement;

namespace GameLogic.GroupHandling
{
    class AIGroup : Group
    {
        public AIGroup() : base(new AIMovementController())
        {

        }
    }
}
