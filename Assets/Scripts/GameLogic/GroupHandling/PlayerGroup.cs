using GameLogic.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.GroupHandling
{
    class PlayerGroup : Group
    {
        public PlayerGroup() : base(new PlayerMovementController())
        {

        }
    }
}
