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
        foreach(ParticleSystem ps in partSystems)
        {
            ps.Play();
        }
    }

    public override void EndShoot()
    {
        foreach (ParticleSystem ps in partSystems)
        {
            ps.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
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
