using UnityEngine;

namespace MissileCommand
{
    public class PlayerInputSingleton : MonoBehaviour
    {
        [SerializeField] private LayerMask cursorCatcher;
        [SerializeField] private KeyCode ShootButton = KeyCode.Space;
 
        public Vector3 CursorPositionInWorld { get => cursorPositionInWorld; }
        private Vector3 cursorPositionInWorld = Vector3.zero;

        public bool IsShootButtonPressed { get => isShootButtonPressed; }
        private bool isShootButtonPressed = false;

        public static PlayerInputSingleton Instance { get => instance; }
        private static PlayerInputSingleton instance;

        #region MonoBehaviour
        private void Awake()
        {
            SetThisInstanceToStaticIfInstaneIsNull();
        }

        private void Update()
        {
            cursorPositionInWorld = GetCursorPosition();

            isShootButtonPressed = Input.GetKeyDown(ShootButton);
        }

        #endregion

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