using System;
using UnityEngine;
using UnityEngine.UI;

public class RankingBoard : MonoBehaviour
{
    [SerializeField] private GameObject[] Panel_List;
    [SerializeField] private GameObject challengeTxt;
    [SerializeField] private GameObject fireworkManager;

    private void Start()
    {
        int element_count = 0;
        for (int i = 0; i < RankingManager.RankingMaxSize; i++)
        {
            if (i >= Panel_List.Length)
                break;
            Console.WriteLine(RankingManager.Instance.GenKey(i));
            GameObject panel = Panel_List[i];
            if (PlayerPrefs.HasKey(RankingManager.Instance.GenKey(i)))
            {
                panel.SetActive(true);
                SetPanel(PlayerPrefs.GetFloat(RankingManager.Instance.GenKey(i)), panel.transform);
                element_count++;
            }
            else
            {
                panel.SetActive(false);
            }
        }
        if (element_count == 0)
        {
            challengeTxt.SetActive(true);
            fireworkManager.SetActive(false);
        }
        else
        {
            challengeTxt.SetActive(false);
            fireworkManager?.SetActive(true);
        }
    }

    private void SetPanel(float score, Transform panel)
    {
        panel.Find("Score").GetComponent<Text>().text = String.Format("{0:N2}", score);
    }
}
