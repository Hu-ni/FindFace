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

    #region ���̵� �ƿ�
    // ���̵� �ƿ�(������)
    public void StartFadeOutB(string sceneName)
    {
        Debug.Log("AAA");
        StartCoroutine(FadeOutAndLoad(sceneName, true));
    }

    // ���̵� �ƿ�(���)
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
        yield return new WaitForSeconds(1.0f); // Fade �ִϸ��̼� ����
        //SceneManager.LoadScene(sceneName);
    }
    #endregion

    #region �����̵�ƿ�
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
