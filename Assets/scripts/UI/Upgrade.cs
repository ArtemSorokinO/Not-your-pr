using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public int lvlShield = 0;
    public int lvlLuck = 1;
    public int lvlHP = 0;
    public float lvlSpeed = 0;

    public int skillPoint = 0;
    [SerializeField] private Text textSkill;

    [SerializeField] private Text textShield;
    [SerializeField] private Text textLuck;
    [SerializeField] private Text textHP;
    [SerializeField] private Text textSpeed;

    [SerializeField] private GameObject buttonShield;
    [SerializeField] private GameObject buttonLuck;
    [SerializeField] private GameObject buttonHP;
    [SerializeField] private GameObject buttonSpeed;

    void Awake()
    {
        Player.toHertsSygnalSet += setParams;
    }

    void setParams(int i)
    {
        var stat = GameObject.FindWithTag("Player").GetComponent<StatsHolderPlayer>();
        lvlHP = stat.maxPlayerHP;
        lvlSpeed = stat.playerSpeed;
        lvlShield = stat.playerArmor;

    }

    void OnDisable()
    {
        Player.toHertsSygnalSet -= setParams;
        this.enabled = true;
    }

    void Update()
    {
        textShield.text = "LVL: " + lvlShield;
        textLuck.text = "LVL: " + lvlLuck;
        textHP.text = "LVL: " + lvlHP;
        textSpeed.text = "LVL: " + lvlSpeed;
        textSkill.text = "Skillpoints avaible: " + skillPoint;

    }

    public void enebleLvl()
    {
        
        if (skillPoint > 0)
        {
            if (lvlHP < 10) buttonHP.SetActive(true);
            if (lvlLuck < 10) buttonLuck.SetActive(true);
            if (lvlSpeed < 10) buttonSpeed.SetActive(true);
            if (lvlShield < 10 && lvlShield < lvlHP) buttonShield.SetActive(true); else buttonShield.SetActive(false);
        }
        else
        {
            disableLvl();
        }
    }

    public void disableLvl()
    {
        buttonHP.SetActive(false);
        buttonLuck.SetActive(false);
        buttonSpeed.SetActive(false);
        buttonShield.SetActive(false);
    }

    public void upSkillPoints(int cnt)
    {
        skillPoint += cnt;
    }

    public void upShield()
    {
        skillPoint--;
        lvlShield++;
        if (lvlShield >= 10) buttonShield.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<StatsHolderPlayer>().playerArmor = lvlShield;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().UpdateStats();
        enebleLvl();
    }
    public void upLuck()
    {
        skillPoint--;
        lvlLuck++;
        if (lvlLuck >= 10) buttonLuck.SetActive(false);
        enebleLvl();
    }
    public void upHP()
    {
        skillPoint--;
        lvlHP++;
        if (lvlHP >= 10) buttonHP.SetActive(false);
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<StatsHolderPlayer>().maxPlayerHP = lvlHP;
        player.UpdateStats();
        player.updateHearts();
        player.hill(1);
        enebleLvl();
    }
    public void upSpeed()
    {
        skillPoint--;
        lvlSpeed++;
        if (lvlSpeed >= 10) buttonSpeed.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<StatsHolderPlayer>().playerSpeed = lvlSpeed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().UpdateStats();
        enebleLvl();
    }

}
