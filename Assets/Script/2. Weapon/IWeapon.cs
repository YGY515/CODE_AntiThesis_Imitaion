using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    //KeyCode Key { get; }
    float Damage { get; }
    void Attack();
    void PlayAnimaion();
}


// ���к��� ��
/*
public class Baton : IWeapon
{


    //public KeyCode Key => KeyCode.A;
    public float Damage => 5f;


    public void Attack()
    {
        Debug.Log("�ֵθ���");
    }

    public void PlayAnimaion()
    {
        Debug.Log("���к� �ִϸ��̼� ���");
    }
}

public class Gun : IWeapon, 
{

    //public KeyCode Key => KeyCode.S;
    public float Damage => 10f;
    public void Attack()
    {
        Debug.Log("��!");
    }
    public void PlayAnimaion()
    {
        Debug.Log("�� �ִϸ��̼� ���");
    }
*/