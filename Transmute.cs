using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Transmute", menuName = "Transmutes")]
public class Transmute : ScriptableObject
{
    public new string name;

    public float minClicks;
    public float maxClicks;
    public Sprite artwork;
    public int transLevel;
}
