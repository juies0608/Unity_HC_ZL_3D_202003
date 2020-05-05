using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData data;
    [Header("補血藥水")]
    public GameObject propHp;
    [Header("加速藥水")]
    public GameObject propCd;
    [Header("發射物件")]
    public GameObject bullt;

    //補血藥水掉落率30%
    //Random.Range(0,1) - 小於0.3
    //if (隨機 <=0.3) 掉落補血藥水

    private Animator ani;
    private float hp;
    private float timer;        //計時器

    private void Start()
    {
        hp = data.hp;
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收到的傷害值</param>
    public void Damage(float damage)
    {
        data.hp -= damage;
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        Invoke("ResetColor", 0.1f);
        if (data.hp <= 0) Dead();
    }
    
    private void ResetColor()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡", true);
        DropProp();
        Destroy(gameObject, 1f);
    }

    /// <summary>
    /// 掉落道具
    /// </summary>
    private void DropProp()
    {
        float rHp = Random.Range(0f, 1f);
        if (rHp <= 0.3f) Instantiate(propHp, transform.position + Vector3.right * Random.Range(-1f,1f), Quaternion.identity);
        float rCd = Random.Range(0f, 1f);
        if (rHp <= 0.3f) Instantiate(propHp, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
    }

    /// <summary>
    /// 攻擊:發射物件
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= data.cd)
        {
            timer = 0;
            GameObject temp =Instantiate(bullt,transform.position + transform.forward,Quaternion.identity);
            temp.AddComponent<Move>().speed = data.bulletSpeed;
            temp.AddComponent<Ball>().damage = data.attack;
            temp.GetComponent<Ball>().type = "怪物";
        }
    }
}
