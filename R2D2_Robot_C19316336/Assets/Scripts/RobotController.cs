using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tracks player's input and applies movement and rotation to the robot as well as rotation to its head.
/// The robot's movement is similar to that of a tank - it moves forward/backward and rotates left/right to switch the direction of the movement.
/// </summary>
public class RobotController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How fast should the robot move?")]
    [SerializeField] private float robotMovementSpeed = 1f;
    [Tooltip("How fast should the robot rotate?")]
    [SerializeField] private float robotRotationSpeed = 80f;
    [Tooltip("How fast should the robot's head rotate?")]
    [SerializeField] private float headRotationSpeed = 80f;

    [Header("References")]
    [Tooltip("Robot's head to rotate. Drag it here.")]
    [SerializeField] private GameObject robotHead;

    [Header("Controls")]
    [SerializeField] private KeyCode forwardMovement = KeyCode.W;
    [SerializeField] private KeyCode backwardMovement = KeyCode.S;
    [SerializeField] private KeyCode robotRotationLeft = KeyCode.A;
    [SerializeField] private KeyCode robotRotationRight = KeyCode.D;
    [SerializeField] private KeyCode headRotationLeft = KeyCode.LeftArrow;
    [SerializeField] private KeyCode headRotationRight = KeyCode.RightArrow;

    private void Update()
    {
        RobotMovementAndRotationInput();

        RobotHeadRotationInput();   
    }

    //tracks player's input and moves/rotates the robot as required
    private void RobotMovementAndRotationInput()
    {
        if (Input.GetKey(forwardMovement))
        {
            transform.position += transform.forward * robotMovementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(backwardMovement))
        {
            transform.position += -transform.forward * robotMovementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(robotRotationLeft))
        {
            transform.Rotate(transform.up, -robotRotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(robotRotationRight))
        {
            transform.Rotate(transform.up, robotRotationSpeed * Time.deltaTime);
        }
    }

    //tracks player's input and rotates the robot's head as required
    private void RobotHeadRotationInput()
    {
        if (Input.GetKey(headRotationLeft))
        {
            robotHead.transform.Rotate(transform.up, -headRotationSpeed * Time.deltaTime, Space.World); //head should rotate on the up axis of the WORLD in order to make sure that it's truly pointing up (local up might point in another direction)
        }

        if (Input.GetKey(headRotationRight))
        {
            robotHead.transform.Rotate(transform.up, headRotationSpeed * Time.deltaTime, Space.World);
        }
    }
}