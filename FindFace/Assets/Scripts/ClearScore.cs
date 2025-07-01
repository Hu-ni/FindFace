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
        scoreTxt.text = $"Score: {GameManager.instance.timeTxt.text}";
        int rank = RankingManager.Instance.CheckHigh(GameManager.clearTime);
        if (rank != -1)
            RankingManager.Instance.AddScore(rank, GameManager.clearTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
