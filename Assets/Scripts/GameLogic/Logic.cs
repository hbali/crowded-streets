using Core;
using GameLogic.GroupHandling;
using GameLogic.Movement;
using ResourceHandling;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    class Logic : SingletonMonoBehaviour<Logic>
    {
        private const int AICOUNT = 0;
        private PlayerGroup playerGroup;
        private NeutralGroup neutralGroup;
        private List<AIGroup> aiGroups;
        private CameraMovementController cameraControl;

        public void Initialize()
        {
            playerGroup = ModelLoader.LoadModel<PlayerGroup>("PlayerGroup");
            neutralGroup = ModelLoader.LoadModel<NeutralGroup>("NeutralGroup");
            CreateAIs();
            cameraControl = new CameraMovementController(playerGroup.Leader.transform);
        }

        private void CreateAIs()
        {
            aiGroups = new List<AIGroup>();
            AIGroup aiGroup;
            for (int i = 0; i < AICOUNT; i++)
            {
                aiGroup = ModelLoader.LoadModel<AIGroup>("AIGroup");
                aiGroups.Add(aiGroup);
                aiGroup.SetColor(UnityEngine.Random.ColorHSV());
            }
            foreach (AIGroup aig in aiGroups)
            {
                aig.SetMovementController(new AIMovementController(neutralGroup, new List<AbsorbingGroup>(aiGroups) { playerGroup }));
            }
        }

        private void Update()
        {
            playerGroup.Move();
            foreach (AIGroup aig in aiGroups)
            {
                aig.Move();
            }
            cameraControl.MoveCamera();
        }
    }
}
