using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class InputModel : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public Vector3 GetAimTarget()
        {
            return Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
        }
        
        
    }
}