using UnityEngine;
using System.Collections.Generic;
using System;

namespace MissileCommand
{
    public class TurretShootController : MonoBehaviour
    {
        [SerializeField] private List<TurretBehaviour> listOfTurrets;
        [SerializeField] private LaunchableGameObjectStrategy launchableGameObjectStrategy;

        [SerializeField] private Transform allyRocketParent;
        [SerializeField] private float rocketSpeed = 100;

        public Action OnNoTurretsAbleToShootLeft = delegate { };

        #region MonoBehaviour

        private void Start()
        {
            ObserveTurrets();
        }
        private void Update()
        {
            if(PlayerInputSingleton.Instance.IsShootButtonPressed)
            {
                ShootToCursor();
            }
        }

        #endregion

        void ShootToCursor()
        {
            if(listOfTurrets.Count == 0)
            {
                OnNoTurretsAbleToShootLeft.Invoke();
                return;
            }

            float shortestDistance = float.MaxValue;
            TurretBehaviour nearestTurretToCursor = listOfTurrets[0] ;

            ///Find turret closest to cursor
            foreach (var turret in listOfTurrets)
            {
                float currentDistance = Vector3.Distance(turret.transform.position, 
                    PlayerInputSingleton.Instance.CursorPositionInWorld);

                if(currentDistance<shortestDistance)
                {
                    shortestDistance = currentDistance;
                    nearestTurretToCursor = turret;
                }
            }

            nearestTurretToCursor.transform.LookAt(PlayerInputSingleton.Instance.CursorPositionInWorld,
                Vector3.left);

            launchableGameObjectStrategy.Launch(nearestTurretToCursor.transform.position,
                nearestTurretToCursor.transform.rotation, PlayerInputSingleton.Instance.CursorPositionInWorld, 
                rocketSpeed, allyRocketParent);

            nearestTurretToCursor.SubtractOneAmmo();
        }

        void ObserveTurrets()
        {
            foreach (var turret in listOfTurrets)
            {
                turret.OnTurretCantShoot += DeleteTurretFromList;
            }
        }

        void DeleteTurretFromList(TurretBehaviour turetToDelete)
        {
            for (int i = 0; i < listOfTurrets.Count; i++)
            {
                if (listOfTurrets[i] == turetToDelete)
                {
                    listOfTurrets.RemoveAt(i);
                    turetToDelete.OnTurretCantShoot -= DeleteTurretFromList;
                }
            }
        }

    }
}