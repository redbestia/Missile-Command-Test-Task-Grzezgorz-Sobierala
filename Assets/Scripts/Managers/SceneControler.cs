using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class SceneControler : MonoBehaviour
    {
        [SerializeField] private GameObject DefenceSystem;
        [SerializeField] private GameObject WinUI;
        [SerializeField] private GameObject LoseUI;
        private void Start()
        {
            FreezeTime();

            HouseBehaviour.OnHouseBombed += CheckIsThereAnyHouseRemain;
        }

        private void OnDestroy()
        {
            HouseBehaviour.OnHouseBombed -= CheckIsThereAnyHouseRemain;
        }
        public void FreezeTime()
        {
            DefenceSystem.SetActive(false);
            Time.timeScale = 0;
        }

        public void UnfreezeTime()
        {
            DefenceSystem.SetActive(true);
            Time.timeScale = 1;
        }

        public void CheckIsThereAnyHouseRemain(int countOfHouses)
        {
            if (countOfHouses == 0)
            {
                FreezeTime();
                WinUI.SetActive(true);
            }
        }
    }
}