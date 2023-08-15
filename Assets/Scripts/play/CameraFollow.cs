using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float sensitivityMouse = 2f;
    public Transform target;

    //观察距离
    public float distance = 5f;
    //旋转角度
    private float mx = 0.0f;
    private float my = 0.0f;
    //角度限制
    private float MinLimity = 5;
    private float MaxLimity = 180;
    //是否启用差值
    public bool isNeedDamping = true;
    //speed
    public float Damping = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        //获取鼠标输入
        mx += Input.GetAxis("Mouse X") * sensitivityMouse * 0.02F;
        my += Input.GetAxis("Mouse Y") * sensitivityMouse * 0.02f;
        //范围限制
        my = ClampAngle(my, MinLimity, MaxLimity);
        //重新计算位置和角度
        Quaternion mRotation = Quaternion.Euler(my, mx, 0);
        Vector3 mPosistion = mRotation * new Vector3(0.0f, 2.0f, -distance) + target.position;
        //设置相机的角度和位置
        if(isNeedDamping)
        {
            //球形差值
            transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * Damping);

            //线性差值
            transform.position = Vector3.Lerp(transform.position, mPosistion, Time.deltaTime * Damping);
        }
        else
        {
            transform.rotation = mRotation;
            transform.position = mPosistion;
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

}