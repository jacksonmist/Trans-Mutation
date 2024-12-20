using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostWanted : MonoBehaviour
{
    public TransmuteManager transMan;
    public float mostWanted;
    public float wantedMult;
    public TMP_Text multText;
    public SpriteRenderer currentTrans;
    void Start()
    {
        MostWantedGen();
    }

    void Update()
    {
        
    }
    public void MostWantedGen()
    {
        wantedMult = Random.Range(1.25f, 2.5f);
        mostWanted = Random.Range(0, transMan.highestUnlock + 1);
        multText.text = wantedMult.ToString("#.#;-#.#") + "X";
        currentTrans.sprite = transMan.transmuteArray[((int)mostWanted)].artwork;
    }
}
