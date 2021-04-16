using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIButton : MonoBehaviour
{

    public GameObject loadScreen;
    public GameObject settingPanel;
    public Slider slider;
    public Text loadNum;
    public Text anyKeyText;
    public int nextLevelNum;
    // public void StartGame()
    // {
    //     SceneManager.LoadScene("Level_1");
    // }

    void Start()
    {
        loadScreen.SetActive(false);
        if (settingPanel != null)
        {
            settingPanel.SetActive(false);
        }


        anyKeyText.text = null;
        //anyKeyText.gameObject.GetComponent<Animator>().SetBool("isFlash", false);
    }

    #region 异步加载场景
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
        loadScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevelNum);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            loadNum.text = operation.progress * 100 + "%";
            if (operation.progress >= 0.9f)
            {
                slider.value = 1;
                loadNum.text = 100 + "%";

                anyKeyText.text = "按下任意键继续";
                anyKeyText.gameObject.GetComponent<Animator>().SetBool("isFlash", true);
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
    #endregion

    //游戏设置
    public void GameSetting()
    {
        if (settingPanel != null)
        {
            settingPanel.SetActive(true);
        }
    }

    //退出游戏
    public void ExitGame()
    {
        Application.Quit();
    }

}
