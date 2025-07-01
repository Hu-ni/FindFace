using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;
    public GameObject clearTxt;

    public int cardCount = 0;
    float time = 30.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
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
                clearTxt.SetActive(true);
                Time.timeScale = 0.0f;
                
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
}
