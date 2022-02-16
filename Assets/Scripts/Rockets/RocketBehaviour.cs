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
    }
}