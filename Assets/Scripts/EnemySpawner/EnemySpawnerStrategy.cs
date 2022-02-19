using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawnerStrategy : ScriptableObject
{
    [SerializeField] GameObject gameObjectToSpawn;

    public abstract void SpawnEnemy(Vector3 startPosition, Quaternion startRotation,
            Vector3 endPosition, float speed, Transform newParent);

}
