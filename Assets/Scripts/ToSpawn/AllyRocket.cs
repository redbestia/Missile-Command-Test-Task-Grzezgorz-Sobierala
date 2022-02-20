using UnityEngine;

namespace MissileCommand
{
    public class AllyRocket : LaunchableGameObject
    {
        private Vector3 startPosition;
        private float distanceToFly = 1000;

        private void Update()
        {
            if (Vector3.Distance(transform.position, startPosition) >= distanceToFly)
                MakeBoom();
        }

        public override void LaunchInDirection(Vector3 startPosition,Vector3 endPosition, float speed)
        {
            distanceToFly = Vector3.Distance(startPosition, endPosition);
            this.startPosition = startPosition;

            rigidbody.AddRelativeForce(Vector3.forward * speed);
        }
    }
}