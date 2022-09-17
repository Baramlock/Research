using UnityEngine;

namespace Scripts.Weapon
{
    public class TombSpawner : MonoBehaviour
    {
        [SerializeField] private Tomb _prefab;

        private void Update()
        {
            if (InputReader.ClickOn(out var hit))
            {
                var spawnInstantiate = Instantiate(_prefab, hit.point, Quaternion.identity);
            }
        }

        public void ChangeType(AttackType type) => enabled = type == AttackType.Spawn;
    }
}
