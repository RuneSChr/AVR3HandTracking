using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AnimateFallDown))]
public class crappCapsuleCollision : MonoBehaviour
{
    private AnimateFallDown afd;
    private void Awake()
    {
        afd = GetComponent<AnimateFallDown>();
    }
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("ColEnter");
        afd.FallDown();
    }
}
