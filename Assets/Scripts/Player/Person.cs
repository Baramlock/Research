using UnityEngine;

namespace Scripts
{
    public class Person : MonoBehaviour
    {
        [SerializeField] private MovePersonSetting _movePersonSetting;
        [SerializeField] private Rotator.RotatorSetting _rotatorSetting;
        private InputKeyReader _inputKeyReader;
        private MoverPerson _moverPerson;
        private Rotator _rotator;

        private Vector3 _directionPlaceParallel;

        private void Awake() => InitMove();

        private void Update() => Move();

        private void InitMove()
        {
            _inputKeyReader = new InputKeyReader();
            _moverPerson = new MoverPerson(transform, _movePersonSetting);
            _rotator = new Rotator(transform, _rotatorSetting);
        }

        private void Move()
        {
            var direction = _inputKeyReader.ReadDirection() * Time.deltaTime;

            if (direction == Vector2.zero)
                return;
            Physics.Raycast(new Ray(transform.position, Vector3.down), out var hit);
            _directionPlaceParallel = _moverPerson.Move(direction, hit);
            Debug.DrawRay(transform.position, _directionPlaceParallel * 100, Color.red);
            _rotator.SlerpRotate(Vector3.forward, _directionPlaceParallel, Time.deltaTime);
        }
    }
}
