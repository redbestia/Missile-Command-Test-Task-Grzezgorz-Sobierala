using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public static class ListsOfLeftEnemies
    {
        public static List<LaunchableGameObject> ListOfLeftEnemies = new List<LaunchableGameObject>();
        public static List<EnemySpawner> ListOfLeftEnemySpawners = new List<EnemySpawner>();
    }
}