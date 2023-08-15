using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public enum PlayerState
{
    Moving,
    Idle
}

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private PlayerDir dir;
    private CharacterController controller;
    public PlayerState playerState = PlayerState.Idle;
    private Animation animation;
    public bool isMoving = false;

    public PlayerState PlayerState
    {
        get => playerState;
        set 
        {
            playerState = value;
            switch(playerState)
            {
                case PlayerState.Idle:
                    animation.CrossFade("Idle");
                    isMoving = false;
                    break;
                case PlayerState.Moving:
                    animation.CrossFade("Run");
                    isMoving = true;
                    break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dir = GetComponent<PlayerDir>();
        controller = GetComponent<CharacterController>();
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(dir.targetPos, transform.position);
        if(distance > 0.3f)
        {
            PlayerState = PlayerState.Moving;
            controller.SimpleMove(transform.forward * speed);
            
        }
        else
        {
            PlayerState = PlayerState.Idle;
            
        }
    }
}
