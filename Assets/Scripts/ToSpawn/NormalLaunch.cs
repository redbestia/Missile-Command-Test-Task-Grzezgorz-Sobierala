using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    [CreateAssetMenu(fileName = "LaunchableGameObjectStrategy",menuName = "Normal Launch",order = 0)]
    public class NormalLaunch : LaunchableGameObjectStrategy
    {
        /// <summary>
        /// Launch in startPosition to endPosition
        /// </summary>
        public override void Launch(Vector3 startPosition, Quaternion startRotation, 
            Vector3 endPosition, float speed, Transform newParent)
        {
            if(gameObjectToLunch.GetComponent<LaunchableGameObject>() == null)
            {
                Debug.LogError("This Game Object dont have LanchableGameObject Component");
                return;
            }

            var spawnerRocket = Instantiate(gameObjectToLunch, startPosition, startRotation, newParent);

            spawnerRocket.GetComponent<LaunchableGameObject>().LaunchInDirection(startPosition, 
                endPosition, speed);
        }
    }
}