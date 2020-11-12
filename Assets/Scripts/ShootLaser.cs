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
    [SerializeField]
    private bool isShooting = false;
    private bool shouldReset = false;
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
        isShooting = true;
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
                    ball.SetActive(false);
                    line.SetStartAndEndPoints(new Vector3(line.m_startPos.x, line.m_startPos.y, line.m_startPos.z + laserSpeed), new Vector3(line.m_endPos.x, line.m_endPos.y, line.m_endPos.z + laserSpeed));
                }

            }
        }
    }
}
