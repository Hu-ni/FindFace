using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class StartButton : MonoBehaviour
{
    private bool isRotating = false;

    public void OnClickStart()
    {
        if (!isRotating)
            StartCoroutine(RotateAndLoadScene());
    }

    private IEnumerator RotateAndLoadScene()
    {
        isRotating = true;

        float duration = 0.5f;
        float elapsed = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(180, 0, 0); 

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsed / duration);
            yield return null;
        }

        
        SceneManager.LoadScene("MainScene");
    }
}