using System.Collections;
using System.Collections.Generic;
using BPWandering;
using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.GraphDesigner.Runtime.Variables;
using UnityEngine;

namespace BPChaseNPC
{
    public class NPCResetValues : EnemyAction
    {
        public SharedVariable<bool> resetWander;
        public SharedVariable<GameObject> targetObject;

        public SharedVariable<bool> hasLeashBroken = false;

        public override void OnStart()
        {
        }

        public override TaskStatus OnUpdate()
        {
            if(!hasLeashBroken.Value) return TaskStatus.Success;
            
            resetVariables();
            return TaskStatus.Failure;
        }

        private void resetVariables() {
            resetWander.Value = true;
            targetObject.Value = null;
        }
    }
}