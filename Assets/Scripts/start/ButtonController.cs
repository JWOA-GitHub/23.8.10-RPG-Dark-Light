using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // 1、游戏数据的保存，和场景之间游戏数据的传递使用PlayerPrefs
    // 2、场景分类
        // 2.1开始场景
        // 2.2角色选择界面
        // 2.3游戏玩家打怪界面，游戏实际运行场景  村庄、野怪

    // 开始新游戏
    public void OnNewGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 0);
        // 加载选择角色场景 2
    }

    // 加载已经保存的游戏
    public void OnLoadGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 1);    // DataFromSave表示数据来自保存
        // 加载游戏play场景3
    }
}
