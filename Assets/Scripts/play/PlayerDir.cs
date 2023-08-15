using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour
{
    [SerializeField] GameObject effect_Click_Prefab;
    private bool isMoving = false;  // 表示鼠标是否按下
    public Vector3 targetPos = Vector3.zero;
    private PlayerMove playerMove;

    private void Start() 
    {
        targetPos = transform.position;    
        playerMove = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerMove>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool isCollider = Physics.Raycast(ray, out raycastHit);
            if( isCollider && raycastHit.collider.tag == Tags.ground )
            {
                isMoving = true;
                ShowClickEffect(raycastHit.point);
                LookAtTarget(raycastHit.point);
            }
        }

        if(Input.GetMouseButtonUp(0))
            isMoving = false;

        if(isMoving)
        {
            // 获取移动目标位置   Player朝向目标位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool isCollider = Physics.Raycast(ray, out raycastHit);
            if( isCollider && raycastHit.collider.tag == Tags.ground )
                LookAtTarget(raycastHit.point);
        }
        else 
        {
            if(playerMove.isMoving)
                LookAtTarget(targetPos);
        }
    }

    // 实例化点击效果
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3( hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        Instantiate(effect_Click_Prefab, hitPoint, Quaternion.identity);
    }

    // Player朝向点击目标
    void LookAtTarget(Vector3 hitPoint)
    {
        targetPos = hitPoint;
        targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
        transform.LookAt(targetPos);
    }
}
