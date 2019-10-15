using GameLogic.GroupHandling.Individual;
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
    abstract class Group : MonoBehaviour
    {
        protected string actType;

        public int ModelCount => actors.Count;

        public virtual Color32 MaterialColor
        {
            get; set;
        }

        //for a lot of models, hashset will be faster, also guarantees no duplication
        protected HashSet<Actor> actors;

        public HashSet<Actor> Actors
        {
            get
            {
                return actors;
            }
        }

        [SerializeField] private Actor leader;

        public Actor Leader
        {
            get
            {
                return leader;
            }
            set
            {
                leader = value;
                leader.ChangeColor(MaterialColor);
                SetLeaderState();
            }
        }

        public virtual float Speed => 5f;

        private void SetLeaderState()
        {
            leader.GetComponent<Rigidbody>().isKinematic = true;
            leader.State = ActorState.Leader;
            leader.Leader = leader;
            leader.GetComponent<CharacterController>().radius = 0f;
        }

        protected MovementController movement;

        protected Transform Parent { get; set; }

        public bool Eliminated { get; internal set; }

        protected virtual void Awake()
        {
            Parent = new GameObject("parent").transform;
            Parent.SetParent(this.transform, false);
            Initialize();
        }

        public void SetMovementController(MovementController movement)
        {
            this.movement = movement;
        }

        public virtual void Initialize()
        {
            actType = "Character";
            actors = new HashSet<Actor>();
        }

        public void AddActor()
        {
            AddActor(actType);
        }

        public void AddActor(string type)
        {
            Actor act = ModelLoader.LoadModel<Actor>(type);
            AddActor(act);
        }

        public void AddActor(Actor act)
        {
            actors.Add(act);
            act.SetParent(Parent, true);
            act.ChangeColor(MaterialColor);
            act.Leader = this.Leader;
            act.GetComponent<Rigidbody>().isKinematic = false;
        }

        public void RemoveActor(Actor act)
        {
            actors.Remove(act);
        }

        public virtual void Move()
        {
            foreach (Actor act in actors)
            {
                Vector2 dir = movement.GetCurrentDirection(act);
                act.Move(dir);
                act.Rotate(dir);
            }
        }

        internal void ChangeToRandomLeader()
        {
            if (ModelCount > 0)
            {
                Leader = actors.FirstOrDefault();
            }
        }
    }
}
