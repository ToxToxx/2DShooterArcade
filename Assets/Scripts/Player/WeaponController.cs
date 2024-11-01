using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private int _selectedWeapon = 0;
    [SerializeField, Range(1,4)] private int _maxCurrentWeapons = 2;

    [SerializeField] private int _maxWeapons = 4;

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
            if (i >= _maxCurrentWeapons)
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
            if (_selectedWeapon >= Mathf.Min(transform.childCount, _maxCurrentWeapons) - 1)
                _selectedWeapon = 0;
            else
                _selectedWeapon++;
        }

        if (InputManager.WeaponChange < 0f)
        {
            if (_selectedWeapon <= 0)
                _selectedWeapon = Mathf.Min(transform.childCount, _maxCurrentWeapons) - 1;
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
        _maxCurrentWeapons++;
    }

    private void OnEnable()
    {
        EnemyBreakpointManager.OnWeaponBreakPointHappened += EnemyBreakpointManager_OnWeaponBreakPointHappened;
    }

    private void OnDisable()
    {
        EnemyBreakpointManager.OnWeaponBreakPointHappened -= EnemyBreakpointManager_OnWeaponBreakPointHappened;
    }

    private void EnemyBreakpointManager_OnWeaponBreakPointHappened(object sender, System.EventArgs e)
    {
        if(_maxCurrentWeapons < _maxWeapons)
        {
            IncreaseMaxWeaponRange();
        }
    }
}
