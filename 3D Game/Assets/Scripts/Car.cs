﻿using UnityEngine;

public class Car : MonoBehaviour
{
    //方法語法:修飾詞 傳回類型 方法名稱(參數) {敘述}
    //void  無傳回:使用此方法時不會有任何資料傳回
    //參數語法:類型 名稱(維護性與擴充性)
    //參數語法:類型 名稱 指定 值(選填式參數 -可填可不填)
    /// <summary>
    /// 開車
    /// </summary>
    /// <param name="speed">時速</param>
    /// /// <param name="sound">音效</param>
    public void Drive(float speed, string sound = "咻咻咻" , string dir = "前方")
    {
        print("開車瞜~時速:" + speed);
        print("開車音效:" + sound);
        print("開車方向" + dir);

    }
    /// <summary>
    /// 開空調
    /// </summary>
    /// <returns>傳回開起空調</returns>
    public bool Cool()
    {
        print("開啟空調了!");
        return true;
    }
    //多載方法
    //同名方法有不同數量或不同類型參數
    /// <summary>
    /// 多載1:飛行
    /// </summary>
    public void Fly()
    {
        print("車子飛起來了~");
    }
    /// <summary>
    /// 多載2:飛行並指定高度
    /// </summary>
    /// <param name="height"></param>
    public void Fly(int height)
    {
        print("車子飛很高:" + height);
    }
}

