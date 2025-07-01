using System;
using UnityEngine;
using UnityEngine.UI;

public class RankingBoard : MonoBehaviour
{
    public GameObject panelPrefab;

    private void Start()
    {    
        for (int i = 0; i < RankingManager.RankingMaxSize; i++)
        {
            Console.WriteLine(RankingManager.Instance.GenKey(i));
            if (PlayerPrefs.HasKey(RankingManager.Instance.GenKey(i)))
            {
                Console.WriteLine(i.ToString());
                GameObject panel = Instantiate(panelPrefab, this.transform);
                SetPanel(PlayerPrefs.GetFloat(RankingManager.Instance.GenKey(i)), i + 1, panel.transform);
            }
            else
                break;
        }
    }

    private void SetPanel(float score, int index, Transform panel)
    {
        panel.GetChild(0).GetComponent<Text>().text = index.ToString();
        panel.GetChild(1).GetComponent<Text>().text = string.Format("{0:N2}", score);
    }
}
