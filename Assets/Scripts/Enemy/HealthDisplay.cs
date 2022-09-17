using System;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Health _health;
        [SerializeField] private Rotator.RotatorSetting _rotatorSetting;

        private Camera _main;
        private Rotator _rotator;

        private void Start()
        {
            SetCurrentFill();
            _main = Camera.main;
            _rotator = new Rotator(transform, _rotatorSetting);
        }

        private void SetCurrentFill() => _image.fillAmount = (float) _health.CurrentHealth / _health.MaxHealth;

        private void OnEnable() => _health.OnHealthChanged += SetCurrentFill;

        private void OnDisable() => _health.OnHealthChanged -= SetCurrentFill;

        private void Update() => transform.LookAt(_main.transform);
    }
}
