using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private int _selectedWeapon = 0;
    [SerializeField, Range(1,4)] private int _maxWeapons = 2;

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        ChangeScrollWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i >= _maxWeapons)
                weapon.gameObject.SetActive(false);
            else
            {
                if (i == _selectedWeapon)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void ChangeScrollWeapon()
    {
        int previousSelectedWeapon = _selectedWeapon;

        if (InputManager.WeaponChange > 0f)
        {
            if (_selectedWeapon >= Mathf.Min(transform.childCount, _maxWeapons) - 1)
                _selectedWeapon = 0;
            else
                _selectedWeapon++;
        }

        if (InputManager.WeaponChange < 0f)
        {
            if (_selectedWeapon <= 0)
                _selectedWeapon = Mathf.Min(transform.childCount, _maxWeapons) - 1;
            else
                _selectedWeapon--;
        }

        if (previousSelectedWeapon != _selectedWeapon)
        {
            SelectWeapon();
        }
    }
    public void IncreaseMaxWeaponRange()
    {
        _maxWeapons++;
    }
}
