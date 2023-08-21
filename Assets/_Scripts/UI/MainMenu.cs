using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas mainMenuCanvas, SettingsCanvas, fadeCanvas;
    [SerializeField] TextMeshProUGUI musicPercent, soundPercent;
    [SerializeField] Slider musicSlider, soundSlider;
    [SerializeField] Animator fadeAnimator, pauseTextAnimator;
    [SerializeField] GameObject musicPlayer;
    [SerializeField] AudioSource menuAudioSource;
    [SerializeField] AudioClip[] menuAudio;
    [SerializeField] TMP_Dropdown controlsDropdown;

    public AudioClip hoverSound;
    public AudioClip pressSound;
    public AudioMixer mixer;

    private const string musicVolumeKey = "MusicVolume";
    private const string soundVolumeKey = "SoundVolume";
    private float defaultVolume = 50f;




    private void Start(){
        LoadPlayerMainManuData();
    }
    #region MenuPlayerPrefs
    private void LoadPlayerMainManuData(){
        if (PlayerPrefs.HasKey(musicVolumeKey))
        {
            float musicVolume = PlayerPrefs.GetFloat(musicVolumeKey);
            musicSlider.value = musicVolume;
        }
        else
        {
            musicSlider.value = defaultVolume;
        }

        if (PlayerPrefs.HasKey(soundVolumeKey))
        {
            float soundVolume = PlayerPrefs.GetFloat(soundVolumeKey);
            soundSlider.value = soundVolume;
        }
        else
        {
            soundSlider.value = defaultVolume;
        }
        ChangePercentages();
    }

    private void ApplyVolume()
    {
        // Sound Mixer Magic lolololololol
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20f);
        mixer.SetFloat("SoundVolume", Mathf.Log10(soundSlider.value) * 20f);
    }

    public void ChangePercentages(){
        ApplyVolume();
        musicPercent.text = Mathf.RoundToInt((musicSlider.value * 100f)).ToString() + "%";
        soundPercent.text = Mathf.RoundToInt((soundSlider.value * 100f)).ToString() + "%";
    }

    

    public void SavePlayerData(){   
        PlayerPrefs.SetFloat(musicVolumeKey, musicSlider.value);
        PlayerPrefs.SetFloat(soundVolumeKey, soundSlider.value);

        PlayerPrefs.Save();
        

    }
    #endregion

    #region MainMenuOnlyButtonLogic
    public void StartGame(){

        SavePlayerData();
        SceneManager.LoadScene("Game");
    }

    public void CloseGame(){
        Application.Quit();
    }
    #endregion

    public void OpenSettings(){
        SettingsCanvas.enabled = true;
        mainMenuCanvas.enabled = false;
    }

    public void CloseSettings(){
        SettingsCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
        SavePlayerData();
    }
    public void PlayHoverAudio() {
        menuAudioSource.PlayOneShot(hoverSound);
    }
    public void PlayPressAudio() {
        menuAudioSource.PlayOneShot(pressSound);
    }



    private IEnumerator PlayFadeIn(){
        fadeCanvas.enabled = true;
        //fadeAnimator.SetTrigger("FadeIn");
        
        yield return new WaitForSeconds(7);
        fadeCanvas.enabled = false;
    }
    private IEnumerator PlayFadeOut(){
        fadeCanvas.enabled = true;
        //fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene(1);
    }
}
