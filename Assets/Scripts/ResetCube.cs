using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetCube : MonoBehaviour
{
    private Vector3 position;
    private Rigidbody rb;
    bool running;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        position = gameObject.transform.position;
    }

    private void Awake()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !running)
        {
            //running = true;
            rb.velocity = Vector3.zero;
            gameObject.transform.position = position;
        }
    }
}
