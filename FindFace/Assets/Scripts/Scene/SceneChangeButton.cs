using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[Serializable]
public enum SceneNames
{
    StartScene = 0,
    MainScene,
    ClearScene,
    GameOverScene,
    RankingScene
}

// ���� ��ư ��ü
public class SceneChangeButton : MonoBehaviour
{
    public SceneNames SceneNames;

    [Header("�ɼ�")]
    public bool isFadeOutBlack;
    public bool isFadeOutWhite;

    [Header("�� �̵� ���� ó���� �̺�Ʈ")]
    public UnityEvent BeforeEvents;

    public void OnButtonClick()
    {
        BeforeEvents?.Invoke();

        if (isFadeOutBlack)
            SceneController.Instance.StartFadeOutB(SceneNames.ToString());
        else if (isFadeOutWhite)
            SceneController.Instance.StartFadeOutW(SceneNames.ToString());
        else 
            SceneController.Instance.SceneChange(SceneNames.ToString());
    }
}