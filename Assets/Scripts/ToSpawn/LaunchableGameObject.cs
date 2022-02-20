using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public abstract class LaunchableGameObject : MonoBehaviour
    {
        [SerializeField] GameObject boomPrefab;
        protected new Rigidbody rigidbody;

        protected virtual void Awake()
        {
            GetRigidbody();
        }

        protected void MakeBoom()
        {
            Instantiate(boomPrefab, transform.position, boomPrefab.transform.rotation);
            Destroy(this.gameObject);
        }

        /// <summary>
        /// Launch in startPosition to endPosition
        /// </summary>
        public abstract void LaunchInDirection(Vector3 startPosition, Vector3 endPosition, float speed);

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