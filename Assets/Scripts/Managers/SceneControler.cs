using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileCommand
{
    public class SceneControler : MonoBehaviour
    {
        [SerializeField] private GameObject AimSystem;
        [SerializeField] private GameObject WinUI;
        [SerializeField] private GameObject LoseUI;

        private int enemyiesLeft;
        private int enemySpawnersLeft;
        private bool isLose = false;
        private void Awake()
        {
        }
        private void Start()
        {
            FreezeTime();

            Observ();

            enemyiesLeft = 10;
            enemySpawnersLeft = ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Count;
        }


        private void OnDestroy()
        {
            StopObserv();
            ClearAllStaticLists();
        }

        public void RestartScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        public void FreezeTime()
        {
            Time.timeScale = 0;
        }

        public void UnfreezeTime()
        {
            Time.timeScale = 1;
        }

        void CheckIsLose(int countOfHouses)
        {
            if (countOfHouses == 0)
            {
                isLose = true;
                AimSystem.SetActive(false);
                LoseUI.SetActive(true);

                FreezeTime();
                StopObserv();
            }
        }

        #region WinChecker
        void Win()
        {
            AimSystem.SetActive(false);
            WinUI.SetActive(true);
            FreezeTime();
            StopObserv();
        }

        void CheckHowMuchEnemiesLeft(int enemies)
        {
            enemyiesLeft = enemies;
            if (IsWin())
                StartCoroutine(WaitForBoomToEndThenWin());
        }

        void CheckHowMuchEnemySpwanersleft(int enemySpawnres)
        {
            enemySpawnersLeft = enemySpawnres;
            if (IsWin())
                StartCoroutine(WaitForBoomToEndThenWin());
        }

        bool IsWin()
        {
            if (enemyiesLeft == 0 && enemySpawnersLeft == 0)
                return true;

            return false;
        }

        IEnumerator WaitForBoomToEndThenWin()
        {
            yield return new WaitForSecondsRealtime(3);
            if (!isLose)
            {
                Win();
            }
        }
        #endregion

        void Observ()
        {
            HouseBehaviour.OnHouseBombed += CheckIsLose;
            Enemy.OnEnemyDestroyed += CheckHowMuchEnemiesLeft;
            EnemySpawner.OnSpawnerOutOfAmmo += CheckHowMuchEnemySpwanersleft;
        }

        void StopObserv()
        {
            HouseBehaviour.OnHouseBombed -= CheckIsLose;
            Enemy.OnEnemyDestroyed -= CheckHowMuchEnemiesLeft;
            EnemySpawner.OnSpawnerOutOfAmmo -= CheckHowMuchEnemySpwanersleft;
        }
        void ClearAllStaticLists()
        {
            ListsOfLeftEnemies.ListOfLeftEnemies.Clear();
            ListsOfLeftEnemies.ListOfLeftEnemySpawnersWithAmmo.Clear();
            HouseBehaviour.ListOfHouseBehaviour.Clear();
        }

    }
}