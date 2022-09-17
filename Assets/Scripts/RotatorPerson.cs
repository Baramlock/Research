using UnityEngine;

namespace Scripts
{
    public class RotatorPerson
    {
        private readonly Transform _transform;
        private readonly RotatorPersonSetting _rotatorPersonSetting;

        public RotatorPerson(Transform transform, RotatorPersonSetting rotatorPersonSetting)
        {
            _transform = transform;
            _rotatorPersonSetting = rotatorPersonSetting;
        }

        public void SlerpRotate(Vector3 fromDirection, Vector3 toDirection, float deltaTime)
        {
            _transform.rotation = Quaternion.Slerp(_transform.rotation,
                Quaternion.FromToRotation(Vector3.forward, toDirection),
                deltaTime * _rotatorPersonSetting.Speed);
        }

        [System.Serializable]
        public class RotatorPersonSetting
        {
            [SerializeField] private float _speed;
            public float Speed => _speed;
        }
    }
}
