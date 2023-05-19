using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject uiPanel;
    [SerializeField]
    private GameObject deathPanel;

    public void death()
    {
        pausePanel.SetActive(false);
        inGamePanel.SetActive(false);
        uiPanel.SetActive(false);
        deathPanel.SetActive(true);

        StartCoroutine(Alpfa());

        Time.timeScale = 0.6f;
    }

    private IEnumerator Alpfa() 
    {
        for (int i = 0; i < 41; i++) { 
            deathPanel.GetComponent<Image>().color = new Color(0.9622642f, 0.2255097f, 0.07716271f, i / 100f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void resurecction()
    {
        deathPanel.SetActive(false);
        pausePanel.SetActive(false);
        inGamePanel.SetActive(true);
        uiPanel.SetActive(true);
        Time.timeScale = 1f;
    }
}
