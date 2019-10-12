using Extensions;
using GameLogic.Movement;
using ResourceHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic.GroupHandling
{
    class PlayerGroup : Group
    {
        protected override Color32 MaterialColor => new Color32(255, 0, 0, 255);

        protected override void Awake()
        {
            base.Awake();
            SetMovementController(new PlayerMovementController());
        }

        private void OnCollisionEnter(Collision collision)
        {
            Group collider = collision.collider.GetComponentInParent<Group>();
            if (collider is NeutralGroup neutral)
            {
                neutral.RemoveActor(collision.transform);
                AddActor(collision.transform);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            leader = ModelLoader.LoadModel(modelType);
            leader.SetParent(Parent, false);
            DestroyImmediate(leader.GetComponent<Rigidbody>());
        }

        public override void Move()
        {
            Vector3 dir = movement.GetCurrentDirection().ToVector3();
            leader.Translate(dir * Speed);
            Vector3 lpos = leader.position;
            Camera.main.transform.position = new Vector3(lpos.x, lpos.y + 10, lpos.z - 10);

            foreach (Transform model in models)
            {
                dir = (lpos - model.position).normalized;
                model.Translate(dir * Speed);
            }
        }
    }
}
