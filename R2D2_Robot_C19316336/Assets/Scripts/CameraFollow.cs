using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Makes sure that the camera follows a certain object (e.g the robot). Supports an offset.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Follow Settings")]
    [Tooltip("By default, the camera will precisely follow the robot's position. This vector will offset that position as needed.")]
    [SerializeField] private Vector3 followOffset = new Vector3(0f, 1f, -2.6f);
    private Transform robotTransform;

    
}