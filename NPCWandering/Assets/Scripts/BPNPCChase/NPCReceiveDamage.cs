using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using Opsive.BehaviorDesigner.Runtime;
using UnityEngine;
using Opsive.Shared.Events;

namespace BPNPCChase
{
    public class NPCReceiveDamage : MonoBehaviour
    {
        protected BehaviorTree _behaviorTree;
        // Start is called before the first frame update
        protected void Start()
        {
            var parent = this.transform.parent;
            _behaviorTree = parent.GetComponentInChildren<BehaviorTree>();
        }

        protected void OnTriggerEnter(Collider other)
        {
            //guard clauses
            if (other.tag != Constants.TAG_DAMAGE_OBJECT) return;

            //get bullet info. and send that.
            var bInfo = other.gameObject.GetComponent<BulletInfo>();

            if (bInfo == null)
            {
                Debug.LogError("Bullet Info is missing! something wrong!");
                return;
            }

            //send bulletInfo
            EventHandler.ExecuteEvent<object>(_behaviorTree, "onReceivedDamage", bInfo.sender);

            //get rid of the object, we're no longer using it.
            Destroy(other.gameObject);
        }
    }
}