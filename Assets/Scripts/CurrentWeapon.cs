using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField]
    private iWeapon startWeapon;
    private iWeapon currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        SetWeapon(startWeapon);
    }
    public void SetWeapon(iWeapon weapon)
    {
        if (currentWeapon)
            currentWeapon.EndShoot();
        currentWeapon = weapon;

    }
    public void BeginShoot()
    {
        currentWeapon.BeginShoot();
    }
    public void EndShoot()
    {
        currentWeapon.EndShoot();
    }
}
