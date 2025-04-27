using System;
using System.Collections;
using System.Collections.Generic;
using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.GraphDesigner.Runtime.Variables;
using TutorialWander;
using UnityEngine;

namespace TutorialWander
{
    public class IdleAtDestination : EnemyAction
    {
        //will hold control of the current time.
        private float _curWaitTime;
        [Tooltip("How long should we idle for?")]
        public SharedVariable<float> maxWaitTime;

        [Tooltip("have we reached the destination?")]
        public SharedVariable<bool> hasReachedDestination;

        public SharedVariable<bool> resetWander;

        public override void OnStart()
        {
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            if(hasReachedDestination == null || !hasReachedDestination.Value) return TaskStatus.Failure;
            //we have reached the destination. set true.
            hasReachedDestination.Value = true;

            //Idle NPC for X Time.
            bool isIdling = IsNPCIdling();
            if (isIdling) return TaskStatus.Running;

            //no longer idling, resetVariables.
            resetWander.Value = true;

            return base.OnUpdate();
        }

        private bool IsNPCIdling()
        {
            if (_curWaitTime < maxWaitTime.Value) {
                _curWaitTime += Time.deltaTime;
                return true;
            }

            //reset waitTime. should no longer be idling.
            _curWaitTime = 0;
            return false;
        }
    }
}