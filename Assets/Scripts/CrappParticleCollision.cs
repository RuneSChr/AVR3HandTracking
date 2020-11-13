using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrappParticleCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        AnimateFallDown afd = other.GetComponent<AnimateFallDown>();
        if (afd)
        {
            afd.FallDown();
        }
    }
}
