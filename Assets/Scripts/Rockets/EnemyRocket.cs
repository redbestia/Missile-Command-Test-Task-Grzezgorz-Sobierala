using UnityEngine;
using System.Collections.Generic;

namespace MissileCommand
{
    public class EnemyRocket : RocketBehaviour 
    {
        [SerializeField] List<string> listOfTagsThatMakesTheRocketBoom;

        private new Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(IsColliderDestroyRocket(other))
            {
                MakeBoom();
            }
        }

        /// <summary>
        /// Shoot rocket in z direction of rocket
        /// </summary>
        public override void Shoot(GameObject rocketPrefab, Vector3 startPosition, Quaternion startRotation,
            Vector3 endPosition, float speed, Transform newParent)
        {
            var spawnerRocket = Instantiate(rocketPrefab, startPosition, startRotation, newParent);

            spawnerRocket.GetComponent<EnemyRocket>().SetPlaceOfBoomAndShoot(speed);
        }

        void SetPlaceOfBoomAndShoot(float speed)
        {
            rigidbody.AddRelativeForce(Vector3.forward * speed);
        }

        bool IsColliderDestroyRocket(Collider other)
        {
            foreach (var tag in listOfTagsThatMakesTheRocketBoom)
            {
                if (tag == other.tag)
                {
                    return true;
                }
            }
            return false;
        }
    }
}