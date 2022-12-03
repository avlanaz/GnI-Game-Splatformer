using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public int level;
    public static bool reset = false;
    public static bool win = false;
    private bool inWin = false;
    public static bool pause = false;

    public GameObject menu;
    public GameObject winUI;
    public GameObject player;
    public GameObject settings;
    public GameObject levelPanel;

    public Slider BGMslide;
    public Slider SFXslide;

    public Image reloadBar;
    public Image icon;
    public Image thumbnail;

    public GameObject[] hillGenerators;
    public GameObject[] cityGenerators;
    public Text bullet_info;
    public Text stage_info;

    private Shoot shoot;

    public Sprite[] icons;

    public Sprite[] thumbnails;

    public GameObject titleWhole;
    public GameObject[] titleBG;
    public Text title;
    private float fadeSpeed = 0.05f;
    private float displaytime = 2f;
    private bool fadeIn = false;
    private bool fadeOut = false;


    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("BGM"))
        {
            PlayerPrefs.SetFloat("BGM", 0.7f);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("SFX"))
        {
            PlayerPrefs.SetFloat("SFX", 0.7f);
            PlayerPrefs.Save();
        }

        shoot = player.GetComponent<Shoot>();



        if (level != -1 && level != 12)
        {
            titleWhole.SetActive(true);
            foreach (GameObject a in titleBG)
            {
                a.GetComponent<Image>().color = new Color(214f / 255f, 206f / 255f, 1, 0);
            }
            title.GetComponent<Text>().color = new Color(1, 1, 1, 0);

            title.text = stageNumtoName(level);
            fadeIn = true;
        }

    }

    public void changeSettings()
    {
        

        PlayerPrefs.SetFloat("BGM", BGMslide.value);
        PlayerPrefs.SetFloat("SFX", SFXslide.value);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
        reloadBar.fillAmount = shoot.shootCount / shoot.shootRate;

        if(shoot.nowC() == inColor.red)
        {
            bullet_info.text = "Jump Boost";
            icon.sprite = icons[0];
            bullet_info.color = Color.red;
            reloadBar.color = Color.red;


        }else if (shoot.nowC() == inColor.blue)
        {
            bullet_info.text = "Dash";
            icon.sprite = icons[1];
            bullet_info.color = Color.blue;
            reloadBar.color = Color.blue;
        }else if (shoot.nowC() == inColor.white)
        {
            bullet_info.text = "Clear";
            icon.sprite = icons[2];
            bullet_info.color = Color.white;
            reloadBar.color = Color.white;
        }

        if (win)
        {
            if (level == 12) {

                clickNextStage();
                return;
            }
            winUI.SetActive(true);
            Time.timeScale = 0;
            pause = true;
            win = false;
            inWin = true;
        }

        if (fadeIn)
        {
            foreach (GameObject a in titleBG)
            {
                a.GetComponent<Image>().color = new Color(214f/255f, 206f/255f, 1, a.GetComponent<Image>().color.a+fadeSpeed);
            }
            title.GetComponent<Text>().color = new Color(1, 1, 1, title.GetComponent<Text>().color.a + fadeSpeed);
            if(title.GetComponent<Text>().color.a >= 1f)
            {
                Invoke("titleOut", displaytime);
                fadeIn = false;
            }
        }

        if (fadeOut)
        {
            foreach (GameObject a in titleBG)
            {
                a.GetComponent<Image>().color = new Color(214f / 255f, 206f / 255f, 1, a.GetComponent<Image>().color.a - fadeSpeed);
            }
            title.GetComponent<Text>().color = new Color(1, 1, 1, title.GetComponent<Text>().color.a - fadeSpeed);
            if (title.GetComponent<Text>().color.a <= 0)
            {
                fadeOut = false;
                titleWhole.SetActive(false);
            }
        }

    }

    public void titleOut()
    {
        fadeOut = true;
    }

    public void clickNextStage()
    {
        inWin = false;
        winUI.SetActive(false);
        win = false;
        pause = false;
        Time.timeScale = 1;
        clickLevel(level+1);

    }

    public void clickPause()
    {
        if (pause)
        {
            return;
        }

        Time.timeScale = 0;
        pause = true;
        menu.SetActive(true);
    }

    public void clickRestart()
    {
        menu.SetActive(false);
        player.GetComponent<PlayerMove>().playerDeath();
        foreach(GameObject hillGen in hillGenerators) {
            hillGen.GetComponent<TerrainGenerate>().ResetCube();
        }
        foreach(GameObject cityGen in cityGenerators) {
            cityGen.GetComponent<TerrainGenerate>().ResetCube();
        }

        clickContinue();
    }

    public void clickReturnTitle()
    {
        clickLevel(-1);
    }

    public void clickContinue()
    {
        Time.timeScale = 1;
        pause = false;
        menu.SetActive(false);
    }

    public void clickSettings()
    {
        BGMslide.value =  PlayerPrefs.GetFloat("BGM");
        SFXslide.value = PlayerPrefs.GetFloat("SFX");
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void clickSelectLevel()
    {
        levelPanel.SetActive(true);
        menu.SetActive(false);
        winUI.SetActive(false);
    }


    public void clickReturnToMain()
    {
        levelPanel.SetActive(false);
        
        if (level == -1)
        {
            GameObject.Find("levels").GetComponent<MenuCube>().setLevelCube();
        }
        else
        {
            if (inWin)
            {
                winUI.SetActive(true);
            }
            else
            {

                settings.SetActive(false);

                menu.SetActive(true);
            }
            
        }
    }

    public void clickQuit()
    {
        Application.Quit();
    }

    // setup mapping here:
    public void clickLevel(int lv)
    {
        inWin = false;

        string targetScene = stageNumtoName(lv);
        
        level = lv;

        Time.timeScale = 1;
        //player.GetComponent<PlayerMove>().playerDeath();
        SceneManager.LoadScene(targetScene);

        pause = false;
        levelPanel.SetActive(false);
        menu.SetActive(false);
        player = GameObject.Find("Player");
        PlayerMove.isDead = false;
        PlayerMove.reset = false;
    }


    private string stageNumtoName(int lv)
    {
        
        switch (lv)
        {
            case -1: return "Title";
            case 0: return "_Tutorial"; 
            case 1: return "L1-Jump!";
            case 2: return "L2-TheSpikeTrap"; 
            case 3: return "L3-TheDashlane"; 
            case 4: return  "L4-TrickySwitches"; 
            case 5: return "L5-TheSlamDam"; 
            case 6: return  "L6-RisingTension"; 
            case 7: return "L7-Backtrack";
            case 8: return "L8-PseudoReflection";
            case 9: return  "L9-DashDashDash"; 
            case 10: return  "L10-TheHall"; 
            case 11: return  "L11-PlainAir"; 
            case 12: return "Congratulations"; 
            case 13: return "Title"; 
            case 14: return  "null"; 
            case 15: return  "null"; 
            default: return  null; 
        }
    }

    public void hoverEnter(int lv)
    {
        stage_info.text = stageNumtoName(lv);
        thumbnail.sprite = thumbnails[lv];
    }
    public void hoverLeave()
    {
        thumbnail.sprite = thumbnails[12];
        stage_info.text = "";
    }

    public void fadeInTitle()
    {



    }

}