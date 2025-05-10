using System.Collections;
using System.Collections.Generic;
using Opsive.BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using Opsive.Shared.Events;

namespace BPChaseNPC
{
    public class NPCReceiveDamage : MonoBehaviour
    {
        protected BehaviorTree _behaviorTree;
        // Start is called before the first frame update
        protected void Start()
        {
            _behaviorTree = this.GetComponentInParent<BehaviorTree>();
        }

        public string TAG_DAMAGE_OBJECT = "DamageObject";

        protected void OnTriggerEnter(Collider other)
        {
            //guard clauses
            if (other.tag != TAG_DAMAGE_OBJECT) return;

            EventHandler.ExecuteEvent<object>(_behaviorTree, "onReceivedDamage", other);
        }
    }
}