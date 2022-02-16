using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class AllyRocket : RocketBehaviour
    {
        private new Rigidbody rigidbody;
        private Vector3 startPosition;
        private float distanceToFly;

        private void Awake()
        {
            GetRigidbody();
        }
        private void Update()
        {
            if (Vector3.Distance(transform.position, startPosition) >= distanceToFly)
                MakeBoom();
        }

        public void Shoot(Vector3 startPosition, Quaternion startRotation, Vector3 endPosition, float speed)
        {
            distanceToFly = Vector3.Distance(startPosition, endPosition);
            this.startPosition = startPosition;

            rigidbody.AddRelativeForce(Vector3.forward * speed);
        }

        void GetRigidbody()
        {
            rigidbody = GetComponent<Rigidbody>();
            if (rigidbody == null)
            {
                Debug.LogError("This GameObject need Rigidbody to work");
            }
        }
    }
}