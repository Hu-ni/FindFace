using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
    }

    #region 페이드 아웃
    // 페이드 아웃(검은색)
    public void StartFadeOutB(string sceneName)
    {
        Debug.Log("AAA");
        StartCoroutine(FadeOutAndLoad(sceneName, true));
    }

    // 페이드 아웃(흰색)
    public void StartFadeOutW(string sceneName)
    {
        Debug.Log("BBB");
        StartCoroutine(FadeOutAndLoad(sceneName, false));
    }


    IEnumerator FadeOutAndLoad(string sceneName, bool isBlack)
    {
        if (isBlack)
            transition.SetTrigger("FadeOutB");
        else
            transition.SetTrigger("FadeOutW");
        yield return new WaitForSeconds(1.0f); // Fade 애니메이션 길이
        //SceneManager.LoadScene(sceneName);
    }
    #endregion

    #region 슬라이드아웃
    public void SlideOut(string sceneName)
    {
        StartCoroutine(SlideOutAndLoad(sceneName));
    }

    IEnumerator SlideOutAndLoad(string sceneName)
    {
        yield return new WaitForSeconds(1.0f);
    }

    #endregion
    public void OnSceneChanged(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
