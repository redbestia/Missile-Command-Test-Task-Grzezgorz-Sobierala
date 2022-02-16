using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class PlayerInputSingleton : MonoBehaviour
    {
        [SerializeField] private LayerMask cursorCatcher;

        [HideInInspector] public Vector3 CursorPositionInWorld { get => cursorPositionInWorld;  }
        private Vector3 cursorPositionInWorld;

        public static PlayerInputSingleton Instance { get => instance;  }
        private static PlayerInputSingleton instance;

        private void Awake()
        {
            SetThisInstanceToStaticIfInstaneIsNull();
        }

        private void Update()
        {
            cursorPositionInWorld = GetCursorPosition();
        }
        private void SetThisInstanceToStaticIfInstaneIsNull()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        Vector3 GetCursorPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, cursorCatcher);
            return hit.point;
        }
    }
}