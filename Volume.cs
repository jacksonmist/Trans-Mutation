using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Volume : MonoBehaviour
{
    public Slider effectSlider;
    public Button musicMute;

    public AudioSource music;
    public AudioSource transmuteSound;
    public AudioSource clickSound;
    public AudioSource flaskSound;
    public AudioSource clickUpgradeSound;
    public AudioSource artifactUpgradeSound;

    public bool muted;

    public void ChangeEffectVolume()
    {
        transmuteSound.volume = effectSlider.value;
        clickSound.volume = effectSlider.value;
        flaskSound.volume = effectSlider.value;
        clickUpgradeSound.volume = effectSlider.value;
        artifactUpgradeSound.volume = effectSlider.value;
    }

    public void MusicMute()
    {
        if (!muted)
        {
            muted = true;
            music.volume = 0;
        }else if (muted)
        {
            muted = false;
            music.volume = 0.7f;
        }
    }
}
