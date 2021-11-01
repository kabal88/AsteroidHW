using UnityEngine;

namespace Asteroids
{
    public interface IInputModel
    {
        float HorizontalSpeed { get; }
        float VerticalSpeed { get; }
        bool IsAccelerating{ get; }
        bool IsFiring { get; }
        Vector3 AimTarget { get; }
    }
}