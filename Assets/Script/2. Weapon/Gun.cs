using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
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
   
}
