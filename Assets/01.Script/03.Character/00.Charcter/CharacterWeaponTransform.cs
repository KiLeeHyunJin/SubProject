using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������
/// </summary>
public class CharacterWeaponTransform : MonoBehaviour
{
    [field: SerializeField] public Transform leftWeaponTransform { get; private set; }
    [field: SerializeField] public Transform rightWeaponTransform { get; private set; }

    public bool AddWeapon(string str)
    {
        GameObject obj = null; 
        //�޼� ���� ������Ʈ�� �ִٸ�
        if (leftWeaponTransform.childCount > 0)
        {//�Ű������� ��ü�� ã���ϴ�.
            obj = FindObject(leftWeaponTransform, str);
        }
        if(obj == null)
        {//������ ���� ������Ʈ�� �ִٸ�
            if (rightWeaponTransform.childCount > 0)
            {//�Ű������� ��ü�� ã���ϴ�.
                obj = FindObject(rightWeaponTransform, str);
            }
        }
        if (obj != null)
        {//��ü�� ã�Ҵٸ� �ش� ��ü�� ŵ�ϴ�.
            obj.SetActive(true);
            return true;
        }
        return false;
    }

    GameObject FindObject(Transform parent , string str)
    {
        for (int i = 0; i < parent.childCount; i++)
        {//�Ű����� �̸��� ��ü�� ���մϴ�.
            if (parent.GetChild(i).name == str)
            {//ã�Ҵٸ� �ش� ��ü�� ��ȯ�մϴ�.
                return parent.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public void SetEquipWeapon(GameObject weapon, bool equipRight = true)
    {//������ �����
        if (equipRight) //�ش� ��ü�� ������ �ڽ����� �߰��մϴ�.
            weapon.transform.SetParent(rightWeaponTransform);
        else
            weapon.transform.SetParent(leftWeaponTransform);
    }

    public void RemoveWeapon()
    {
        //�޼��� ���� ��ü�� �����Ѵٸ�
        if (leftWeaponTransform.childCount > 0)
            //��� ������ü�� ��Ȱ��ȭ�մϴ�.
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
