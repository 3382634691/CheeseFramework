using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public int ID;
    //Tip�����״̬
    [HideInInspector]
    public bool taskComplete;

    /// <summary>
    /// Callback:
    /// ����֮��
    /// </summary>
    public virtual void OnCreate()
    { 
    
    }

    /// <summary>
    /// Do:
    /// ��ɻ�ɫ
    /// </summary>
    public virtual void DoGray(float time = 0)
    { 
        
    }

    /// <summary>
    /// Do:
    /// ��ɲ�ɫ
    /// </summary>
    public virtual void DoColour(float time = 0.5f)
    { 
    
    }

    public virtual void AddOutLine()
    {

    }

    public virtual void RemoveOutLine()
    {

    }


    public void AddTriggerColliderBackAction(Action<GameObject> action)
    {
       
    }


    private void OnTriggerEnter(Collider other)
    {
       
    }



    /// <summary>
    /// Callback:
    /// �϶�ʱִ��
    /// </summary>
    public virtual void OnCameraRotate()
    {

    }

    /// <summary>
    /// Callback:
    /// �϶�ʱִ��
    /// </summary>
    public virtual void OnRayMove(float dis)
    {

    }

    public virtual void OnTaskComplete(int id)
    {
        taskComplete = true;
    }


    
}

public enum ModelType
{
    Model,
    Sprite,
}
