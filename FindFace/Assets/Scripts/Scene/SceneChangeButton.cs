using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public enum SceneNames
{
    StartScene = 0,
    MainScene,
    ClearScene,
    GameOverScene,
    RankingScene
}

// 기존 버튼 대체
public class SceneChangeButton : MonoBehaviour
{
    public SceneNames SceneNames;

    [Header("옵션")]
    public bool isFadeOutBlack;
    public bool isFadeOutWhite;
    public bool isFadeOutPicture;

    [Header("씬 이동 전에 처리할 이벤트")]
    public UnityEvent BeforeEvents;

    public void OnButtonClick()
    {
        gameObject.GetComponent<Button>().interactable = false;
        BeforeEvents?.Invoke();

        if (isFadeOutBlack)
            SceneController.Instance.StartFadeOutB(SceneNames.ToString());
        else if (isFadeOutWhite)
            SceneController.Instance.StartFadeOutW(SceneNames.ToString());
        else if(isFadeOutPicture)
            SceneController.Instance.StartFadeOutPicture(SceneNames.ToString());
        else 
            SceneController.Instance.SceneChange(SceneNames.ToString());

    }
}