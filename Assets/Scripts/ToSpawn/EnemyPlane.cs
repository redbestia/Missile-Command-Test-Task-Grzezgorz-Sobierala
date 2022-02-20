using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class EnemyPlane : Enemy , IDamagedByBoom
    {
        [SerializeField] EnemySpawner spawnerInPlane;

        private Vector3 startPosition;
        private float distanceToFly = 1000;

         protected override void Awake()
        {
            base.Awake();
            spawnerInPlane.SetTargetArea(MainTargetAreaInScene.MainTargetAreaStatic);
            spawnerInPlane.SetEnemyParent(MainRocketParentInScene.MainRocketParentStatic);
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, startPosition) >= distanceToFly)
                MakeBoom();
        }

        public void OnBoomTriggerEnter()
        {
            ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Remove(spawnerInPlane);
            EnemySpawner.OnSpawnerOutOfAmmo.Invoke(
                ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Count);

            MakeBoom();
        }

        public override void LaunchInDirection(Vector3 startPosition, Vector3 endPosition, float speed)
        {
            distanceToFly = Vector3.Distance(startPosition, endPosition);
            
            this.startPosition = startPosition;

            rigidbody.AddRelativeForce(Vector3.forward * speed);
        }

       
    }
}