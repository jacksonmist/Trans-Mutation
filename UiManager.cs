using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GlobalClick global;

    public TMP_Text moneyText;
    public TMP_Text clicksText;
    public TMP_Text potentialText;

    public float cachedMoney;
    public float clicksPerSecond;

    void Start()
    {
        StartCoroutine(ClicksPerSec());
    }

    void Update()
    {
        moneyText.text = $"${global.totalMoney.ToString("0")}";
        clicksText.text = $"{clicksPerSecond} clicks/s";
        potentialText.text = global.localClickCounter.ToString();
    }

    IEnumerator ClicksPerSec()
    {
        cachedMoney = global.backgroundClick;
        yield return new WaitForSeconds(1);
        clicksPerSecond = global.backgroundClick - cachedMoney;
        StartCoroutine(ClicksPerSec());
    }

    
}
