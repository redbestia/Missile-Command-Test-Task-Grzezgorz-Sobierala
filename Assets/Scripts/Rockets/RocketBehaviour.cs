using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public abstract class RocketBehaviour : MonoBehaviour
    {
        [SerializeField] GameObject boomPrefab;
        protected void MakeBoom()
        {
            Instantiate(boomPrefab, transform.position, boomPrefab.transform.rotation);
            Destroy(this.gameObject);
        }

        public abstract void Shoot(GameObject rocketPrefab, Vector3 startPosition, Quaternion startRotation,
            Vector3 endPosition, float speed, Transform newParent);
    }
}