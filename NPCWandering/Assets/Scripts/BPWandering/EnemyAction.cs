using System.Collections;
using System.Collections.Generic;
using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using UnityEngine;
using UnityEngine.AI;

namespace BPWandering
{
    public class EnemyAction : Action
    {
        protected NavMeshAgent _agent;
        public override void OnStart()
        {
            _agent = this.gameObject.GetComponentInParent<NavMeshAgent>();
            base.OnStart();
        }
    }
}