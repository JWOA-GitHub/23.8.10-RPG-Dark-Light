using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class DelayedCanvasDisplay : MonoBehaviour
{
    [SerializeField] private float delayTime = 2f;
    private Image image;
    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        Color imageColor = image.color;         // 或通过组件 canvas group 调节不透明度
        imageColor.a = 0f;
        image.color = imageColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowButton());
    }

    public IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(delayTime);
        Color imageColor = image.color;
        imageColor.a = 1f;
        image.color = imageColor;
    }
}
