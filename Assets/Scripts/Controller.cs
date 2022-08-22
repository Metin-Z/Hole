using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float speed;
    public float turnSpeed;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            JoyStickMovement();
        }
    }
    public void JoyStickMovement()
    {
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        Vector3 addedPos = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        transform.position += addedPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }
}
