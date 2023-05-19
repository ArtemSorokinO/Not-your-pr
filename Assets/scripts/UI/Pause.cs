using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject inGamePanel;

    public void pause()
    {
        pausePanel.SetActive(true);
        inGamePanel.SetActive(false);
        gameObject.GetComponent<Upgrade>().enebleLvl();
        Time.timeScale = 0f;
    }

    public void continueP()
    {
        pausePanel.SetActive(false);
        inGamePanel.SetActive(true);
        gameObject.GetComponent<Upgrade>().disableLvl();
        Time.timeScale = 1f;
    }
}
