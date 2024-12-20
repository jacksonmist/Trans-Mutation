using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    //public GameObject[] artifactArray = new GameObject[10];
    public Artifacts[] artifactArray = new Artifacts[10];
    public ButtonManager button;
    public Artifacts nextArtifact;
    public int artifactNumber;
    public int nextArtifactNumber;
    public int artifactPrice;
    public bool isNull;
    void Start()
    {
        NextArtifactPrice();
    }

    void Update()
    {
        
    }

    public int NextArtifactPrice()
    {
        if(artifactArray[button.artifactLevel] != null)
        {
            nextArtifact = artifactArray[button.artifactLevel];
        }      
        artifactPrice = nextArtifact.artifactPrice;
        print(artifactPrice);
        return artifactPrice;
    }
}
