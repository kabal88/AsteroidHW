using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private ShipPrefab _shipPrefab;
        [SerializeField] private float _force;
        [SerializeField] private IInputModel _inputModel;
        private Ship _ship;

        private void Start()
        {
            var moveTransform =
                new AccelerationMove(_shipPrefab.ShipTransform, _playerStats.Speed, _playerStats.Acceleration);
            var rotation = new RotationShip(_shipPrefab.ShipTransform);
            _ship = new Ship(moveTransform, rotation);
        }

        private void Update()
        {
            RotatingAndMovingShip();
            AcceleratingShip();
            Shooting();
        }

        private void RotatingAndMovingShip()
        {
            _ship.Rotation(_inputModel.AimTarget);
            _ship.Move(_inputModel.HorizontalSpeed, _inputModel.VerticalSpeed, Time.deltaTime);
        }

        private void AcceleratingShip()
        {
            switch (_inputModel.IsAccelerating)
            {
                case true:
                    _ship.AddAcceleration();
                    break;
                case false:
                    _ship.RemoveAcceleration();
                    break;
            }
        }

        private void Shooting()
        {
            if (_inputModel.IsFiring)
            {
                var temAmmunition = Instantiate(_playerStats.Bullet, _shipPrefab.Barrel.position,
                    _shipPrefab.Barrel.rotation);
                temAmmunition.AddForce(_shipPrefab.Barrel.up * _force);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_playerStats.Hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _playerStats.Hp--;
            }
        }
    }
}