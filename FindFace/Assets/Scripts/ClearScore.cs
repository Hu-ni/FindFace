using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScore : MonoBehaviour
{
    public Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = $"Score: {(GameManager.InitialTime - GameManager.clearTime).ToString("F2")}";
        bool isRank = RankingManager.Instance.CheckHigh(GameManager.InitialTime - GameManager.clearTime);
        if (isRank)
            RankingManager.Instance.AddScore(GameManager.InitialTime - GameManager.clearTime);

    }
}
