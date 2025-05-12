using System.Runtime.CompilerServices;
using UnityEngine;

namespace BPNPCChase
{
    public class ProjectileShooter : MonoBehaviour {
        public GameObject projectilePrefab;

        public float fireDistanceFromCharacter = 1.5f;

        public float projectileSpeed = 15.0f;

        /// <summary>
        /// Set this to the ground or what you want the ray to hit.
        /// </summary>
        public LayerMask aimLayerMask;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireProjectileAtMouseDown();
            }
        }

        private void FireProjectileAtMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, aimLayerMask))
            {
                Vector3 targetPos = hitInfo.point;

                // Get direction to target
                Vector3 direction = (targetPos - transform.position).normalized;

                // Spawn point in front of character
                Vector3 spawnPos = transform.position + direction * fireDistanceFromCharacter;

                // Spawn and aim projectile
                GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.LookRotation(direction));
                AddBulletInfo(projectile);

                // Launch the projectile
                if (projectile.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.linearVelocity = direction * projectileSpeed;
                }
            }
        }

        private void AddBulletInfo(GameObject go)
        {
            var bInfo = go.AddComponent<BulletInfo>();

            bInfo.sender = this.transform.parent.gameObject;
        }
    }   
}