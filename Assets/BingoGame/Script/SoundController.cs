using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    private void Update()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    void Start()
    {
        
        GetMusicAndSFXButton();
    }


    //public Slider _musicSlider, _sfxSlider;
    // public float volume;
    public void ToggleMusic()
    {
        AudioController.Instance.ToggleMusic();
    }
    public void PlayMusic()
    {
        AudioController.Instance.playMusic();
    }
    public void ToggleSFX()
    {
        AudioController.Instance.ToggleSFX();
    }
    public void PlaySFX()
    {
        AudioController.Instance.playSFX();
    }
    public void ShakeSound()
    {
        AudioController.Instance.PlaySFX("shake");
    }
    public void CorrectSound()
    {
        AudioController.Instance.PlaySFX("correct");
    }
    public void WrongSound()
    {
        AudioController.Instance.PlaySFX("wrong");
    }
    public void OpenCoverSound()
    {
        AudioController.Instance.PlaySFX("openCover");
    }
    public void CoinSound()
    {
        AudioController.Instance.PlaySFX("coin");
    }
    public void ClickSound()
    {
        AudioController.Instance.PlaySFX("click");
    }
    public void CountSound()
    {
        AudioController.Instance.PlaySFX("count");
    }
    /*   public void MusicVolume()
       {
           AudioManager.Instance.MusicVolume(_musicSlider.value);
       }
       public void SFXVolume()
       {
           AudioManager.Instance.SFXVolume(_sfxSlider.value);
       }*/
    #region Sound button
    public GameObject music, sfx, muteMusic, mutesfx;
    //public GameObject music1, sfx1, muteMusic1, mutesfx1;
    private string musicStr, sfxStr, muteMusicStr, mutesfxStr;
    private float musicVolume = 1f;
    private float sfxVolume = 1f;
    public void GetMusicAndSFXButton()
    {
        musicStr = PlayerPrefs.GetString("Music");
        if (musicStr == "clicked")
        {
            music.SetActive(false);
            muteMusic.SetActive(true);
            //music1.SetActive(false);
            //muteMusic1.SetActive(true);
            ToggleMusic();
        }
        muteMusicStr = PlayerPrefs.GetString("MuteMusic");
        if (muteMusicStr == "clicked")
        {
            music.SetActive(true);
            muteMusic.SetActive(false);
            //music1.SetActive(true);
            //muteMusic1.SetActive(false);
        }
        sfxStr = PlayerPrefs.GetString("SFX");
        if (sfxStr == "clicked")
        {
            sfx.SetActive(false);
            mutesfx.SetActive(true);
            //sfx1.SetActive(false);
            //mutesfx1.SetActive(true);
            ToggleSFX();
        }
        mutesfxStr = PlayerPrefs.GetString("MuteSFX");
        if (mutesfxStr == "clicked")
        {
            sfx.SetActive(true);
            mutesfx.SetActive(false);
            //sfx1.SetActive(true);
            //mutesfx1.SetActive(false);
        }
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            //musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            //sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }

    }

    //public Slider musicSlider;
    //public Slider sfxSlider;
    public void VolumeMusic()
    {

        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        //AudioController.Instance.MusicVolume(musicSlider.value);
        //musicVolume = musicSlider.value;

    }
    public void VolumeSFX()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        //AudioController.Instance.SFXVolume(sfxSlider.value);
        //sfxVolume = sfxSlider.value;
    }
    public void MusicButton()
    {    AudioController.Instance.TapSound();
        PlayerPrefs.SetString("Music", "clicked");
        PlayerPrefs.SetString("MuteMusic", "null");
    }
    public void MuteMusicButton()
    {
        AudioController.Instance.TapSound();
        PlayerPrefs.SetString("Music", "null");
        PlayerPrefs.SetString("MuteMusic", "clicked");


    }

    public void SFXButton()
    {
        AudioController.Instance.TapSound();
        PlayerPrefs.SetString("SFX", "clicked");
        PlayerPrefs.SetString("MuteSFX", "null");

    }
    public void MuteSFXButton()
    {
        AudioController.Instance.TapSound();
        PlayerPrefs.SetString("SFX", "null");
        PlayerPrefs.SetString("MuteSFX", "clicked");

    }
    #endregion end sound button
}
