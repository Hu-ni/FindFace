using System;
using UnityEngine;
using UnityEngine.SceneManagement;
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

                RectTransform rt = panel.GetComponent<RectTransform>();
                Text[] texts = panel.transform.GetComponentsInChildren<Text>();
                Outline[] outlines = panel.transform.GetComponentsInChildren<Outline>();
                if (i == 0)
                {
                    rt.sizeDelta = new Vector2(rt.sizeDelta.x, 150);
                    foreach (Text text in texts)
                    {
                        text.color = new Color(211 / 255.0f, 175 / 255.0f, 55 / 255.0f);
                        text.fontSize = 120;
                    }
                    foreach (Outline outline in outlines)
                    {
                        outline.effectColor = Color.yellow;
                        outline.effectDistance = new Vector2(3, -3);
                    }
                }
                else if (i == 1)
                {
                    rt.sizeDelta = new Vector2(rt.sizeDelta.x, 120);
                    foreach (Text text in texts)
                    {
                        text.color = new Color(196 / 255.0f, 196 / 255.0f, 196 / 255.0f);
                        text.fontSize = 80;
                    }

                    foreach (Outline outline in outlines)
                    {
                        outline.effectColor = Color.gray;
                        outline.effectDistance = new Vector2(2, -2);
                    }
                }
                else if (i == 2)
                {
                    rt.sizeDelta = new Vector2(rt.sizeDelta.x, 100);
                    foreach (Text text in texts)
                    {
                        text.color = new Color(206 / 255.0f, 137 / 255.0f, 70 / 255.0f);
                        text.fontSize = 60;
                    }

                    foreach (Outline outline in outlines)
                    {
                        outline.effectColor = new Color(255/255.0f, 165/255.0f, 0);
                        outline.effectDistance = new Vector2(1.5f, -1.5f);
                    }
                }
                else
                {
                    rt.sizeDelta = new Vector2(rt.sizeDelta.x, 80);
                    foreach (Text text in texts)
                    {
                        text.fontSize = 40;
                    }
                    foreach (Outline outline in outlines)
                    {
                        outline.effectColor = Color.white;
                        outline.effectDistance = new Vector2(0.2f, 0.2f);
                    }
                }

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
