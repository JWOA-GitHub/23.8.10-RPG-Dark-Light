using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayAnimation : MonoBehaviour
{
    Animator animator;

    // private void Awake()
    // {
    //     Color color = gameObject.GetComponent<RawImage>().color;
    //     color.a = 1.0f;
    // }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Play");
    }
    
    private void AnimationFinished()
    {
        gameObject.SetActive(false);
    }
}
