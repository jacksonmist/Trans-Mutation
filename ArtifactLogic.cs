using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtifactLogic : MonoBehaviour
{
    public Artifacts artifact;
    public GlobalClick global;
    public ButtonManager button;
    public DragAndDrop drag;

    public GameObject clickerObject;
    public float speed;
    public float returnSpeed;
    public float followSpeed;

    public TMP_Text nameText;

    public SpriteRenderer artworkImage;

    public float clickAmount;
    public float waitTime;
    public int artifactLevel;
    public int artifactPrice;
    public bool canClick = true;
    public bool isDoubled;


    public Vector3 homePos;
    public bool movingToHome;
    public Vector2 localHomePos;
    public Vector3 difference;
    private void Awake()
    {
        //nameText.text = artifact.artifactName;
        clickAmount = artifact.clickAmount;
        waitTime = artifact.waitTime;
        artworkImage.sprite = artifact.artWork;
        artifactLevel = artifact.artifactLevel;
        artifactPrice = artifact.artifactPrice;

        homePos = transform.position;
        difference = homePos - clickerObject.transform.position;
    }

    void Start()
    {
        

        artworkImage.enabled = false;
    }

    void Update()
    {
        Movement();
        ReturnHome();
        ArtifactUnlocked();
        //print(button.isFlasked);
    }

    public void Movement()
    {
        if(Vector3.Distance(transform.position, homePos) < 0.1f)
        {
            movingToHome = false;
            drag.movingHome = false;
        }
        if (!movingToHome)
        {
            transform.RotateAround(clickerObject.transform.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
        }
        if (global.isDragging)
        {
            localHomePos = clickerObject.transform.position + difference;
            transform.position = Vector3.MoveTowards(transform.position, localHomePos, followSpeed * Time.deltaTime);
        }
    }

    public void ReturnHome()
    {
        if(drag.movingHome)
        {
            movingToHome = true;          
        }
        if (movingToHome)
        {
            transform.position = Vector3.MoveTowards(transform.position, homePos, returnSpeed * Time.deltaTime);
        }
    }

    IEnumerator AutomaticClick()
    {
        canClick = false;
        if (button.isFlasked)
        {
            global.ClickCount(clickAmount * 2);
        }else if (!button.isFlasked)
        {
            global.ClickCount(clickAmount);
        }               
        yield return new WaitForSeconds(waitTime);
        canClick = true;
    }

    public bool ArtifactUnlocked()
    {
        if(button.artifactLevel >= artifactLevel && canClick)
        {
            artworkImage.enabled = true;
            StartCoroutine(AutomaticClick());
            return true;
        }
        else
        {
            return false;
        }
        
    }

}
