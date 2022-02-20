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
        public void OnBoomTriggerEnter()
        {
            ListOfHouseBehaviour.Remove(this);
            OnHouseBombed.Invoke(ListOfHouseBehaviour.Count);

            Destroy(gameObject);
        }

    }
}