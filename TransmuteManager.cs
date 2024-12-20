using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransmuteManager : MonoBehaviour
{
    public GlobalClick global;
    public Transmute[] transmuteArray = new Transmute[5];
    public Transmute currentTransmute;
    public Transmute previousTransmute;
    public bool isChecking;
    public int highestUnlock;
    public Slider transSlider;

    public float sliderDiff;
    public float divHundred;
    public float nextTransLevel;

    public bool transTutBool;
    public bool transTutComp;

    public GameObject transmuteExplosion;

    public AudioSource transmuteSound;

    private void Awake()
    {
        currentTransmute = transmuteArray[0];
        highestUnlock = PlayerPrefs.GetInt("highestUnlock");
    }
    void Start()
    {
        TransmuteMinClicks();
        TransmuteSlider();
        transSlider.minValue = currentTransmute.minClicks;
        transSlider.maxValue = currentTransmute.maxClicks;
        transSlider.value = 0;
    }

    void Update()
    {
        CurrentTransmute();
        TransmuteSlider();
    }
    public Transmute CurrentTransmute()
    {
        
        if(currentTransmute.maxClicks < global.localClickCounter && currentTransmute.transLevel < transmuteArray.Length - 1)
        {
            transTutBool = true;
            global.localClickCounter = currentTransmute.maxClicks;
        }
        return currentTransmute;
    }

    public void UpgradeTransmute()
    {
        if(currentTransmute.maxClicks == global.localClickCounter)
        {
            Instantiate(transmuteExplosion, transmuteExplosion.transform);
            transTutComp = true;
            transmuteSound.Play();
            currentTransmute = transmuteArray[currentTransmute.transLevel + 1];
            if (currentTransmute.transLevel > highestUnlock)
            {
                highestUnlock = currentTransmute.transLevel;
                PlayerPrefs.SetInt("highestUnlock", highestUnlock);
                
            }
            transSlider.minValue = currentTransmute.minClicks;
            transSlider.maxValue = currentTransmute.maxClicks;
            TransmuteSlider();
            global.UpdateTransmute();
        }
    }

    public void TransmuteSlider()
    {
        transSlider.value = global.localClickCounter;
    }
    
    public void ResetTransmute()
    {
        currentTransmute = transmuteArray[0];
        transSlider.minValue = currentTransmute.minClicks;
        transSlider.maxValue = currentTransmute.maxClicks;
        global.UpdateTransmute();
    }

    public void TransmuteMinClicks()
    {
        foreach (Transmute item in transmuteArray)
        {
            if(item.transLevel == 0)
            {
                item.minClicks = 0;
            }
            else
            {
                previousTransmute = transmuteArray[item.transLevel - 1];
                item.minClicks = previousTransmute.maxClicks;
            }
        }
    }
}
