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
    private void Awake()
    {

    }

    private void Start()
    {
        GameManager.Instance.player = UnitManager.Instance.CreateNpc(1) as Player;

    }

    public void Update()
    {
       
    }

}
