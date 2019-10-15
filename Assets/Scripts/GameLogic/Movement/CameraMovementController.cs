using GameLogic.GroupHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.Movement
{
    class CameraMovementController
    {
        private Camera camera;
        private Group playerGroup;

        public CameraMovementController(Group playerGroup)
        {
            this.camera = Camera.main;
            this.playerGroup = playerGroup;
        }

        public void MoveCamera()
        {
            Vector3 pos = playerGroup.Leader.Position;
            float offset = 10 + playerGroup.ModelCount / 10;
            camera.transform.position = new Vector3(pos.x, pos.y + offset, pos.z - offset);
        }
    }
}
