using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(Animator))]
public class AnimateFallDown : MonoBehaviour
{
    private Animator anim;
    [SerializeField, Range(0.75f, 10f)]
    private float returnAfter = 1f;
    private bool started = false;
    [SerializeField]
    private bool testBool = false;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(testBool)
        {
            FallDown();
            testBool = false;
        }
    }
    public void FallDown()
    {
        if (!started)
            StartCoroutine(FallDownRoutine(returnAfter));
    }
    private IEnumerator FallDownRoutine(float f)
    {
        started = true;
        anim.SetBool("fall", true);
        yield return new WaitForSeconds(f);
        anim.SetBool("fall", false);
        yield return new WaitForSeconds(1f);
        started = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        FallDown();
    }
}
