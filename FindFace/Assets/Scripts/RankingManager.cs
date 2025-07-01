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
    public bool CheckHigh(float score)
    {
        for (int i = 0; i < RankingMaxSize; i++)
        {
            if (!PlayerPrefs.HasKey(GenKey(i)) || score < PlayerPrefs.GetFloat(GenKey(i)))
                return true;
        }
        return false;
    }

    public void AddScore(float score)
    {
        int size = 0;
        while(PlayerPrefs.HasKey(GenKey(size)) && size < RankingMaxSize)
            size++;
        int last_index;
        if (size < RankingMaxSize)
        {
            PlayerPrefs.SetFloat(GenKey(size), score);
            last_index = size;
        }
        else
        {
            PlayerPrefs.SetFloat(GenKey(RankingMaxSize - 1), score);
            last_index = RankingMaxSize - 1;
        }
        while (last_index > 0)
        {
            float f = PlayerPrefs.GetFloat(GenKey(last_index-1));
            float b = PlayerPrefs.GetFloat(GenKey(last_index));
            if (b < f)
            {
                PlayerPrefs.SetFloat(GenKey(last_index - 1), b);
                PlayerPrefs.SetFloat(GenKey(last_index), f);
                last_index--;
            }
            else
                break;
        }
    }
    public string GenKey(int index)
    {
        return ScoreTemplate + index.ToString();
    }
    public void HardReset()
    {
        for(int i = 0; i < RankingMaxSize; i++)
            PlayerPrefs.DeleteKey(GenKey(i));
    }
}
