using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class TurretShootController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 1;
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Rotate(new Vector3(0, 0, rotationSpeed));
            }
        }
    }
}