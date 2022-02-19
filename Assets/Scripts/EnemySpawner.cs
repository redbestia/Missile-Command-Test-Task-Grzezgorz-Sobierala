using UnityEngine;

namespace MissileCommand
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject rocketPrefab;
        [SerializeField] Transform enemyRocketsParent;

        [SerializeField] Transform rocketSpawnArea;
        [SerializeField] Transform rocketTargetArea;

        [SerializeField] int amountOfRocketsToShoot = 10;
        [SerializeField] float rokcetSpeed = 300;
        [SerializeField] float maxTimeBeetwenShoots = 0.5f;
        [SerializeField] float minTimeBeetwenShoots = 0.2f;

        private float timeOfNextShoot=0;

        private void Start()
        {
            ShootToRandomPlaceInTarget();
        }
        private void Update()
        {
            Shooting();
        }

        void Shooting()
        {
            if (timeOfNextShoot <= Time.time && amountOfRocketsToShoot > 0)
            {
                ShootToRandomPlaceInTarget();
                timeOfNextShoot = Time.time + Random.Range(minTimeBeetwenShoots, maxTimeBeetwenShoots);
            }
        }


        void ShootToRandomPlaceInTarget()
        {
            var spawnPositionX = Random.Range(LeftMaxSpawnPointX(), RightMaxSpawnPointX());
            var spawnPositionY = Random.Range(DownMaxSpawnPointY(), TopMaxSpawnPointY());
            var targetPositionX = Random.Range(LeftMaxTargetPointX(), RightMaxTargetPointX());
            var targetPositionY = Random.Range(DownMaxTargetPointY(), TopMaxTargetPointY());

            Vector3 spawnPosition = new Vector3(spawnPositionX,
                spawnPositionY, rocketSpawnArea.position.z);

            Vector3 targetPosition = new Vector3(targetPositionX,
                targetPositionY, rocketTargetArea.position.z);

            Vector3 spawnToTargetVector = targetPosition - spawnPosition;

            Quaternion startRotation = Quaternion.LookRotation(spawnToTargetVector);
            
            rocketPrefab.GetComponent<EnemyRocket>().Shoot(rocketPrefab, spawnPosition, 
                startRotation, targetPosition, rokcetSpeed, enemyRocketsParent);

            amountOfRocketsToShoot--;
        }

        #region SpawnAndTargetPoints
        float LeftMaxSpawnPointX()
        {
            return rocketSpawnArea.position.x - (rocketSpawnArea.localScale.x / 2);
        }
        float RightMaxSpawnPointX()
        {
            return rocketSpawnArea.position.x + (rocketSpawnArea.localScale.x / 2);
        }
        float LeftMaxTargetPointX()
        {
            return rocketTargetArea.position.x - (rocketSpawnArea.localScale.x / 2);
        }
        float RightMaxTargetPointX()
        {
            return rocketTargetArea.position.x + (rocketSpawnArea.localScale.x / 2);
        }
        float DownMaxSpawnPointY()
        {
            return rocketSpawnArea.position.y - (rocketSpawnArea.localScale.y / 2);
        }
        float TopMaxSpawnPointY()
        {
            return rocketSpawnArea.position.y + (rocketSpawnArea.localScale.y / 2);
        }
        float DownMaxTargetPointY()
        {
            return rocketTargetArea.position.y - (rocketTargetArea.localScale.y / 2);
        }
        float TopMaxTargetPointY()
        {
            return rocketTargetArea.position.y + (rocketTargetArea.localScale.y / 2);
        }
        #endregion


    }
}