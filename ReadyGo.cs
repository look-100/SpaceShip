using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyGo : MonoBehaviour
{

    public Button playButton;
    public GameObject readyPanel;
    public Text readyText;

    void Start()
    {
        readyText.text = "Ready";
    }

    void PlayReadyAudio()
    {
        AudioManager.PlayReadyAudio();
    }

    void ChangeText()
    {
        readyText.text = "Go!";
    }

    void ClosePanel()
    {
        GlobalMgr.ClosePanel(readyPanel);
        playButton.interactable = true;
        //readyPanel.SetActive(false);
    }

}
