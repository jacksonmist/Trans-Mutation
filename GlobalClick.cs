using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalClick : MonoBehaviour
{
    public TransmuteManager transMan;
    public Transmute currentTransmute;
    public MostWanted wanted;
    public DragAndDrop drag;
    public float clickAmt;
    [SerializeField] bool isOverClicker;
    [SerializeField] float dragCounter = 0;
    public bool isDragging;

    public float localClickCounter;
    public float totalMoney;
    public float backgroundClick;

    public string transName;
    public float minClicks;
    public SpriteRenderer artwork;
    public int transLevel;

    public bool sellTutBool;
    public bool sellTutComp;

    public AudioSource clickSound;
    public AudioClip clickClip;

    public float moneyToAdd;

    private void Awake()
    {
        totalMoney = PlayerPrefs.GetFloat("totalMoney");
        clickAmt += PlayerPrefs.GetInt("clickUpgradeLevel");
        
        
    }
    void Start()
    {
        currentTransmute = transMan.currentTransmute;
        transName = currentTransmute.name;
        minClicks = currentTransmute.minClicks;
        artwork.sprite = currentTransmute.artwork;
        transLevel = currentTransmute.transLevel;
    }

    void Update()
    {
        clickChecker();
        artwork.sprite = currentTransmute.artwork;
    }
    
    public void clickChecker()
    {
        if (isOverClicker && Input.GetButton("Fire1"))
        {
            dragCounter = dragCounter + 1 * Time.deltaTime;      
            if(dragCounter >= 0.17f)
            {
                isDragging = true;
            }
        }
        if (isOverClicker && Input.GetButtonUp("Fire1"))
        {
            isDragging = false;
            if(dragCounter < 0.17f)
            {
                ClickCount(clickAmt);
            }
            print(dragCounter);
            dragCounter = 0;
        }
        SellTutorialActivate();
    }
    public void SellTutorialActivate()
    {
        if (localClickCounter >= 25)
        {
            sellTutBool = true;
        }
    }
    public void SellClicks()
    {
        sellTutComp = true;
        moneyToAdd = localClickCounter;
        if(wanted.mostWanted == currentTransmute.transLevel)
        {
            moneyToAdd *= wanted.wantedMult;
        }
        totalMoney += moneyToAdd;
        PlayerPrefs.SetFloat("totalMoney", totalMoney);
        localClickCounter = 0;
        transMan.ResetTransmute();
        wanted.MostWantedGen();
    }

    public void UpdateMoney()
    {
        PlayerPrefs.SetFloat("totalMoney", totalMoney);
    }
    public void ClickCount(float clickAmt)
    {
        clickSound.PlayOneShot(clickClip);
        localClickCounter += clickAmt;
        backgroundClick += clickAmt;
    }

    public void UpdateTransmute()
    {
        currentTransmute = transMan.currentTransmute;
        transName = currentTransmute.name;
        minClicks = currentTransmute.minClicks;
        artwork.sprite = currentTransmute.artwork;
        transLevel = currentTransmute.transLevel;
    }

    

    private void OnMouseOver()
    {
        isOverClicker = true;
    }
    private void OnMouseExit()
    {
        isOverClicker = false;
    }
}
