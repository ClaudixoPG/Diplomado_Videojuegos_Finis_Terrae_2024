using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser: Bullet
{

    /*public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;
    public LineRenderer lineRenderer;
    public Transform laserHit;

    private Vector3 hitPoint;
    private Vector3 direction;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, laserMaxLength))
        {
            hitPoint = hit.point;
            direction = hitPoint - transform.position;
        }
        else
        {
            hitPoint = transform.position + transform.forward * laserMaxLength;
            direction = transform.forward * laserMaxLength;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hitPoint);
        laserHit.position = hitPoint;
        laserHit.rotation = Quaternion.LookRotation(direction);
    }*/


}
