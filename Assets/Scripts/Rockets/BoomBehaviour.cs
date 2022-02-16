using UnityEngine;
using System.Linq;

namespace MissileCommand
{
    public class BoomBehaviour : MonoBehaviour
    {
        [SerializeField] private float startBoomSize = 0.75f;
        [SerializeField] private float endBoomSize = 2.25f;
        [SerializeField] private float timeFormStartSizeToMax = 1f;

        private float diffreceBerweenStartSizeAndEnd;
        private bool IsEndSizeReached = false;
        private Vector3 diffreceBerweenStartSizeAndEndVector3;

        #region MonoBehaviour

        private void Start()
        {
            SetStartValues();
        }

        private void Update()
        {
            Explosion();
        }

        private void OnTriggerEnter(Collider other)
        {
            ActivateOnBoomEfectInTriggeredObjectWithIDamagedByBoom(other);
        }

        #endregion MonoBehaviour

        void ActivateOnBoomEfectInTriggeredObjectWithIDamagedByBoom(Collider other)
        {
            var BoomableComponent = other.GetComponents<MonoBehaviour>().OfType<IDamagedByBoom>();
            if (BoomableComponent != null)
            {
                foreach (var item in BoomableComponent)
                {
                    item.OnBoomTriggerEnter();
                }
            }
        }

        void SetStartValues()
        {
            diffreceBerweenStartSizeAndEnd = endBoomSize - startBoomSize;

            diffreceBerweenStartSizeAndEndVector3 = new Vector3(diffreceBerweenStartSizeAndEnd,
                    diffreceBerweenStartSizeAndEnd, diffreceBerweenStartSizeAndEnd);

            transform.localScale = new Vector3(startBoomSize, startBoomSize, startBoomSize);
        }

        void Explosion()
        {

            ///Increase Sacle
            if (!IsEndSizeReached)
            {
                transform.localScale += diffreceBerweenStartSizeAndEndVector3 *
                    Time.deltaTime / timeFormStartSizeToMax;

                if (transform.localScale.x > endBoomSize)
                    IsEndSizeReached = true;

                return;
            }

            ///Decrease Sacle
            if (IsEndSizeReached)
            {
                transform.localScale -= diffreceBerweenStartSizeAndEndVector3 *
                    Time.deltaTime / timeFormStartSizeToMax;

                if (transform.localScale.x < 0.1)
                    Destroy(this.gameObject);

                return;
            }
        }    
    }
}