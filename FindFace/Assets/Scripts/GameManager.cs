using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject mosaicImage;

    public Card firstCard;
    public Card secondCard;
  
    public Text timeTxt;
    public Text scoreTxt;

    public Color warningColor = new Color(1f, 0.2f, 0.2f, 1f);
  
    AudioSource audioSource;
    public AudioClip clip;


    public int cardCount = 0;
    public static float InitialTime = 90.0f;
    float time = InitialTime;

    public static float clearTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

            audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1.0f;
        if (PlayerPrefs.GetInt("IsClear", 0) == 1)
        {
            if (mosaicImage != null)
                mosaicImage.SetActive(false);
        }

    }

   

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
            return; //main scene에서만 실행
            time -= Time.deltaTime;


        if (time < 30.0f)
        {
            timeTxt.color = new Color(warningColor.r, warningColor.g - time, warningColor.b - time, timeTxt.color.a);
        }
       if (time <= 0f)
        {
            time = 0f;
            SceneController.Instance.StartFadeOutB(SceneNames.GameOverScene.ToString());
                //SceneManager.LoadScene("GameOverScene");                       
        }                    

        timeTxt.text = time.ToString("N2");
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestoeyCard();
            secondCard.DestoeyCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
                clearTime = time;
                GameClear();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
    void GameClear()
    {
        PlayerPrefs.SetInt("IsClear", 1);
        PlayerPrefs.Save();
        //SceneManager.LoadScene("ClearScene");
        SceneController.Instance.StartFadeOutW(SceneNames.ClearScene.ToString());
    }
}
