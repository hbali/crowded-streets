using Core;
using GameLogic.GroupHandling;
using ResourceHandling;
using UnityEngine;

namespace GameLogic
{
    class Logic : SingletonMonoBehaviour<Logic>
    {
        private PlayerGroup playerGroup;
        private NeutralGroup neutralGroup;

        public void Initialize()
        {
            playerGroup = ModelLoader.LoadModel("PlayerGroup").GetComponent<PlayerGroup>();
            neutralGroup = new GameObject("neutrals").AddComponent<NeutralGroup>();
        }

        private void Update()
        {
            playerGroup.Move();
        }
    }
}
