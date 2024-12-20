using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TransmuteManager transMan;
    public GlobalClick global;

    public GameObject uiFilm;

    public GameObject clickUI;
    public GameObject transUI;
    public GameObject sellUI;

    public GameObject allTutorial;

    public int clicksTutCheck;
    public int transTutCheck;
    public int sellTutCheck;

    private void Awake()
    {
        clicksTutCheck = PlayerPrefs.GetInt("clicksTutCheck");
        transTutCheck = PlayerPrefs.GetInt("transTutCheck");
        sellTutCheck = PlayerPrefs.GetInt("sellTutCheck");
        //allTutorial.SetActive(false);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        ClicksUI();
        TransUI();
        SellUI();
    }
    public void ClicksUI()
    {
        if(clicksTutCheck == 0)
        {
            clickUI.SetActive(true);
            uiFilm.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                clickUI.SetActive(false);
                uiFilm.SetActive(false);
                clicksTutCheck = 1;
                PlayerPrefs.SetInt("clicksTutCheck", 1);
            }
        }
    }
    public void TransUI()
    {
        if (transTutCheck == 0 && transMan.transTutBool)
        {
            transUI.SetActive(true);
            uiFilm.SetActive(true);
            if (transMan.transTutComp)
            {
                transUI.SetActive(false);
                uiFilm.SetActive(false);
                transTutCheck = 1;
                PlayerPrefs.SetInt("transTutCheck", 1);
            }
        }
        
    }
    public void SellUI()
    {
        if (sellTutCheck == 0 && global.sellTutBool)
        {
            sellUI.SetActive(true);
            uiFilm.SetActive(true);
            if (global.sellTutComp)
            {
                sellUI.SetActive(false);
                uiFilm.SetActive(false);
                sellTutCheck = 1;
                PlayerPrefs.SetInt("sellTutCheck", 1);
            }
        }
    }

    public void AllTutorialsActivate()
    {
        clickUI.SetActive(true);
        uiFilm.SetActive(true);
        sellUI.SetActive(true);
        transUI.SetActive(true);
    }
    public void AllTutorialsDectivate()
    {
        clickUI.SetActive(false);
        uiFilm.SetActive(false);
        sellUI.SetActive(false);
        transUI.SetActive(false);
    }
}
