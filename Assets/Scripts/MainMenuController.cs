using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    #region Canvas Entities
    [Header("Main Menu Buttons")]
    public GameObject Holder_MainMenu;
    public Button StartButton;
    public Button OptionsButton;
    public Button QuitButton;

    [Header("Options Menu Buttons")]
    public GameObject Holder_SubMenu;
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
    public Button audioBackButton;
    public Slider SFXVolumeSlider;
    public Slider MusicVolumeslider;

    [Header("Graphics Options")]
    public Button graphicsBackButton;
    public Slider graphicQualitySlider;
    #endregion

    void Start()
    {

    }


}
