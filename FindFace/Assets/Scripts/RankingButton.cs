using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{
    [SerializeField] GameObject rankingBoard;
    public void OnButtonPressedRanking()
    {
        SceneManager.LoadScene("RankingScene");
    }
    public void OnButtonPressedHardReset()
    {
        RankingManager.Instance.HardReset();
        SceneManager.LoadScene("StartScene");
    }
}
