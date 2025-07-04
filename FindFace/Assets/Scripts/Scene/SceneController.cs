using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    public GameObject maskImage;

    private bool isLoading = false;

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

    private void Start()
    {
        maskImage.SetActive(false);
    }

    #region ���̵� �ƿ�
    // ���̵� �ƿ�(������)
    public void StartFadeOutB(string sceneName)
    {
        if (isLoading)
            return;
        StartCoroutine(FadeOutAndLoad(sceneName, true));
    }

    // ���̵� �ƿ�(���)
    public void StartFadeOutW(string sceneName)
    {
        if (isLoading)
            return;
        StartCoroutine(FadeOutAndLoad(sceneName, false));
    }


    IEnumerator FadeOutAndLoad(string sceneName, bool isBlack)
    {
        if(isLoading)
            yield break;

        isLoading = true;
        if (Time.timeScale <= 0f)
            Time.timeScale = 1f;


        if (isBlack)
            transition.SetTrigger("FadeOutB");
        else
            transition.SetTrigger("FadeOutW");
        yield return new WaitForSeconds(1.0f); // Fade �ִϸ��̼� ����
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        isLoading = false;
    }

    public void StartFadeOutPicture(string sceneName)
    {
        if (isLoading)
            return;

        int idx = Random.Range(0, 10);
        maskImage.SetActive(true);
        maskImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"image{idx}");

        StartCoroutine(FadeOutWithPicture(sceneName));
        
    }

    IEnumerator FadeOutWithPicture(string sceneName)
    {
        isLoading = true;
        if (Time.timeScale <= 0f)
            Time.timeScale = 1f;

        transition.SetTrigger("FadeOutPicture");
        yield return new WaitForSeconds(1.0f); // Fade �ִϸ��̼� ����
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        maskImage.SetActive(false);
        isLoading = false;
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
        if (isLoading)
            return;
        isLoading = true;
        SceneManager.LoadScene(sceneName);
        isLoading = false;
    }
}
