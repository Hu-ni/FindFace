using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//public static class SceneNames
//{
//    public const string ClearScene = "ClearScene";
//    public const string GameOverScene = "GameOverScene";
//    public const string MainScene = "MainScene";
//    public const string RankingScene = "ClearScene";
//    public const string StartScene = "StartScene";
//}

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    public Animator transition;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #region ���̵� �ƿ�
    // ���̵� �ƿ�(������)
    public void StartFadeOutB(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName, true));
    }

    // ���̵� �ƿ�(���)
    public void StartFadeOutW(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName, false));
    }


    IEnumerator FadeOutAndLoad(string sceneName, bool isBlack)
    {
        if (Time.timeScale <= 0f)
            Time.timeScale = 1f;


        if (isBlack)
            transition.SetTrigger("FadeOutB");
        else
            transition.SetTrigger("FadeOutW");
        yield return new WaitForSeconds(1.0f); // Fade �ִϸ��̼� ����
        SceneManager.LoadScene(sceneName);
    }
    #endregion

    // �������Ƿ� ���� �����غ��� ����غ���� 
    //#region �����̵�ƿ�
    //public void SlideOut(string sceneName)
    //{
    //    StartCoroutine(SlideOutAndLoad(sceneName));
    //}

    //IEnumerator SlideOutAndLoad(string sceneName)
    //{

    //    yield return new WaitForSeconds(1.0f);
    //    SceneManager.LoadScene(sceneName);
    //}
    //#endregion
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
