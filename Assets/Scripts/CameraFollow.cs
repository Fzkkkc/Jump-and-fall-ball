using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;

    public float Distance = 7.6f;
    public float Height = 2.5f;
    public float Damping = 1.1f;
    public float RotationDamping = 0f;

    public bool SmoothRotation = true;
    public bool FollowBehind = true;

    private void Awake()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }
 
    void Update()
    {
        Vector3 wantedPosition;
        if (FollowBehind)
            wantedPosition = _target.TransformPoint(0f, Height, -Distance);
        else
            wantedPosition = _target.TransformPoint(0f, Height, Distance);

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * Damping);

        if (SmoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(_target.position - transform.position, _target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * RotationDamping);
        }
        else
        {
            transform.LookAt(_target, _target.up);
        }
    }
}
