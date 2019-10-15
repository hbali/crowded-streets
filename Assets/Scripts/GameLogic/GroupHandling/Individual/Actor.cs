using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GroupHandling.Individual
{
    public class MoveHistory
    {
        public int count;
        public Vector2 prevDir;
    }

    public enum ActorState
    {
        Neutral,
        Following,
        Leader
    }

    class Actor : MonoBehaviour
    {
        public MoveHistory MHistory { get; set; }

        public new Transform transform
        {
            get
            {
                return base.transform;
            }
        }

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
            private set
            {
                transform.position = value;
            }
        }

        private void Awake()
        {
            MHistory = new MoveHistory();
        }

        public ActorState State { get; set; }

        public Actor Leader { get; set; }

        public Group ActorGroup { get; set; }

        protected virtual float Speed => ActorGroup.Speed;

        public void Move(Vector3 dir)
        {
            GetComponent<CharacterController>().Move(dir * Speed * Time.deltaTime);

            if (State != ActorState.Neutral)
            {
                CheckCollision();
            }
        }

        internal void Rotate(Vector3 dir)
        {
            transform.rotation = Quaternion.LookRotation(dir, new Vector3(0, 1, 0));
        }

        private void CheckCollision()
        {
            foreach (Collider clr in Physics.OverlapSphere(Position, 1f))
            {
                Actor act = clr.GetComponent<Actor>();
                if (act != null && act.Leader != this.Leader)
                {
                    CheckStates(act);
                }
            }
        }


        private void CheckStates(Actor act)
        {
            if (act.State != ActorState.Neutral)
            {
                if (act.ActorGroup.ModelCount > ActorGroup.ModelCount)
                {
                    this.ChangeLeader(act.Leader);
                }
                else if (act.ActorGroup.ModelCount < ActorGroup.ModelCount)
                {
                    act.ChangeLeader(this.Leader);
                }
                else
                {
                    //if equals, we dont do anything
                }
            }
            else
            {
                act.ChangeLeader(this.Leader);
            }
        }

        private void ChangeLeader(Actor leader)
        {
            if (State == ActorState.Leader && (leader.ActorGroup is PlayerGroup || ActorGroup is PlayerGroup))
            {
                Logic.Instance.Eliminate(ActorGroup);
            }
            this.Leader = leader;
            State = ActorState.Following;

            ActorGroup.RemoveActor(this);
            leader.ActorGroup.AddActor(this);
        }

        internal void SetParent(Transform parent, bool worldPositionStays)
        {
            transform.SetParent(parent, false);
            ActorGroup = parent.GetComponentInParent<Group>();
        }

        internal void SetRandom()
        {
            float x = UnityEngine.Random.Range(Map.Instance.MinX, Map.Instance.MaxX);
            float z = UnityEngine.Random.Range(Map.Instance.MinZ, Map.Instance.MaxZ);
            Position = new Vector3(x, Position.y, z);
        }

        private MaterialPropertyBlock block;

        internal void ChangeColor(Color32 materialColor)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                if (block == null)
                {
                    block = new MaterialPropertyBlock();
                }

                block.SetColor("_BaseColor", materialColor);

                r.SetPropertyBlock(block);
            }
        }
    }
}