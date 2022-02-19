using UnityEngine;

namespace MissileCommand
{
    public class AllyRocket : RocketBehaviour
    {
        private new Rigidbody rigidbody;
        private Vector3 startPosition;
        private float distanceToFly = 1000;

        private void Awake()
        {
            GetRigidbody();
        }
        private void Update()
        {
            if (Vector3.Distance(transform.position, startPosition) >= distanceToFly)
                MakeBoom();
        }

        /// <summary>
        /// Shoot rocket in z direction of rocket and make boom at the end position
        /// </summary>
        public override void Shoot(GameObject rocketPrefab, Vector3 startPosition,Quaternion startRotation,
            Vector3 endPosition, float speed, Transform newParent)
        {
            var spawnerRocket = Instantiate(rocketPrefab, startPosition, startRotation,newParent);

            spawnerRocket.GetComponent<AllyRocket>().SetPlaceOfBoomAndShoot(startPosition,endPosition,speed);
        }

        void SetPlaceOfBoomAndShoot(Vector3 startPosition,Vector3 endPosition, float speed)
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