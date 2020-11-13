using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iWeapon : MonoBehaviour
{
    public bool isShooting;
    [SerializeField]
    private AudioSource audioS;
    public virtual void BeginShoot()
    {
        if (isShooting)
            return;
        isShooting = true;
        audioS.Play();
    }
    public virtual void EndShoot()
    {
        audioS.Stop();
        isShooting = false;
    }
}
