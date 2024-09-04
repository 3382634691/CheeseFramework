using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyManager : SingleMono<InputKeyManager>
{
    //Tip: Esc�رհ��������ȼ����� ��������������Ƿ��SetUI)
    public List<int> escCache = new List<int>();
    //Tip: ���ģʽ
    public bool browseMode = false;
    //Tip: ��������
    public List<KeyCode> tobeKeyRun = new List<KeyCode>();

    /// <summary>
    /// Add:
    /// ���һ����ִ�в���
    /// </summary>
    /// <param name="code"></param>
    public void AddTobeKey(KeyCode code)
    {
        tobeKeyRun.Add(code);
    }

    /// <summary>
    /// Remove:
    /// �Ƴ�һ����ִ�в���
    /// </summary>
    /// <param name="code"></param>
    public void RemoveTobeKey(KeyCode code)
    { 
        tobeKeyRun.Remove(code);
    }

    /// <summary>
    /// Add:
    /// ���һ��Esc����
    /// </summary>
    /// <param name="id"></param>
    public void AddEscCache(int id)
    {
        escCache.Add(id);
    }
    
    /// <summary>
    /// Remove:
    /// �Ƴ�һ��Esc����
    /// </summary>
    /// <param name="id"></param>
    public void RemoveEscCache(int id)
    {
        escCache.Remove(id);
    }

    public bool IsEscCache(int id)
    {
        return escCache.Contains(id);
    }

    public int GetEscCacheCount()
    {
        return escCache.Count;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        OnAngKeyDown();
        OnConditionsKeyDown();
    }

    public void OnAngKeyDown()
    { 
        
    }
    
    /// <summary>
    /// Callback:
    /// ����������ִ�еĲ���
    /// </summary>
    public void OnConditionsKeyDown()
    {
        
    }

    /// <summary>
    /// Callback:
    /// �ؿ��еİ�������
    /// </summary>
    public void OnGameInitKeyDown()
    {
        if (IsCanDoRun(KeyCode.M))
        {
            
        }

       
    }

   

    /// <summary>
    /// Callback:
    /// �ؿ��еİ�������
    /// </summary>
    public void OnGameLevelKeyDown()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape) && escCache.Count <= 0)
        {
           
        }
        else if (browseMode)
        {
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlayEffic(1004);
        }

        OnGameLevelLongKeyDown();
    }

    /// <summary>
    /// Callback:
    /// ������Ϸ�г�������
    /// </summary>
    public void OnGameLevelLongKeyDown()
    {   

    }


    /// <summary>
    /// Is:
    /// �Ӳ������в鿴�Ƿ��д�ִ�в���
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool IsCanDoRun(KeyCode code)
    {
        foreach (var item in tobeKeyRun)
        {
            if (item == code)
                return true;
        }
        return false;
    }
}
