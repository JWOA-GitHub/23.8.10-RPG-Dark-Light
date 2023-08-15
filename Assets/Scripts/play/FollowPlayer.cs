using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offsetPos;
    private bool isRotating = false;

    [SerializeField]private float distance = 0;
    [SerializeField]private float scrollSpeed = 10;
    [SerializeField]private float rotateSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player);
        offsetPos = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offsetPos;
        // 处理视野的拉近和拉远效果 
        ScrollView();
        // 处理视野的旋转
        RotateView();
    }


    void ScrollView()
    {
        //鼠标滚轮向后滑动 返回负值（拉近视野）  向前滑动（拉远距离）
        // print(Input.GetAxis("Mouse ScrollWheel"));
        distance = offsetPos.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);        // 滚轮距离限制
        offsetPos = offsetPos.normalized * distance;
    }

    void RotateView()
    {
        print(Input.GetAxis("Mouse X"));       // 鼠标在水平方向的滑动
        Input.GetAxis("Mouse Y");       // 鼠标在垂直方向的滑动

        if(Input.GetMouseButtonDown(1))
            isRotating = true;

        if(Input.GetMouseButtonUp(1))
            isRotating = false;
        
        if(isRotating)
        {
            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;
            transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X"));
            transform.RotateAround(player.position, transform.right, -  rotateSpeed * Input.GetAxis("Mouse Y"));  // 影响两个属性 position 和 rotation
            // print("Y轴    "+Input.GetAxis("Mouse Y"));
            
            float x = transform.eulerAngles.x;      // 限制摄像机y轴的移动范围在 10-80间
            if( x < 10 || x > 80)       // 当超出范围后，属性归位， 旋转无效
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;                
            }
            offsetPos = transform.position - player.position;
        }
    }
}
