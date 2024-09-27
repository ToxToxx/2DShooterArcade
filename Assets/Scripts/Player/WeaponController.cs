
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private int _selectedWeapon = 0;

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
            if(i == _selectedWeapon)
                weapon.gameObject.SetActive(true);

            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    private void ChangeScrollWeapon()
    {
        int previousSelectedWeapon = _selectedWeapon;
        if (InputManager.WeaponChange > 0f)
        {
            if (_selectedWeapon >= transform.childCount - 1)
                _selectedWeapon = 0;
            else
                _selectedWeapon++;
        }
        if (InputManager.WeaponChange < 0f)
        {
            if (_selectedWeapon <= 0)
                _selectedWeapon = transform.childCount - 1;
            else
                _selectedWeapon--;
        }
        if (previousSelectedWeapon != _selectedWeapon)
        {
            SelectWeapon();
        }
    }

}
