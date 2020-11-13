using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



//class without function
[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerPositions;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    public OVRSkeleton skeleton;
    public List<Gesture> savedGestures;
    public float threshold = 0.1f;

    public CurrentWeapon currWeap;

    public bool debugMode;

    private Gesture previousGes;
    private void Start()
    {
        previousGes = new Gesture();
    }
    // Update is called once per frame
    void Update()
    {
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        Gesture currentGes = Recognize();
        bool hasRecognized = !currentGes.Equals(new Gesture());
        if (hasRecognized && (!currentGes.Equals(previousGes) || savedGestures.Count < 2))
        {
            previousGes = currentGes;
            currentGes.onRecognized.Invoke();
        }
        else if (!hasRecognized)
        {
            if (currWeap != null)
                currWeap.EndShoot();
        }
    }

    public void Save()
    {
        Gesture g = new Gesture();
        g.name = "New gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in skeleton.Bones)
        {
            //compare 
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerPositions = data;
        savedGestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture ges = new Gesture();
        float minDif = Mathf.Infinity;

        foreach (var gesture in savedGestures)
        {
            float distanceSum = 0;
            bool discarded = false;

            for (int i = 0; i < skeleton.Bones.Count; i++)
            {
                Vector3 currPosition = skeleton.transform.InverseTransformPoint(skeleton.Bones[i].Transform.position);
                float distance = Vector3.Distance(currPosition, gesture.fingerPositions[i]);
                if (distance > threshold)
                {
                    discarded = true;
                    break;
                }
                distanceSum += distance;
            }
            if (!discarded && distanceSum < minDif)
            {
                minDif = distanceSum;
                ges = gesture;
            }
        }

        return ges;
    }
}
