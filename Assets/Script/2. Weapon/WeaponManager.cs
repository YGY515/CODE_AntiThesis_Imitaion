using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weaponObjects;
    private IWeapon currentWeapon;
    private int weapon_index = 0;

    /*
    public WeaponManager()
    {
        weapons = new IWeapon[]
        {
            new Baton(),
            new Gun(),

        };
        currentWeapon = weapons[0];
    }
    */
    void Start()
    {
        // WeaponManager�� �ν����Ϳ� ���� �Ҵ��ϴ� ������ ����
        //weaponObjects = GameObject.FindGameObjectsWithTag("Weapon");
        //weaponObjects[weapon_index].SetActive(true);

        currentWeapon = weaponObjects[weapon_index].GetComponent<IWeapon>();

        if (currentWeapon == null)
            Debug.LogError($"{weaponObjects[weapon_index].name} ������Ʈ�� IWeapon ������Ʈ�� ����");

        weaponObjects[weapon_index].SetActive(false);

    }


    public void UseWeapon()
    {
        
        if (currentWeapon != null)
            currentWeapon.Attack();
        else
            Debug.LogError("currentWeapon�� ���� �Ҵ���� ����");
    }

    public void ChangeWeapon()
    {
        Debug.Log("���� ����");

        /*
        if (weapon_index % 2 == 1)
        {
            weapon_index = 0;
        }
        else
        {
            weapon_index = 1;
        }
        currentWeapon = weapons[weapon_index];
        */

        weapon_index = (weapon_index + 1) % weaponObjects.Length;
        currentWeapon = weaponObjects[weapon_index].GetComponent<IWeapon>();
    

    }
}
