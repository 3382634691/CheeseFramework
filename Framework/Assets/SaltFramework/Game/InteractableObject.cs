using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �ɽ���������
/// ��Ϸ���ָ���ƶ�����ĵط���
/// </summary>
public class InteractableObject : Item
{
   
    //Tip�����״̬
    [HideInInspector]
    public bool complete;
   

    public virtual void Awake()
    {
        OnCreate();
    }

    /// <summary>
    /// Callback:
    /// ���崴���ص�
    /// </summary>
    public virtual void OnCreate() 
    { 
    }



    /// <summary>
    /// Callback:
    /// �϶�ʱִ��
    /// </summary>
    public virtual void OnDray()
    {

    }

    /// <summary>
    /// Callback:
    /// �������
    /// </summary>
    /// <param name="id"></param>
    public virtual void OnTaskComplete(int id) 
    {
        complete = true;
    }
}
