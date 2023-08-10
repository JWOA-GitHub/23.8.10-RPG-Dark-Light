using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    [SerializeField] TMP_InputField tMP_InputField;     // 获取输入的文本
    private int selectedIndex = 0;
    int length; // 可供选择的角色个数

    // Start is called before the first frame update
    void Start()
    {
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for(int i=0; i<length; i++)  
        {
            characterGameObjects[i] = GameObject.Instantiate( characterPrefabs[i], transform.position, transform.rotation );
        }
        UpdateCharacterShow();  
        
    }

    void UpdateCharacterShow()  // 更新所有角色显示
    {
        characterGameObjects[selectedIndex].SetActive(true);
        for(int i=0; i<length; i++)
        {
            if( i != selectedIndex )
                characterGameObjects[i].SetActive(false);   // 未选择的角色设为隐藏
        }
    }

    public void OnNextButtonClick()
    {
        selectedIndex = (++selectedIndex) % length;
        UpdateCharacterShow();  
    }

    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if( selectedIndex < 0 )
            selectedIndex = length - 1;
        UpdateCharacterShow();  
    }

    public void OnOkButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex",selectedIndex);     // 存储选择的角色
        PlayerPrefs.SetString("name",tMP_InputField.text);     // 存储输入的名字
        // 加载下一场景

    }
}
