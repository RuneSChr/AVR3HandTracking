using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetCube : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rot;
    private Rigidbody rb;
    bool running;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        position = gameObject.transform.position;
        rot = gameObject.transform.rotation;
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
            print(rb.velocity);
            gameObject.transform.rotation = rot;
            gameObject.transform.position = position;
            rb.velocity = Vector3.zero;
        }
    }
}
