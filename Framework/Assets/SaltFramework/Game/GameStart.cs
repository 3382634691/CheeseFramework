using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ؿ���������
/// ����������
/// </summary>
public class GameStart : MonoBehaviour
{
    public float distancePerKeyPress = 1f; // ÿ�ΰ����ƶ��ľ���
    public float scaleIncreaseAmount = 0.01f; // ÿ���ƶ�ʱ�������ӵ���

    private void Awake()
    {
        UIManager.Instance.Init();
    }

    private void Start()
    {
        if (GameBaseData.levelType == LevelType.COMMON)
        {

        }
        else if (GameBaseData.levelType == LevelType.HAVESUBTITLE)
        {
        }

#if UNITY_EDITOR
     /*   var debugui = UIManager.Instance.OpenUI<DebugUI>();
        debugui.GetComponent<RectTransform>().anchoredPosition = new Vector2(-172, 459f);*/
#endif

    }

    public void Update()
    {
       
    }

}
