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
        private Transform player;

        public CameraMovementController(Transform player)
        {
            this.camera = Camera.main;
            this.player = player;
        }

        public void MoveCamera()
        {
            Vector3 pos = player.position;
            camera.transform.position = new Vector3(pos.x, pos.y + 10, pos.z - 10);
        }
    }
}
