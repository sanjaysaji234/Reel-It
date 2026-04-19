using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown qualityDropDown;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        int savedQuality = PlayerPrefs.GetInt("MasterQuality", 1);

        volumeSlider.value = savedVolume;
        qualityDropDown.value = savedQuality;
        SetVolume(savedVolume);
        SetQuality(savedQuality);
    }

    public void SetVolume(float sliderValue)
    {
        float volumeInDecibels = Mathf.Log10(Mathf.Max(0.0001f, sliderValue)) * 20;

        mainMixer.SetFloat("MasterVol", volumeInDecibels);

        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("MasterQuality", qualityIndex);
        PlayerPrefs.Save();
    }
}