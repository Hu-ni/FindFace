using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject mosaicImage;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;
    public GameObject clearTxt;
    public Text scoreTxt;

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
        timeTxt.text=time.ToString("N2");
        if(time <=  0.01f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
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
        SceneManager.LoadScene("ClearScene");
    }
}
