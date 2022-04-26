using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Vector3 CamOffset;
    private Vector3 CamPosition;
    [SerializeField] private float SmoothSpeed;
    private Transform CamAngle;

    private void Start()
    {
        CamAngle = this.transform;
    }

    void FixedUpdate()
    {
        Quaternion desiredRotation = Quaternion.Euler(20, 0, 0);
        Quaternion SmoothRotation = Quaternion.Slerp(transform.rotation, desiredRotation, SmoothSpeed);
        CamPosition = PlayerPosition.position + CamOffset;
        transform.position = Vector3.Lerp(transform.position, CamPosition, SmoothSpeed);
        transform.rotation = SmoothRotation;
    }
}