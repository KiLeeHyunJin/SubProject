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
    /// 마우스 위치의 객체를 반환합니다.
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
    /// 더블클릭한 위치에 객체를 반환합니다.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public GameObject DoubleClick(GameObject obj)
    {
        //전 타임의 클릭 시간을 저장합니다.
        float beforeTime = doubleClickTime;
        //현재 클릭시간을 저장합니다.
        doubleClickTime = Time.time;
        //전 타임의 클릭 오브젝트를 저장합니다.
        GameObject beforeObj = doubleClickObj;
        //현재 클릭 오브젝트를 저장합니다.
        doubleClickObj = obj;
        //현재타임 클릭 시간 - 전타임 클릭시간 < 더블클릭 인정 시간
        if (doubleClickTime - beforeTime < succesDoubleClickTime)
        { //전 타임 오브젝트와 현재 타임 오브젝트가 같다면
            if (beforeObj == obj)
            { //더블클릭 인정
                doubleClick = true;
                return obj;
            }
        }
        return null;
    }


}
