using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnityWeapons : iWeapon
{
    [SerializeField]
    private ParticleSystem[] partSystems;

    [SerializeField]
    private bool testBegin, testEnd;

    public override void BeginShoot()
    {
        if (isShooting)
            return;
        isShooting = true;
        foreach(ParticleSystem ps in partSystems)
        {
            ps.Play();
        }
        audioS.Play();
    }

    public override void EndShoot()
    {
        isShooting = false;
        foreach (ParticleSystem ps in partSystems)
        {
            ps.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
        audioS.Stop();
    }
    private void Update()
    {
        if (testBegin)
        {
            BeginShoot();
            testBegin = false;
        }
        if (testEnd)
        {
            EndShoot();
            testEnd = false;
        }
    }
}
