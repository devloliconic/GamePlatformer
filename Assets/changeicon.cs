using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class changeicon : MonoBehaviour
{
    public Image oldImage;
    public Sprite dogImage;
    public Sprite manImage;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            ChangeDog();
        }
        if (Input.GetKey(KeyCode.F2))
        {
            ChangeImg();        }
    }

    public void ChangeImg()
    {
        oldImage.sprite = manImage;
    }
    public void ChangeDog()
    {
        oldImage.sprite = dogImage;
    }
}
