using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{
    public void OnButtonPressedRanking()
    {
        SceneManager.LoadScene("RankingScene");
    }
}
