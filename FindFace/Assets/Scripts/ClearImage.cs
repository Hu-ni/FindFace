using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClearImage : MonoBehaviour
{
    public SpriteRenderer image1;
    public SpriteRenderer image2;
    public SpriteRenderer image1Back;
    public SpriteRenderer image2Back;

    public Animator clearAnim1;
    public Animator clearAnim2;

    public bool isPlaying1 = false;
    public bool isPlaying2 = false;

    public void ChangeImage()
    {
        int order1 = image1.sortingOrder;
        int order2 = image2.sortingOrder;

        if(isPlaying1 || isPlaying2)
        {
            return;
        }

        isPlaying1 = true;
        isPlaying2 = true;

        if (order1 > order2)
        {
            clearAnim1.SetBool("isClick1", true);
            clearAnim2.SetBool("isClick2", false);
        }
        else
        {
            clearAnim2.SetBool("isClick2", true);
            clearAnim1.SetBool("isClick1", false);
        }

        Invoke("ChangeOrderInLayer", 0.2f);
        Invoke("unlockTrigger", 0.5f);

    }
    public void ChangeOrderInLayer()
    {
        int order1 = image1.sortingOrder;
        int order2 = image2.sortingOrder;
        int order1Back = image1Back.sortingOrder;
        int order2Back = image2Back.sortingOrder;

        image1.sortingOrder = order2;
        image2.sortingOrder = order1;
        image1Back.sortingOrder = order2Back;
        image2Back.sortingOrder = order1Back;
    }
    void unlockTrigger()
    {
        isPlaying1 = false;
        isPlaying2 = false;
    }
}
