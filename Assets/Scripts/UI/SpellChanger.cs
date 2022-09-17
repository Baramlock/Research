using Scripts.Weapon;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellChanger : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Weapon _laserWeapon;
    [SerializeField] private AttackType _attackType;
    [SerializeField] private Image _image;
    [SerializeField] private Color _selected;

    private static SpellChanger _currentClick;
    private Color _startColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        _laserWeapon.ChangeWeapon(_attackType);

        if (_currentClick == this)
            return;
        // ReSharper disable once Unity.NoNullPropagation
        _currentClick?.DeSelect();
        _currentClick = this;
        Select();
    }

    private void Select()
    {
        _startColor = _image.color;
        _image.color = _selected;
    }

    private void DeSelect()
    {
        _image.color = _startColor;
    }
}
