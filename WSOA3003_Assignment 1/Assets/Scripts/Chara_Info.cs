using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_Info : MonoBehaviour
{
    public string UnitName;

    public int type; //types: 0 = protag, 1 = base enemy, 2 = elemental enemy
    public int element;  // 0 = none, 1 = fire, 2 = water


    public int damage;


    public int maxHP;
    public int currentHP;

    //public void Start()
    //{
    //    damage = damage * level;
    //    maxHP = maxHP * level;
    //}

    public void TakeDamage()
    {

    }
    

}
