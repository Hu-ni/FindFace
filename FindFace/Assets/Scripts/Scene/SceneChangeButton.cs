using System;
using UnityEngine;
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


    public void OnClickFadeOutB() =>
        SceneController.Instance?.StartFadeOutB(SceneNames.ToString());

    public void OnClickFadeOutW() =>
        SceneController.Instance?.StartFadeOutW(SceneNames.ToString());


    public void OnButtonClick()
    {
        SceneController.Instance?.SceneChange(SceneNames.ToString());
    }
}