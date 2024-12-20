using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{   
    public GlobalClick global;
    public TransmuteManager transMan;
    public ArtifactManager artifacts;

    public Button clearButton;
    public Button clickUpgradeButton;
    public Button newFriendButton;
    public Button flaskButton;

    public Slider flaskSlider;
    public bool flaskWaited = true;

    public TMP_Text clickUpgradeText;
    public TMP_Text newFriendText;
    public TMP_Text flaskText;

    public int clickUpgradeLevel;
    public int clickUpgradeCost;

    public int artifactLevel;
    public int artifactUpgradeCost;

    public bool isFlasked;
    public bool canFlask;

    public AudioSource flaskSound;
    public AudioSource clickUpgradeSound;
    public AudioClip clickUpgradeClip;
    public AudioSource artifactUpgradeSound;
    public AudioClip artifactUpgradeClip;


    private void Start()
    {
        clickUpgradeLevel = PlayerPrefs.GetInt("clickUpgradeLevel");
        artifactLevel = PlayerPrefs.GetInt("artifactLevel");
        canFlask = true;
        
    }
    private void Update()
    {
        
    }


    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ClickUpgrade()
    {
        if (global.totalMoney >= ClickUpgradeCost())
        {
            clickUpgradeSound.PlayOneShot(clickUpgradeClip);
            global.totalMoney -= ClickUpgradeCost();
            global.UpdateMoney();
            clickUpgradeLevel++;
            PlayerPrefs.SetInt("clickUpgradeLevel", clickUpgradeLevel);
            global.clickAmt += clickUpgradeLevel;
            clickUpgradeText.text = $"Cost: ${ClickUpgradeCost()} Level: {clickUpgradeLevel} \n Upgrades amount per click";
        }
    }

    public void ArtifactUpgrade()
    {
        if(global.totalMoney >= artifacts.NextArtifactPrice())
        {
            artifactUpgradeSound.PlayOneShot(artifactUpgradeClip);
            global.totalMoney -= artifacts.NextArtifactPrice();
            global.UpdateMoney();
            artifactLevel++;
            PlayerPrefs.SetInt("artifactLevel", artifactLevel);
            newFriendText.text = $"Cost: ${artifacts.NextArtifactPrice()} Level: {artifactLevel} \n Buy additional artifacts to increase power!";
        }
    }

    public void FlaskPowerupButton()
    {
        if (canFlask)
        {
            flaskSound.Play();
            StartCoroutine(FlaskPowerup());
        }
    }

    public IEnumerator FlaskPowerup()
    {
        isFlasked = true;
        canFlask = false;
        flaskSlider.value = 0;
        global.clickAmt *= 2;
        yield return new WaitForSeconds(20);
        global.clickAmt /= 2;
        isFlasked = false;
        StartCoroutine(FlaskCooldown());
    }

    public IEnumerator FlaskCooldown()
    {
        StartCoroutine(FlaskFillUp());
        yield return new WaitForSeconds(40);
        canFlask = true;
    }

    public IEnumerator FlaskFillUp()
    {
        if (flaskWaited)
        {
            for(int i = 0; i <= 40; i++)
            {
                flaskWaited = false;
                flaskSlider.value += 0.025f;
                yield return new WaitForSeconds(1f);
                flaskWaited = true;
            }           
        }
        
    }

    public int ClickUpgradeCost()
    {
        clickUpgradeCost = (clickUpgradeLevel * clickUpgradeLevel) * 10 + 10;
        return clickUpgradeCost;
    }

    public int ArtifactUpgradeCost()
    {
        return artifactUpgradeCost;
    }
    public void ClickUpgradeTextEnter()
    {
        clickUpgradeText.text = $"cost: ${ClickUpgradeCost()} Level: {clickUpgradeLevel} \n Upgrades amount per click";
        clickUpgradeText.enabled = true;
    }
    public void ClickUpgradeTextExit()
    {
        clickUpgradeText.enabled = false;
    }
    public void NewFriendTextEnter()
    {
        newFriendText.text = $"Cost: ${artifacts.NextArtifactPrice()} Level: {artifactLevel} \n Buy additional artifacts to increase power!";
        newFriendText.enabled = true;
    }
    public void NewFriendTextExit()
    {
        newFriendText.enabled = false;
    }
    public void flaskTextEnter()
    {
        flaskText.enabled = true;
    }
    public void flaskTextExit()
    {
        flaskText.enabled = false;
    }
}
