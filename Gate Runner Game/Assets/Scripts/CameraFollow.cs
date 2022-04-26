using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Vector3 CamOffset;
    private Vector3 DesiredCamPos;
    [SerializeField] private float SmoothSpeed;
    private Transform CamAngle;

    private void Start()
    {
        CamAngle = this.transform;
    }

    void LateUpdate()
    {
        Quaternion desiredRotation = Quaternion.Euler(20, 0, 0);
        Quaternion SmoothRotation = Quaternion.Slerp(transform.rotation, desiredRotation, SmoothSpeed);
        DesiredCamPos = PlayerPosition.position + CamOffset;
        Vector3 SmoothCamPos = Vector3.Lerp(transform.position,DesiredCamPos, SmoothSpeed);
        transform.position = SmoothCamPos;
        transform.rotation = SmoothRotation;
    }
}