using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class HouseBehaviour : MonoBehaviour, IDamagedByBoom
    {
        public static List<HouseBehaviour> ListOfHouseBehaviour = new List<HouseBehaviour>();
        public static Action<int> OnHouseBombed = delegate { };

        private void Awake()
        {
            ListOfHouseBehaviour.Add(this);
        }

        private void OnDestroy()
        {
            ListOfHouseBehaviour.RemoveAt(ListOfHouseBehaviour.IndexOf(this));
        }

        public void OnBoomTriggerEnter()
        {
            OnHouseBombed.Invoke(ListOfHouseBehaviour.Count);
            Destroy(gameObject);
        }

    }
}