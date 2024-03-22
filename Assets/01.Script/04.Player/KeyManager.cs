using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;
/// <summary>
/// ������
/// </summary>
public class KeyManager : MonoBehaviour
{
    [SerializeField] Key[] keys;
    InputActionAsset inputSystem;

    /// <summary>
    /// �÷��̾��� PlayerInput���� ��ǲ�ý����� ������ Ű�� �߰��մϴ�.
    /// </summary>
    public void Awake()
    {
        inputSystem = GetComponent<PlayerInput>().actions;
        if(inputSystem != null)
            MakeKeyAction();
        else
            Debug.LogError("InputActionAsset�� �Ҵ���� �ʾҽ��ϴ�.");
    }

    /// <summary>
    /// KeyManager �׼� ���� �����ϰ� Ű�� �����մϴ�.
    /// </summary>
    void MakeKeyAction()
    {
        //��ǲ�ý����� ��Ȱ��ȭ�մϴ�.
        inputSystem.Disable();

        //�׼� ���� �����մϴ�. 
        InputActionMap actionMap = inputSystem.AddActionMap("KeyManager");

        if (actionMap != null)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                //Ű�� ���� �̺�Ʈ�� ���� �׼��� �����մϴ�.
                AddAction(keys[i], actionMap);
            }
        }
        else
        {
            Debug.LogError("Player �׼� ���� ã�� �� �����ϴ�.");
        }
        //��ǲ�ý����� Ȱ��ȭ�մϴ�.
        inputSystem.Enable();
    }

    /// <summary>
    /// Ű�� �߰��ϴ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="actionMap"></param>
    void AddAction(Key name, InputActionMap actionMap)
    {
        string inputActionName = name.ToString();
        //�ش� Ű�� �׼��� �ִ��� Ȯ���մϴ�.
        InputAction action = actionMap.FindAction(inputActionName);

        //�ش� Ű�� �׼��� ���� ��� �׼��� �����մϴ�.
        if (action == null)
            action = actionMap.AddAction(inputActionName, InputActionType.Button, binding: $"<Keyboard>/{inputActionName}");
        //�׼ǿ� �̺�Ʈ�� �߰��մϴ�.
        action.started += (InputAction.CallbackContext context) => OnKeyLayer(name);
    }

    public long KeyLayer { get; private set; }

    /// <summary>
    /// ��� Ű�� �÷��׸� �ʱ�ȭ�մϴ�.
    /// </summary>
    public void ResetKeyLayer() => KeyLayer = 0;
    /// <summary>
    /// Ư�� Ű�� �÷��׸� �ø��ϴ�.
    /// </summary>
    /// <param name="inputKey"></param>
    public void OnKeyLayer(Key onKey) => KeyLayer |= ((long)1 << (int)onKey);
    /// <summary>
    /// �Ű������� �Էµ� Ű�� �÷��װ� �ö���ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <param name="checkKey"></param>
    /// <returns></returns>
    public bool GetKeyCheck(Key checkKey)
    {
        long temp = ((long)1 << (int)checkKey);
        return 0 < (temp & KeyLayer);
    }

}
