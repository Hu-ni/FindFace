using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScore : MonoBehaviour
{
    public Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = $"Score: {GameManager.instance.timeTxt.text}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
