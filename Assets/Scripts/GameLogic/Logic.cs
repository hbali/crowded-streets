using Core;
using GameLogic.GroupHandling;
using GameLogic.Movement;
using ResourceHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace GameLogic
{
    class Logic : SingletonMonoBehaviour<Logic>
    {
        [SerializeField] private ScoreScreen scores;
        [SerializeField] private Popup popup;

        private const int AICOUNT = 10;
        private PlayerGroup playerGroup;
        private NeutralGroup neutralGroup;
        private List<AIGroup> aiGroups;
        private CameraMovementController cameraControl;

        public void Initialize()
        {
            playerGroup = ModelLoader.LoadModel<PlayerGroup>("PlayerGroup");
            neutralGroup = ModelLoader.LoadModel<NeutralGroup>("NeutralGroup");
            CreateAIs();
            cameraControl = new CameraMovementController(playerGroup);
            scores.Initialize(aiGroups.Union(new Group[] { playerGroup }));
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
            //game not initialized yet
            if (playerGroup == null)
            {
                return;
            }
            playerGroup.Move();
            foreach (AIGroup aig in aiGroups)
            {
                aig.Move();
            }
            cameraControl.MoveCamera();
            neutralGroup.Move();
            neutralGroup.RefreshNeutrals();
            scores.Refresh();
        }

        public void Eliminate(Group actorGroup)
        {
            if(actorGroup == playerGroup)
            {
                popup.GameOver(playerGroup);
                Invoke("Restart", 2f);
            }
            else
            {
                actorGroup.Eliminated = true;
                KilledPopup(actorGroup);
                if(aiGroups.All(x => x.Eliminated))
                {
                    popup.Win(playerGroup);
                    Invoke("Restart", 2f);
                }
            }
        }

        private void Restart()
        {
            foreach(Group g in aiGroups)
            {
                DestroyImmediate(g.gameObject);
            }
            DestroyImmediate(playerGroup.gameObject);
            DestroyImmediate(neutralGroup.gameObject);
            scores.Reset();
            Invoke("Initialize2", 0.5f);
        }
        public void Initialize2()
        {
            //playerGroup = ModelLoader.LoadModel<PlayerGroup>("PlayerGroup");
            neutralGroup = ModelLoader.LoadModel<NeutralGroup>("NeutralGroup");
            //CreateAIs();
            //cameraControl = new CameraMovementController(playerGroup);
            //scores.Initialize(aiGroups.Union(new Group[] { playerGroup }));
        }

        private void KilledPopup(Group group)
        {
            popup.Killed(group);
        }
    }
}
