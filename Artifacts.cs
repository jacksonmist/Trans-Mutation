using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Artifact", menuName = "Artifacts")]
public class Artifacts : ScriptableObject
{
    public string artifactName;

    public float clickAmount;
    public float waitTime;
    public int artifactLevel;
    public int artifactPrice;

    public Sprite artWork;
}
