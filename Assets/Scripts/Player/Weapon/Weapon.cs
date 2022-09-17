using UnityEngine;

namespace Scripts.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private LaserWeapon _laserWeapon;
        [SerializeField] private TombSpawner _spawner;

        public void ChangeWeapon(AttackType type)
        {
            _laserWeapon.ChangeType(type);
            _spawner.ChangeType(type);
        }
    }
}
