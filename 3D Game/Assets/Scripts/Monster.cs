﻿using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData data;
    [Header("補血藥水")]
    public GameObject propHP;
    [Header("加速藥水")]
    public GameObject propCd;

    //補血藥水掉落率30%
    //Random.Range(0,1) - 小於0.3
    //if (隨機 <=0.3) 掉落補血藥水

    private Animator ani;
    private float hp;

    private void Start()
    {
        hp = data.hp;
        ani = GetComponent<Animator>();
    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收到的傷害值</param>
    public void Damage(float damage)
    {
        data.hp -= damage;

        if (data.hp <= 0) Dead();
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡", true);
        DropProp();
        Destroy(gameObject, 0.1f);
    }

    /// <summary>
    /// 掉落道具
    /// </summary>
    private void DropProp()
    {
        float rHp = Random.Range(0f, 1f);
        if (rHp <= 0.3f) Instantiate(propHP, transform.position + Vector3.right * Random.Range(-1f,1f), Quaternion.identity);
        float rCd = Random.Range(0f, 1f);
        if (rHp <= 0.3f) Instantiate(propHP, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
    }
}
