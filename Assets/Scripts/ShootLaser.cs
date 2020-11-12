using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using VolumetricLines;

public class ShootLaser : iWeapon
{
    [SerializeField]
    private VolumetricLineBehavior line;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private float laserSpeed, laserLimit;
    private bool shouldReset = false;
    [SerializeField]
    private Transform handParent;
    // Start is called before the first frame update
    void Awake()
    {
        if (line.m_startPos == Vector3.zero && line.m_endPos == Vector3.zero)
        {
            line.gameObject.SetActive(false);
        }
    }
    public override void BeginShoot()
    {
        if (isShooting)
            return;
        isShooting = true;
        line.SetStartAndEndPoints(Vector3.zero, Vector3.zero);
    }
    public override void EndShoot()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            line.transform.SetParent(handParent);
            line.transform.localRotation = Quaternion.Euler(90, 0, 0);
            line.transform.position = handParent.transform.position;
            if (line.m_endPos.z == 0)
            {
                line.gameObject.SetActive(true);
                ball.SetActive(true);
                line.SetStartAndEndPoints(line.m_startPos, new Vector3(line.m_endPos.x, line.m_endPos.y, line.m_endPos.z + laserSpeed));
            }
            else
            {
                line.SetStartAndEndPoints(line.m_startPos, new Vector3(line.m_endPos.x, line.m_endPos.y, line.m_endPos.z + laserSpeed));
            }
        }
        else
        {
            if (line.m_startPos.z > laserLimit)
            {
                shouldReset = true;
            }
            if (shouldReset)
            {
                line.SetStartAndEndPoints(Vector3.zero, Vector3.zero);
                line.gameObject.SetActive(false);
                shouldReset = false;
                return;
            }
            else
            {
                if (line.m_endPos.z > 0)
                {
                    line.transform.SetParent(null);
                    ball.SetActive(false);
                    line.SetStartAndEndPoints(new Vector3(line.m_startPos.x, line.m_startPos.y, line.m_startPos.z + laserSpeed), new Vector3(line.m_endPos.x, line.m_endPos.y, line.m_endPos.z + laserSpeed));
                }

            }
        }
    }
}
