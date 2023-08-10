using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowPressKey : MonoBehaviour
{
    [SerializeField] private float changeSpeed = 0.1f;
    private Image image;
    float timer = 0f;

    bool isAnyKeyDown = false;
    GameObject button;
    

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        button = transform.parent.Find("Button").gameObject;
        button.SetActive(false);
        Invoke( nameof(delayedStart) , 2f);
    }

    private void Update() 
    {
        if( Time.time > 2 && isAnyKeyDown == false )
            if( Input.anyKeyDown )
                ShowButton();
    }

    void ShowButton()
    {
        button.SetActive(true);
        isAnyKeyDown = true;
        gameObject.SetActive(false);
    }

    void delayedStart()
    {
        StartCoroutine( StartDisplay());
    }

    private IEnumerator StartDisplay()
    {
        while(true)
        {
            timer = 0;
            // 递增透明度
            while( timer < 1f )
            {
                timer += Time.deltaTime * changeSpeed;
                Color color = image.color;
                color.a = Mathf.Lerp( 0, 1, timer);
                image.color = color;
                yield return null;
            }

            timer = 0;
            // 递减透明度
            while( timer < 1f )
            {
                timer += Time.deltaTime * changeSpeed;
                Color color = image.color;
                color.a = Mathf.Lerp( 1, 0, timer);
                image.color = color;
                yield return null;
            }

        }    
    }

}
