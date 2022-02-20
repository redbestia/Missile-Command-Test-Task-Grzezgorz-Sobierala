using UnityEngine;
using System.Collections.Generic;

namespace MissileCommand
{
    public class EnemyRocket : LaunchableGameObject 
    {
        [SerializeField] List<string> listOfTagsThatMakesTheRocketBoom;

        private void OnTriggerEnter(Collider other)
        {
            if(IsColliderDestroyRocket(other))
            {
                MakeBoom();
            }
        }

        public override void LaunchInDirection(Vector3 startPosition, Vector3 endPosition, float speed)
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