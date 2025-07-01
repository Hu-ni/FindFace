using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: 클레스 이름 변경.
// Class 이름은 기존 클래스와 안 겹치게
// Unity의 Image와 충돌 가능성 있음!!!
// 가능하면 파일이름과 동일하게
public class Image : MonoBehaviour
{
    public SpriteRenderer image1;
    public SpriteRenderer image2;
    public SpriteRenderer image1Back;
    public SpriteRenderer image2Back;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: 해당 코드 의미 없음. 
        image1.GetComponent<SpriteRenderer>();
        image2.GetComponent<SpriteRenderer>();
        image1Back.GetComponent<SpriteRenderer>();
        image2Back.GetComponent<SpriteRenderer>();
    }

    public void ChangeImage()
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
}
