using UnityEngine;
using UnityEngine.UI;

public class RankingBoard : MonoBehaviour
{
    public GameObject panelPrefab;

    private void Start()
    {
        //Destroy Already Exisiting Panel
        while (this.transform.childCount != 0)
            Destroy(this.transform.GetChild(0));
        for (int i = 0; i < RankingManager.RankingMaxSize; i++)
        {
            if (PlayerPrefs.HasKey(RankingManager.Instance.GenKey(i)))
            {
                Transform panel = Instantiate(panelPrefab, this.transform).transform;
                SetPanel(PlayerPrefs.GetFloat(RankingManager.Instance.GenKey(i)), i + 1, panel);
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
