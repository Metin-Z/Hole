using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float speed, turnSpeed;
    //public PlayerSettings settings;
    Vector3 StartScale;
    UpgradeSystem _upgrade;
    private void Awake()
    {
        _upgrade = FindObjectOfType<UpgradeSystem>();
        speed = PlayerPrefs.GetFloat("SpeedSet");
        transform.GetChild(1).GetComponent<MeshRenderer>().material.DOColor(_upgrade.ChangeColor[PlayerPrefs.GetInt("SkinChangeControl")],3f);
    }
    private void Start()
    {
        StartScale = transform.localScale;
        if (StartScale == new Vector3 (0,0,0))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (speed == 0)
        {
            speed = 2.5f;
        }
        //speed = settings.speed;
        //turnSpeed = settings.turnSpeed;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            JoyStickMovement();
        }     
        Clamp();
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
    public void Clamp()
    {
        float minX = -9.42f;
        float maxX = 9.42f;
        float minZ = -9.45f;
        float maxZ = 9.45f;
        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        float zPos = Mathf.Clamp(transform.position.z, minZ, maxZ);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
