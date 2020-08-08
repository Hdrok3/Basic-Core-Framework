using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Scene Management")]
    public string playSceneName;

    [Header("Player Prefs")]
    public string gamePrefsName = "DefaultPrefs";

    #region Settings Graphics and Audio
    float audioSFXSliderValue;
    float audioMusicSliderValue;

    float graphicsSliderValue;
    int detailLevels;
    #endregion

    #region Canvas Entities
    [Header("Main Menu Buttons")]
    public GameObject Holder_MainMenu;
    public Button StartButton;
    public Button OptionsButton;
    public Button QuitButton;

    [Header("Options Menu Buttons")]
    public GameObject Holder_OptionsMenu;
    public Button AudioOptionsButton;
    public Button GraphicsOptionsButton;
    public Button OptionsBackButton;

    [Header("Quit Menu Buttons")]
    public GameObject Holder_QuitMenu;
    public Button YesButton;
    public Button NoButton;

    [Header("Sub Options")]
    public GameObject Holder_SubOptions;
    public GameObject Holder_AudioSubOptions;
    public GameObject Holder_GraphicsSubOptions;

    [Header("Audio Options")]
    public Button AudioBackButton;
    public Slider SFXVolumeSlider;
    public Slider MusicVolumeslider;

    [Header("Graphics Options")]
    public Button GraphicsBackButton;
    public Slider GraphicQualitySlider;
    #endregion

    void Start()
    {
        #region MainMenu Initialization
        Holder_MainMenu.SetActive(true);
        Holder_OptionsMenu.SetActive(false);
        Holder_QuitMenu.SetActive(false);
        Holder_SubOptions.SetActive(false);
        Holder_AudioSubOptions.SetActive(false);
        Holder_GraphicsSubOptions.SetActive(false);
        #endregion

        #region Buttons Events Initialization
        // Start Game
        StartButton.onClick.AddListener(StartGame);

        // Options
        OptionsButton.onClick.AddListener(() => ShowMenu(Holder_MainMenu, Holder_OptionsMenu));
        OptionsBackButton.onClick.AddListener(() => BackToMainMenu(Holder_OptionsMenu));

        // Audio Options
        AudioOptionsButton.onClick.AddListener(() => ShowMenu(Holder_OptionsMenu, Holder_SubOptions, Holder_AudioSubOptions));
        AudioBackButton.onClick.AddListener(() => BackToOptionsMenu(Holder_AudioSubOptions));

        //Graphics Options
        GraphicsOptionsButton.onClick.AddListener(() => ShowMenu(Holder_OptionsMenu, Holder_SubOptions, Holder_GraphicsSubOptions));
        GraphicsBackButton.onClick.AddListener(() => BackToOptionsMenu(Holder_GraphicsSubOptions));

        // Quit Button
        QuitButton.onClick.AddListener(() => ShowMenu(Holder_MainMenu, Holder_QuitMenu));
        NoButton.onClick.AddListener(() => BackToMainMenu(Holder_QuitMenu));
        YesButton.onClick.AddListener(QuitGame);
        #endregion

        #region Player Prefs
        if(PlayerPrefs.HasKey(gamePrefsName + "_SFXVol"))
        {
            audioSFXSliderValue = PlayerPrefs.GetFloat(gamePrefsName + "_SFXVol");
        }
        else
        {
            audioSFXSliderValue = 1;
        }

        if (PlayerPrefs.HasKey(gamePrefsName + "_MusicVol"))
        {
            audioMusicSliderValue = PlayerPrefs.GetFloat(gamePrefsName + "_MusicVol");
        }
        else
        {
            audioMusicSliderValue = 1;
        }

        if (PlayerPrefs.HasKey(gamePrefsName + "_GraphicsDetail"))
        {
            graphicsSliderValue = PlayerPrefs.GetFloat(gamePrefsName + "_GraphicsDetail");
        }
        else
        {
            string[] names = QualitySettings.names;
            detailLevels = names.Length;
            graphicsSliderValue = detailLevels;
        }

        QualitySettings.SetQualityLevel((int)graphicsSliderValue, true);
        #endregion

        #region Slider Events
        SFXVolumeSlider.onValueChanged.AddListener((value) => ConfigValueToSliderValue(value, ref audioSFXSliderValue));
        MusicVolumeslider.onValueChanged.AddListener((value) => ConfigValueToSliderValue(value, ref audioMusicSliderValue));

        GraphicQualitySlider.onValueChanged.AddListener((value) => ConfigValueToSliderValue(value, ref graphicsSliderValue));
        #endregion
    }

    private void Update()
    {
        Debug.Log("SFXValue: " + audioSFXSliderValue);
        Debug.Log("MusicValue: " + audioMusicSliderValue);
        Debug.Log("GraphicsQuality: " + graphicsSliderValue);
    }

    // Start, quit
    void StartGame()
    {
        SceneManager.LoadScene(playSceneName);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    // Show Menu
    void ShowOptionsMenu()
    {
        Holder_MainMenu.SetActive(false);
        Holder_OptionsMenu.SetActive(true);
    }
    void ShowQuitMenu()
    {
        Holder_MainMenu.SetActive(false);
        Holder_QuitMenu.SetActive(true);
    }

    void ShowAudioOptionsMenu()
    {
        Holder_OptionsMenu.SetActive(false);
        Holder_AudioSubOptions.SetActive(true);
    }

    void ShowGraphicsOptionsMenu()
    {
        Holder_OptionsMenu.SetActive(false);
        Holder_GraphicsSubOptions.SetActive(true);
    }

    void ShowMenu(GameObject Main_Holder, params GameObject[] Sub_Holder)
    {
        Main_Holder.SetActive(false);

        foreach (var m in Sub_Holder)
            m.SetActive(true);
    }

    // Back To before menu
    void BackToMainMenu(GameObject holder)
    {
        holder.SetActive(false);
        Holder_MainMenu.SetActive(true);
    }

    void BackToOptionsMenu(GameObject holder)
    {
        holder.SetActive(false);
        Holder_SubOptions.SetActive(false);
        Holder_OptionsMenu.SetActive(true);
    }

    // Sliders
    void ConfigValueToSliderValue(float value, ref float toChange)
    {
        toChange = value;
    }
}
