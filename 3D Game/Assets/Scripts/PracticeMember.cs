using UnityEngine;

public class PracticeMember : MonoBehaviour
{
    public SpriteRenderer logo;
    public Transform cam;
    private void Start()
    {
        
        Cursor.visible = false;                          //設定鼠標消失

        logo.flipX = true;                              //將圖片左右翻轉

        print("去小數點 :" + Mathf.Floor(1.23456f));    //去小數點

        cam.Rotate(0, 90, 0);                          //鏡頭轉向90度
    }
}
