using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 이현진
/// </summary>
public class CharacterWeaponTransform : MonoBehaviour
{
    [field: SerializeField] public Transform leftWeaponTransform { get; private set; }
    [field: SerializeField] public Transform rightWeaponTransform { get; private set; }

    public bool AddWeapon(string str)
    {
        GameObject obj = null; 
        //왼손 하위 오브젝트가 있다면
        if (leftWeaponTransform.childCount > 0)
        {//매개변수의 객체를 찾습니다.
            obj = FindObject(leftWeaponTransform, str);
        }
        if(obj == null)
        {//오른손 하위 오브젝트가 있다면
            if (rightWeaponTransform.childCount > 0)
            {//매개변수의 객체를 찾습니다.
                obj = FindObject(rightWeaponTransform, str);
            }
        }
        if (obj != null)
        {//객체를 찾았다면 해당 객체를 킵니다.
            obj.SetActive(true);
            return true;
        }
        return false;
    }

    GameObject FindObject(Transform parent , string str)
    {
        for (int i = 0; i < parent.childCount; i++)
        {//매개변수 이름의 객체를 비교합니다.
            if (parent.GetChild(i).name == str)
            {//찾았다면 해당 객체를 반환합니다.
                return parent.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public void SetEquipWeapon(GameObject weapon, bool equipRight = true)
    {//오른손 장비라면
        if (equipRight) //해당 객체를 오른손 자식으로 추가합니다.
            weapon.transform.SetParent(rightWeaponTransform);
        else
            weapon.transform.SetParent(leftWeaponTransform);
    }

    public void RemoveWeapon()
    {
        //왼손의 하위 객체가 존재한다면
        if (leftWeaponTransform.childCount > 0)
            //모든 하위객체를 비활성화합니다.
            AllOffWeapon(leftWeaponTransform);

        if(rightWeaponTransform.childCount > 0)
            AllOffWeapon(rightWeaponTransform);
    }

    void AllOffWeapon(Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }
}
