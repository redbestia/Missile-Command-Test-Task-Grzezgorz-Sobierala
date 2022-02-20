using UnityEngine;

namespace MissileCommand
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] LaunchableGameObjectStrategy launchableGameObjectStrategy;

        [SerializeField] Transform enemyParent;

        [SerializeField] Transform spawnArea;
        [SerializeField] Transform targetArea;

        [SerializeField] int amountOfLaunches = 10;
        [SerializeField] float speed = 300;
        [SerializeField] float maxTimeBeetwenLaunches = 0.5f;
        [SerializeField] float minTimeBeetwenLaunches = 0.2f;

        public static System.Action<int> OnSpawnerOutOfAmmo = delegate { };

        private float timeOfNextLaunch=0;

        private void Awake()
        {
            ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Add(this);
        }

        private void Update()
        {
            LauchingUntillHaveAmmo();
        }

        private void OnDestroy()
        {
            //ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Remove(this);
            //OnSpawnerOutOfAmmo.Invoke(ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Count);
        }

        public void SetTargetArea(Transform newTargetArea)
        {
            targetArea = newTargetArea;
        }
        
        public void SetEnemyParent(Transform newEnemyParent)
        {
            enemyParent = newEnemyParent;
        }

        void LauchingUntillHaveAmmo()
        {
            if (timeOfNextLaunch <= Time.time && amountOfLaunches > 0)
            {
                LaunchToRandomPlaceInTarget();
                timeOfNextLaunch = Time.time + Random.Range(minTimeBeetwenLaunches, maxTimeBeetwenLaunches);
            }
        }

        void LaunchToRandomPlaceInTarget()
        {
            var spawnPositionX = Random.Range(LeftMaxSpawnPointX(), RightMaxSpawnPointX());
            var spawnPositionY = Random.Range(DownMaxSpawnPointY(), TopMaxSpawnPointY());
            var targetPositionX = Random.Range(LeftMaxTargetPointX(), RightMaxTargetPointX());
            var targetPositionY = Random.Range(DownMaxTargetPointY(), TopMaxTargetPointY());

            Vector3 spawnPosition = new Vector3(spawnPositionX,
                spawnPositionY, spawnArea.position.z);

            Vector3 targetPosition = new Vector3(targetPositionX,
                targetPositionY, targetArea.position.z);

            Vector3 spawnToTargetVector = targetPosition - spawnPosition;

            Quaternion startRotation = Quaternion.LookRotation(spawnToTargetVector);

            launchableGameObjectStrategy.Launch(spawnPosition, 
                startRotation, targetPosition, speed, enemyParent);

            amountOfLaunches--;
            if (amountOfLaunches == 0)
            {
                ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Remove(this);
                OnSpawnerOutOfAmmo.Invoke(ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Count);
            }
        }

        #region SpawnAndTargetPoints
        float LeftMaxSpawnPointX()
        {
            return spawnArea.position.x - (spawnArea.localScale.x / 2);
        }
        float RightMaxSpawnPointX()
        {
            return spawnArea.position.x + (spawnArea.localScale.x / 2);
        }
        float LeftMaxTargetPointX()
        {
            return targetArea.position.x - (targetArea.localScale.x / 2);
        }
        float RightMaxTargetPointX()
        {
            return targetArea.position.x + (targetArea.localScale.x / 2);
        }
        float DownMaxSpawnPointY()
        {
            return spawnArea.position.y - (spawnArea.localScale.y / 2);
        }
        float TopMaxSpawnPointY()
        {
            return spawnArea.position.y + (spawnArea.localScale.y / 2);
        }
        float DownMaxTargetPointY()
        {
            return targetArea.position.y - (targetArea.localScale.y / 2);
        }
        float TopMaxTargetPointY()
        {
            return targetArea.position.y + (targetArea.localScale.y / 2);
        }
        #endregion


    }
}