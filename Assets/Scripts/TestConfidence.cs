using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConfidence : MonoBehaviour
{

    [SerializeField]
    private Material Confidence, instance;
    public OVRHand hand;
    private Color red, green;
    // Start is called before the first frame update
    void Start()
    {
        instance = Confidence;
        red = Color.red;
        green = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFingerMatColor(OVRHand.TrackingConfidence confidence)
    {
        if (confidence == OVRHand.TrackingConfidence.Low)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color= Color.green;
        }

    }

    
}
