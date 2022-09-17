using System.Collections;
using Scripts;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _damage = 5;
    [SerializeField] private int _heal = 2;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _timeTick = 0.5f;

    private LaserWeaponDrawer _laserWeaponDrawer;
    private Coroutine _attack;

    private delegate Vector3 MoveDirection(Enemy target);

    private MoveDirection _currentMoveDirection;

    private delegate void Effect(Health enemy);

    private Effect _currentEffect;

    private void Start()
    {
        _laserWeaponDrawer = new LaserWeaponDrawer(_lineRenderer, transform);
        ChangeType(AttackType.Spawn);
    }

    private void Update()
    {
        if (InputReader.ClickOn(out Enemy target))
        {
            if (_attack != null)
                StopCoroutine(_attack);
            _attack = StartCoroutine(Attack(target));
        }
    }

    public void ChangeType(AttackType type)
    {
        enabled = true;

        switch (type)
        {
            case AttackType.Heal:
                _laserWeaponDrawer.CurrentColor = Color.green;
                _currentMoveDirection = CountDirectionToUs;
                _currentEffect = Heal;
                break;
            case AttackType.Damage:
                _laserWeaponDrawer.CurrentColor = Color.red;
                _currentMoveDirection = CountDirectionFromUs;
                _currentEffect = Damage;
                break;
            default:
                enabled = false;
                _laserWeaponDrawer.Clear();
                break;
        }
    }

    private IEnumerator Attack(Enemy target)
    {
        var currentTickTime = 0f;

        while (enabled)
        {
            _laserWeaponDrawer.DrawLine(target);
            target.transform.position += _currentMoveDirection(target) * (Time.deltaTime * _speed);
            currentTickTime += Time.deltaTime;

            if (currentTickTime > _timeTick)
            {
                currentTickTime = 0;
                _currentEffect(target.Health);
            }

            yield return null;
        }
    }

    private Vector3 CountDirectionToUs(Enemy target) =>
        target.transform.GetNormalizeDirection(transform);

    private Vector3 CountDirectionFromUs(Enemy target) =>
        transform.GetNormalizeDirection(target.transform);

    private void Heal(Health to) => to.Heal(_heal);

    private void Damage(Health to) => to.TakeDamage(_damage);
}
