using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPyramid : MonoBehaviour
{
    [SerializeField]
    private AudioSource aSource;
    private List<ResetCube> cubeResets;
    // Start is called before the first frame update
    void Start()
    {
        cubeResets = new List<ResetCube>();
        foreach (ResetCube rs in transform.GetComponentsInChildren<ResetCube>())
        {
            cubeResets.Add(rs);
        }
    }

    public void ResetAllCubes()
    {
        aSource.Play();
        foreach (ResetCube rs in cubeResets)
        {
            rs.Reset();
        }
    }
}
