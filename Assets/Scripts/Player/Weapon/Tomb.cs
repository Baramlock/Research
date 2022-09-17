using UnityEngine;

namespace Scripts.Weapon
{
    public class Tomb : MonoBehaviour
    {
        [SerializeField] private float _radius = 5;
        [SerializeField] private float _speed = 1;

        private void Update()
        {
            var colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.transform.position +=
                        enemy.transform.GetNormalizeDirection(transform) * (Time.deltaTime * _speed);
                }
            }
        }
    }
}
