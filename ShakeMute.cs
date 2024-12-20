using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMute : MonoBehaviour
{
    public GlobalClick global;
    public TransmuteManager transMan;
    public int shakeCounter;
    public bool isUpgraded;
    public new BoxCollider2D collider;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        shakeCounter = 0;
        isUpgraded = false;
        StartCoroutine(Start());
    }

    void Update()
    {
        if (global.isDragging)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
        if(shakeCounter >= 3 && !isUpgraded)
        {
            isUpgraded = true;
            transMan.UpgradeTransmute();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shakeCounter++;
    }
}
