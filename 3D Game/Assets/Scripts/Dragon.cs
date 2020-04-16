using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour
{
    [Header("移動速度"), Range(1, 1000)]
    public float speed = 300;
    [Header("虛擬搖桿")]
    public Joystick joy;
    [Header("攻擊冷卻時間")]
    public float cd = 1;
    [Header("火球生成延遲時間")]
    public float delayFire = 0.10f;
    [Header("火球")]
    public GameObject fierBall;
    [Header("火球移動速度"), Range(1, 5000)]
    public float speedFireBall = 300;

    //第一種寫法:須要欄位
    //public Transform tra;

    /// <summary>
    /// 動畫控制器
    /// </summary>
    private Animator ani;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;
    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
        print("移動中~");

        //第一種寫法
        //tra.Translate(0,0,1);
        //Time.deltaTime 一幀的時間
        //Input.GetAxis("Vertical"); - ws 上下
        //水平:Horizontal

        
        float v = Input.GetAxis("Vertical");
        float h= Input.GetAxis("Horizontal");

        //第二種寫法:僅限於 Transform
        transform.Translate(speed * Time.deltaTime * h, 0, speed * Time.deltaTime * v);


        float joyV = joy.Vertical;
        float joyH = joy.Horizontal;

        transform.Translate(speed * Time.deltaTime * joyH, 0, speed * Time.deltaTime * joyV);

        Vector3 pos = transform.position;       //取得飛龍座標
        pos.x = Mathf.Clamp(pos.x, 30, 70);     //數學.夾住(值,最小,最大)
        pos.z = Mathf.Clamp(pos.z, 20, 30);
        transform.position = pos;               //飛龍座標 = 夾住座標
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;            //計時器  遞增
        if (timer >= cd)            //如果   計時器 >= 冷卻
        {
            timer = 0;                  //計時器  歸零
            ani.SetTrigger("攻擊觸發");     //動畫控制.設定觸發器("參數名稱")

            StartCoroutine(DelayFireBall()); 
        }
       
    }
    private  IEnumerator DelayFireBall()
    {
        yield return new WaitForSeconds(delayFire);

        Vector3 posFire = transform.position;           //火球座標 = 飛龍座標
            posFire.z = 25f;                               //微調x軸
            posFire.y += 5.5f;                              //微調Y軸

           GameObject temp = Instantiate(fierBall, posFire, Quaternion.identity);            //生成(物件、座標、角度)
                                                                                             //Quaternion.identity Unity 角度類型、零角度
        temp.GetComponent<Rigidbody>().AddForce(0, 0, speedFireBall);
    }
    private void Start()
    {
        //取得元件<泛型>()
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Attack();
    }
}
