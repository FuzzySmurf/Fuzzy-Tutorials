using System.Collections;
using System.Collections.Generic;
using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.GraphDesigner.Runtime.Variables;
using UnityEngine;

namespace TutorialWander
{
    public class NPCWander : EnemyAction
    {
        public SharedVariable<float> radius = 5.0f;
        [Tooltip("have we reached the destination?")]
        public SharedVariable<bool> hasReachedDestination;
        [Tooltip("Can we get a new destination?")]
        public SharedVariable<bool> canGetNewDestination;
        protected Vector3 _startingPoint;

        public Vector3 destination;

        public override void OnAwake()
        {
            _startingPoint = this.transform.position;
            base.OnAwake();
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public override TaskStatus OnUpdate()
        {
            //Determine Destination for Unit.
            DetermineDestinationPoint();

            //Check if we are within range, and mark True.
            CheckWithinRange();

            return base.OnUpdate();
        }

        private void CheckWithinRange()
        {
            //if we already reached the destination, no need to continue.
            if (hasReachedDestination.Value) return;
            //if we already have a destination, no need to check.
            if (canGetNewDestination.Value) return;
            
            //do a distance check between US and the destination.
            float dist = Vector3.Distance(transform.position, destination);
            if (dist < 0.5f)
            {
                hasReachedDestination.Value = true;
            }
        }

        protected override void OnDrawGizmos() {
            base.OnDrawGizmos();
            DrawAreaWandering();
        }

        private void DrawAreaWandering()
        {
            using (new UnityEditor.Handles.DrawingScope(Matrix4x4.TRS(_startingPoint, Quaternion.identity, Vector3.one)))
            {
                UnityEditor.Handles.color = Color.cyan;
                UnityEditor.Handles.DrawWireArc(Vector3.zero, Vector3.up, Vector3.forward, 360, radius.Value);
            }
        }

        private void DetermineDestinationPoint()
        {
            //if not assigned.
            if (destination == Vector3.zero || canGetNewDestination.Value)
            {
                //find next destination.
                destination = GetRandomPointInSphere();

                //set assignment to NPC.
                _agent.SetDestination(destination);

                //we got destination, set back to false.
                canGetNewDestination.Value = false;
            }
        }

        private Vector3 GetRandomPointInSphere()
        {
            //generate a random point within a unit sphere.
            Vector3 generatedDest = Random.insideUnitSphere * radius.Value;

            //adjust the Y Value.
            float adjY = _startingPoint.y + 0.01f;

            //Get newDestination.
            Vector3 desiredDestination = new Vector3(generatedDest.x + _startingPoint.x, adjY, generatedDest.z + _startingPoint.z);

            //return newDestination
            return desiredDestination;
        }
    }
}