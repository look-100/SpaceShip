using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{

    public GameObject player;
    public GameObject Boss;
    public GameObject enemySpawnPoint;
    public GameObject minionSpawnPoint;

    public static GameObject bossHealthBar;
    [Space]
    [Tooltip("关卡总时间（boss除外）")]
    public float thisLevelTime;
    [Tooltip("boss死亡后等待几秒后显示通关面板")]
    public float passedLevelWaitTime;
    [Tooltip("停止生成点生成敌人，几秒后出现boss")]
    public float bossShowAfterStopSpawn;
    [Space]
    public GameObject failPanel;
    public GameObject successPanel;
    public GameObject readyPanel;

    public Button playButton;



    void Start()
    {
        GlobalMgr.OpenPanel(readyPanel);
        playButton.interactable = false;
        bossHealthBar = GameObject.FindGameObjectWithTag("BossHealth");
        bossHealthBar.SetActive(false);
        Instantiate(player, new Vector3(0, -6, 0), Quaternion.identity);
        enemySpawnPoint.SetActive(false);
        StartCoroutine(StartGame());
    }

    void Update()
    {
        //玩家和boss同时死亡
        if (GlobalMgr.playerIsdead && GlobalMgr.bossIsDead)
        {
            PassFail();
            return;
        }
        //玩家死亡，boss存活
        else if (GlobalMgr.playerIsdead && GlobalMgr.bossIsDead == false)
        {
            PassFail();
            return;
        }
        //boss死亡，玩家存活
        else if (GlobalMgr.playerIsdead == false && GlobalMgr.bossIsDead)
        {
            PassSuccess();
            return;
        }


    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);
        enemySpawnPoint.SetActive(true);
        yield return new WaitForSeconds(thisLevelTime);
        enemySpawnPoint.SetActive(false);
        yield return new WaitForSeconds(bossShowAfterStopSpawn);
        if (GlobalMgr.playerIsdead == false)
        {
            Instantiate(Boss, new Vector3(0, 9.8f, 0), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            minionSpawnPoint.SetActive(true);

            //Debug.Log("Boss出现");
        }
        StopCoroutine(StartGame());
    }


    //通关失败
    public void PassFail()
    {

        enemySpawnPoint.SetActive(false);
        playButton.interactable = false;
        // if (bossGo != null)
        // {
        //     bossGo.SetActive(false);
        //     GameMgr.bossHealthBar.SetActive(false);
        // }
        passedLevelWaitTime -= Time.deltaTime;
        if (passedLevelWaitTime <= 0)
        {
            failPanel.SetActive(true);
        }
    }

    //通关成功
    public void PassSuccess()
    {
        minionSpawnPoint.SetActive(false);
        playButton.interactable = false;
        passedLevelWaitTime -= Time.deltaTime;
        if (passedLevelWaitTime <= 0)
        {
            successPanel.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
