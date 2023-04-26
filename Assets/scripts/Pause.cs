using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject inGamepanel;

    public void pause()
    {
        pausePanel.SetActive(true);
        inGamepanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void continueP()
    {
        pausePanel.SetActive(false);
        inGamepanel.SetActive(true);
        Time.timeScale = 1f;
    }
}
