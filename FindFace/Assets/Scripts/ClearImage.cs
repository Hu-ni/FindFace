using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Ŭ���� �̸� ����.
// Class �̸��� ���� Ŭ������ �� ��ġ��
// Unity�� Image�� �浹 ���ɼ� ����!!!
// �����ϸ� �����̸��� �����ϰ�
public class Image : MonoBehaviour
{
    public SpriteRenderer image1;
    public SpriteRenderer image2;
    public SpriteRenderer image1Back;
    public SpriteRenderer image2Back;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: �ش� �ڵ� �ǹ� ����. 
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
