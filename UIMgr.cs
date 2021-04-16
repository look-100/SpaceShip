using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public GameObject pausePanel;


    public GameObject pauseImage;
    public GameObject playImage;
    public Text scoreText;
    // public int sceneNum;

    int sceneIndex;
    int score = 0;
    //暂停游戏
    void Awake()
    {
        AddScore(0);
    }

    //游戏暂停
    public void PauseGame()
    {
        // pauseImage.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Pause();
        //显示暂停的icon，隐藏播放的icon
        GlobalMgr.OpenPanel(pauseImage);
        GlobalMgr.ClosePanel(playImage);
        // playImage.SetActive(false);

        //打开暂停面板
        GlobalMgr.OpenPanel(pausePanel);
        pausePanel.GetComponent<Animator>().SetBool("isPause", true);
        //Time.timeScale = 0;
        //pausePanel.SetActive(true);
    }


    //继续游戏
    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Play();
        //显示播放的icon，隐藏暂停的icon
        GlobalMgr.ClosePanel(pauseImage);
        GlobalMgr.OpenPanel(playImage);
        //pauseImage.SetActive(false);
        //playImage.SetActive(true);

        pausePanel.GetComponent<Animator>().SetBool("isPause", false);

        // GlobalMgr.ClosePanel(pausePanel);

        //pausePanel.SetActive(false);
    }
    //下一关
    // public void NextLevel()
    // {
    //     SceneManager.LoadScene(sceneNum);
    // }

    //重新开始本关卡
    public void Replay()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    //返回主菜单
    public void BackMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "分数" + "\n" + score;
        // Debug.Log(score);
    }


}
