using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool MenuOpen;
    public GameObject Menu;
    public AudioMixer masterMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BGB;
    public GameObject BGG;
    public GameObject BG1Preview;
    public GameObject BG2Preview;
    public GameObject BGBPreview;
    public GameObject BGGPreview;
    public string BGActive = "BG1";
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        box.SetActive(true);
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MenuOpen = false;
            }
        }
        if (Menu.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MenuOpen = true;
            }
        }
        if (MenuOpen == false)
        {
            Menu.SetActive(false);
        }
        if (MenuOpen == true)
        {
            Menu.SetActive(true);
        }
    }
    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float Volume)
    {
        masterMixer.SetFloat("MasterVolume", Volume);
    }

    public void SetQual(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFull(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    
    public void SetBG1()
    {
        BG1.SetActive(true);
        BG2.SetActive(false);
        BGG.SetActive(false);
        BGB.SetActive(false);
        BG1Preview.SetActive(true);
        BG2Preview.SetActive(false);
        BGGPreview.SetActive(false);
        BGBPreview.SetActive(false);
    }
    public void SetBG2()
    {
        BG1.SetActive(false);
        BG2.SetActive(true);
        BGG.SetActive(false);
        BGB.SetActive(false);
        BG1Preview.SetActive(false);
        BG2Preview.SetActive(true);
        BGGPreview.SetActive(false);
        BGBPreview.SetActive(false);
    }
    public void SetBGG()
    {
        BG1.SetActive(false);
        BG2.SetActive(false);
        BGG.SetActive(true);
        BGB.SetActive(false);
        BG1Preview.SetActive(false);
        BG2Preview.SetActive(false);
        BGGPreview.SetActive(true);
        BGBPreview.SetActive(false);
    }
    public void SetBGB()
    {
        BG1.SetActive(false);
        BG2.SetActive(false);
        BGG.SetActive(false);
        BGB.SetActive(true);
        BG1Preview.SetActive(false);
        BG2Preview.SetActive(false);
        BGGPreview.SetActive(false);
        BGBPreview.SetActive(true);
    }
}
