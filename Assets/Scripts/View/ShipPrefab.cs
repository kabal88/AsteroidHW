using UnityEngine;

namespace Asteroids
{
    public class ShipPrefab : MonoBehaviour
    {
        [SerializeField] private Transform _barrel;
        public Transform ShipTransform => transform;
        public Transform Barrel => _barrel;
    }
}