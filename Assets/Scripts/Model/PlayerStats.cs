using UnityEngine;

namespace Asteroids
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;

        public float Speed => _speed;
        public float Acceleration => _acceleration;

        public float Hp
        {
            get => _hp;
            set => _hp = value;
        }

        public Rigidbody2D Bullet => _bullet;
    }
}