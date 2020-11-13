using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iWeapon : MonoBehaviour
{
    public bool isShooting;
    [SerializeField]
    public AudioSource audioS;
    public abstract void BeginShoot();
    public abstract void EndShoot();
}
