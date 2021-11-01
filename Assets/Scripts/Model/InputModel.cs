using UnityEngine;

namespace Asteroids
{
    public class InputModel : MonoBehaviour, IInputModel
    {
        private Camera _camera;
        public Vector3 AimTarget  => GetAimTarget();
        public float HorizontalSpeed => GetHorizontalSpeed();
        public float VerticalSpeed => GetVerticalSpeed();
        public bool IsAccelerating => CheckAcceleration();
        public bool IsFiring => CheckFire();


        private void Awake()
        {
            _camera = Camera.main;
        }


        private Vector3 GetAimTarget()
        {
            return Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
        }

        private float GetHorizontalSpeed()
        {
            return Input.GetAxis("Horizontal");
        }   
        private float GetVerticalSpeed()
        {
            return Input.GetAxis("Vertical");
        }

        private bool CheckAcceleration()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }
        
        private bool CheckFire()
        {
            return Input.GetButtonDown("Fire1");
        }
        
        
    }
}