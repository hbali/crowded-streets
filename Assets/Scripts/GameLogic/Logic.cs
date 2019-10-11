using Core;
using GameLogic.GroupHandling;
using GameLogic.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic
{
    class Logic : SingletonMonoBehaviour<Logic>
    {
        private PlayerGroup playerGroup;

        public void Initialize()
        {
            playerGroup = new PlayerGroup();
        }
    }
}
