using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] float succesDoubleClickTime;
    GameObject doubleClickObj;
    float doubleClickTime;
    public bool doubleClick { get; private set; }

    /// <summary>
    /// ���콺 ��ġ�� ��ü�� ��ȯ�մϴ�.
    /// </summary>
    /// <returns></returns>
    public GameObject Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
        {
            GameObject obj = hit.collider.gameObject;
            DoubleClick(obj);
            return obj;
        }
        return null;
    }

    /// <summary>
    /// ����Ŭ���� ��ġ�� ��ü�� ��ȯ�մϴ�.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public GameObject DoubleClick(GameObject obj)
    {
        //�� Ÿ���� Ŭ�� �ð��� �����մϴ�.
        float beforeTime = doubleClickTime;
        //���� Ŭ���ð��� �����մϴ�.
        doubleClickTime = Time.time;
        //�� Ÿ���� Ŭ�� ������Ʈ�� �����մϴ�.
        GameObject beforeObj = doubleClickObj;
        //���� Ŭ�� ������Ʈ�� �����մϴ�.
        doubleClickObj = obj;
        //����Ÿ�� Ŭ�� �ð� - ��Ÿ�� Ŭ���ð� < ����Ŭ�� ���� �ð�
        if (doubleClickTime - beforeTime < succesDoubleClickTime)
        { //�� Ÿ�� ������Ʈ�� ���� Ÿ�� ������Ʈ�� ���ٸ�
            if (beforeObj == obj)
            { //����Ŭ�� ����
                doubleClick = true;
                return obj;
            }
        }
        return null;
    }


}
