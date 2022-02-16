using UnityEngine;
using System.Collections.Generic;

namespace MissileCommand
{
    public class TurretShootController : MonoBehaviour
    {
        [SerializeField] private List<Transform> ListOfTurrets;
        [SerializeField] private GameObject rocketPrefab;
        [SerializeField] private float rocketSpeed = 100;
        #region MonoBehaviour

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
            float shortestDistance = float.MaxValue;
            Transform nearestTurretToCursor = ListOfTurrets[0] ;

            foreach (var turret in ListOfTurrets)
            {
                float currentDistance = Vector3.Distance(turret.position, 
                    PlayerInputSingleton.Instance.CursorPositionInWorld);

                if(currentDistance<shortestDistance)
                {
                    shortestDistance = currentDistance;
                    nearestTurretToCursor = turret;
                }
            }

            nearestTurretToCursor.transform.LookAt(PlayerInputSingleton.Instance.CursorPositionInWorld,
                Vector3.left);

            var spawnedRocket = Instantiate(rocketPrefab, nearestTurretToCursor.position, 
                nearestTurretToCursor.rotation);

            spawnedRocket.GetComponent<AllyRocket>().Shoot(nearestTurretToCursor.position,
                nearestTurretToCursor.rotation, PlayerInputSingleton.Instance.CursorPositionInWorld, rocketSpeed);

        }
    }
}