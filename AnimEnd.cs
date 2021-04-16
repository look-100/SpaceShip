using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEnd : MonoBehaviour
{

    //暂停开启面板动画播放完毕后调用
    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }

    //暂停关闭面板动画播放完毕后调用
    public void PlayAnimEnd()
    {
        GlobalMgr.ClosePanel(gameObject);
    }

}
