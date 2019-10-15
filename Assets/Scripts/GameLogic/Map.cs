using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic
{
    class Map : SingletonMonoBehaviour<Map>
    {
        private const float OFFSET = 10;

        [SerializeField] private Transform terrain;

        public float X { get; private set; }
        public float Z { get; private set; }

        #region map constraints
        public float MinX => (terrain.position.x - X / 2) + OFFSET;

        public float MaxX => (terrain.position.x + X / 2) - OFFSET;

        public float MinZ => (terrain.position.x - Z / 2) + OFFSET;

        public float MaxZ => (terrain.position.x + Z / 2) - OFFSET;
        #endregion

        private void Awake()
        {
            X = terrain.localScale.x;
            //map is rotated
            Z = terrain.localScale.y;
        }

    }
}
