using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class TurretBehaviour : MonoBehaviour, IDamagedByBoom
    {
        [SerializeField] int strartAmmo = 15;

        [HideInInspector] public int CurrentAmmo { get => currentAmmo; }
        private int currentAmmo = 0;

        public Action<TurretBehaviour> OnTurretCantShoot = delegate { };

        public Action<int> OnTurretShoot = delegate { };


        private void Awake()
        {
            currentAmmo = strartAmmo;    
        }

        public void OnBoomTriggerEnter()
        {
            OnTurretCantShoot.Invoke(this);
            Destroy(this.gameObject);
        }

        public void SubtractOneAmmo()
        {
            if(currentAmmo <= 1)
            {
                OnTurretCantShoot.Invoke(this);
                currentAmmo = 0;
                OnTurretShoot.Invoke(currentAmmo);
                return;
            }

            currentAmmo--;
            OnTurretShoot.Invoke(currentAmmo);
        }
    }
}