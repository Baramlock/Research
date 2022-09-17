using UnityEngine;

namespace Scripts
{
    public class Rotator
    {
        private readonly Transform _transform;
        private readonly RotatorSetting _rotatorSetting;

        public Rotator(Transform transform, RotatorSetting rotatorSetting)
        {
            _transform = transform;
            _rotatorSetting = rotatorSetting;
        }

        public void SlerpRotate(Vector3 fromDirection, Vector3 toDirection, float deltaTime)
        {
            _transform.rotation = Quaternion.Slerp(_transform.rotation,
                Quaternion.FromToRotation(fromDirection, toDirection),
                deltaTime * _rotatorSetting.Speed);
        }

        [System.Serializable]
        public class RotatorSetting
        {
            [SerializeField] private float _speed = 1;
            public float Speed => _speed;
        }
    }
}
