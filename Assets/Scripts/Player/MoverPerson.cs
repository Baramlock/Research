using UnityEngine;

namespace Scripts
{
    public class MoverPerson
    {
        private Transform _transform;
        private MovePersonSetting _currentSetting;

        public MoverPerson(Transform transform, MovePersonSetting movePersonSetting)
        {
            _transform = transform;
            _currentSetting = movePersonSetting;
        }

        public Vector3 Move(Vector2 direction, RaycastHit hit)
        {
            var selfDirection = ChooseMoveDirection(direction);
            var directionParallelPlace = selfDirection - Vector3.Project(selfDirection, hit.normal);
            var directionSpeed = directionParallelPlace * _currentSetting.FullSpeed;
            _transform.position += directionSpeed;
            return directionParallelPlace;
        }

        private Vector3 ChooseMoveDirection(Vector2 direction) =>
            (_transform.forward * (direction.x * _currentSetting.ForwardSpeed) +
             _transform.right * (direction.y * _currentSetting.LateralSpeed)) / 2;
    }

    [System.Serializable]
    public class MovePersonSetting
    {
        [SerializeField] private float _fullSpeed = 1;
        [SerializeField] private float _forwardSpeed = 1;
        [SerializeField] private float _lateralSpeed = 1;

        public float ForwardSpeed => _forwardSpeed;
        public float LateralSpeed => _lateralSpeed;

        public float FullSpeed => _fullSpeed;
    }
}
