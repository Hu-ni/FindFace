using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance;
    public string ScoreTemplate = "Rank_Score";
    public static int RankingMaxSize = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


    //return index where this score locates
    //return -1 when not top 5.
    public int CheckHigh(float score)
    {
        for (int i = RankingMaxSize - 1; i >= 0; i--)
        {
            if (PlayerPrefs.HasKey(GenKey(i)))
            {
                if (i == RankingMaxSize - 1)
                    break;
                else
                    return i + 1;
            }
        }
        for (int i = 0; i < RankingMaxSize; i++)
        {
            if (score < PlayerPrefs.GetFloat(GenKey(i)))
                return i;
        }
        return -1;
    }

    public void AddScore(int index, float score)
    {
        if (!PlayerPrefs.HasKey(GenKey(index)))
        {
            PlayerPrefs.SetFloat(GenKey(index), score);
            return;
        }
        for (int i = RankingMaxSize-1; i > index; i++)
        {
            PlayerPrefs.SetFloat(GenKey(i), PlayerPrefs.GetFloat(GenKey(i - 1)));
        }
        PlayerPrefs.SetFloat(GenKey(index), score);
    }
    public string GenKey(int index)
    {
        return ScoreTemplate + index.ToString();
    }
}
