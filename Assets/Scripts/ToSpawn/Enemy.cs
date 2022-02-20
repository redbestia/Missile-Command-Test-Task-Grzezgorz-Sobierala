using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public abstract class Enemy : LaunchableGameObject
    {
        public static Action<int> OnEnemyDestroyed = delegate { };

        protected override void Awake()
        {
            base.Awake();
            ListsOfLeftEnemies.ListOfLeftEnemies.Add(this);
        }

        protected override void MakeBoom()
        {
            ListsOfLeftEnemies.ListOfLeftEnemies.Remove(this);
            OnEnemyDestroyed.Invoke(ListsOfLeftEnemies.ListOfLeftEnemies.Count);

            base.MakeBoom();
        }
    }
}