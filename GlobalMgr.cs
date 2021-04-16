using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMgr
{

    public static bool barrierIsBreak = false;
    public static bool playerIsdead = false;
    public static bool bossIsDead = false;

    public static void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public static void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

}
