using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iWeapon : MonoBehaviour
{
    public bool isShooting;
    public abstract void BeginShoot();
    public abstract void EndShoot();
}
