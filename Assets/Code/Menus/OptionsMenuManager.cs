using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenuManager : MonoBehaviour
{

    public Slider mainVolumeSlider;
    public Slider SFXVolumeSlider;
    public Slider musicVolumeSlider;
    public AudioMixer audioMixer;        
    public Toggle splitScreenToggle;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnEnable is run when this GameObject is enabled
    void OnEnable ()
    {
        // Set our volume sliders
        float temp;
        audioMixer.GetFloat("VolumeMaster", out temp);
        mainVolumeSlider.value = temp;

        audioMixer.GetFloat("VolumeMusic", out temp);
        musicVolumeSlider.value = temp;

        audioMixer.GetFloat("VolumeSFX", out temp);
        SFXVolumeSlider.value = temp;

    }

    public void OnBackToMenuButtonPressed()
    {
        // TODO: Save our options

        // Go back to main menu
        GameManager.instance.ActivateMainMenu();
    }


    public void OnChangeMainVolume()
    {
        // Change mixer volume to match the slider
        audioMixer.SetFloat("VolumeMaster", mainVolumeSlider.value);
    }

    public void OnChangeSFXVolume()
    {
        // Change mixer volume to match the slider
        audioMixer.SetFloat("VolumeSFX", SFXVolumeSlider.value);
    }

    public void OnChangeMusicVolume()
    {
        // Change mixer volume to match the slider
        audioMixer.SetFloat("VolumeMusic", musicVolumeSlider.value);
    }

    public void OnChangeSplitScreenToggle()
    {
        // Set my game manager variabe to the same as this toggle
        GameManager.instance.isSplitScreen = splitScreenToggle.isOn;
    }


}
