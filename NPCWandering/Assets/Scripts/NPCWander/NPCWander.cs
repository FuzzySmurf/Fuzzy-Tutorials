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

            return base.OnUpdate();
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
            if (destination == Vector3.zero)
            {
                //find next destination.
                destination = GetRandomPointInSphere();

                //set assignment to NPC.
                _agent.SetDestination(destination);
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