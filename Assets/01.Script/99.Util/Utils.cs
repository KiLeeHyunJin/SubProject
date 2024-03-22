using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using static Define;


public class Utils
{
    public static T ParseEnum<T>(string value, bool ignoreCase = true)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            Transform transform = go.transform.Find(name);
            if (transform != null)
                return transform.GetComponent<T>();
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }
        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;
        return null;
    }

	public static string GetStatToString(StatType stat)
	{
		switch (stat)
		{
			default:
				Debug.Log("GetStatString 미구현 상태");
				break;
		}

		return "";
	}

    public static Color GetPercentToColor(float value,bool isHp = false)
	{
		if (isHp)
		{
			if (value > 0)
				return new Color(0.08971164f, 0.5462896f, 0.9056604f);
			else
				return new Color(1.0f, 0, 0);
		}
		else
		{
			if (value < 0)
				return new Color(0.08971164f, 0.5462896f, 0.9056604f);
			else
				return new Color(1.0f, 0, 0);
		}
	}

	public static int GetStatToValue(StatType stat)
    {
        switch (stat)
        {
			default:
				Debug.Log("GetStatValue 미구현 상태");
				break;
        }

        return 0;
    }


	public static string GetPlayerTypeToString(PlayerCharacterType type)
	{
		switch (type)
		{
			default:
				Debug.Log("PlayerTypeToString 미구현 상태");
				break;
		}

		return "";
	}
}
