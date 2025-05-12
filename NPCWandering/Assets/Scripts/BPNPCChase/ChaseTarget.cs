using System.Collections;
using System.Collections.Generic;
using BPWandering;
using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using Opsive.GraphDesigner.Runtime.Variables;
using UnityEngine;

namespace BPNPCChase
{
    public class ChaseTarget : EnemyAction
    {
        [Tooltip("The targetObject we are chasing.")]
        public SharedVariable<GameObject> targetObject;
        public float stoppingDistance;
        [Tooltip("How far should we be before the leash breaks?")]
        public SharedVariable<float> leashDistance = 12;

        [Tooltip("Should we reset the Wander Values?")]
        public SharedVariable<bool> resetWander = false;

        private GameObject _parentRef;

        public override void OnAwake()
        {
            base.OnAwake();
            _parentRef = this.transform.parent.gameObject;
        }
        public override void OnStart()
        {
            base.OnStart();
        }
        
        public override TaskStatus OnUpdate()
        {
            if (targetObject.Value == null) return TaskStatus.Failure;

            //Chase the given target.
            ChaseTargetObject();

            //Check if we are still in Leash Range.
            if(IsWithinLeashDistance()) return TaskStatus.Success;

            ResetVariables();
            return TaskStatus.Failure;
        }

        protected override void OnDrawGizmos() {
            base.OnDrawGizmos();
            DrawAreaWandering();
        }

        private void DrawAreaWandering()
        {
            //prevent an editor error.
            if (_parentRef == null) return;

            using (new UnityEditor.Handles.DrawingScope(Matrix4x4.TRS(_parentRef.transform.position, Quaternion.identity, Vector3.one)))
            {
                UnityEditor.Handles.color = Color.red;
                UnityEditor.Handles.DrawSolidArc(Vector3.zero, Vector3.up, Vector3.forward, 360, leashDistance.Value);
            }
        }

        private bool IsWithinLeashDistance() {
            float dist = Vector3.Distance(_parentRef.transform.position, targetObject.Value.transform.position);
            if (dist < leashDistance.Value) return true;

            return false;
        }

        private void ResetVariables() {
            targetObject.Value = null;
            resetWander.Value = true;
        }

        private void ChaseTargetObject() {
            _agent.SetDestination(DetermineStoppingDestination(targetObject.Value, stoppingDistance));
        }

        protected Vector3 DetermineStoppingDestination(GameObject targetCharacter, float stopDistance) {
            //find the distance between enemy and player. (player pos = this.pos);
            Vector3 parentPosition = _parentRef.transform.position;
            Vector3 difference = targetCharacter.transform.position - parentPosition;
            //Normalize it. (should get the direction)
            Vector3 direction = difference.normalized;
            float currentDistance = difference.magnitude;

            //are we still Far enough from the target??
            if (currentDistance > stopDistance)
            {
                float moveDistance = currentDistance - stopDistance;
                Vector3 targetPosition = parentPosition + direction * moveDistance;
                return targetPosition;
            }
            //if we're still far, just return 'our' position.
            return parentPosition;
        }
    }
}