using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetSysteam : Manager<GameSetSysteam>
{
    public bool isFullScreen = true;  // Ĭ��ȫ��
    public int resolutionIndex = 0;  // Ĭ�Ϸֱ�������

    public override IEnumerator Init(MonoBehaviour obj)
    {
        LoadSettings();
        return base.Init(obj);
    }

    // ������Ϸ����
    public void SaveSettings()
    {
        PlayerPrefsManager.Instance.Add("FullScreen", isFullScreen ? 1 : 0);
        PlayerPrefsManager.Instance.Add("ResolutionIndex", resolutionIndex);
    }

    // ������Ϸ����
    public void LoadSettings()
    {
        isFullScreen = PlayerPrefsManager.Instance.Get("FullScreen", 1) == 1;  // Ĭ��ȫ��
        resolutionIndex = PlayerPrefsManager.Instance.Get("ResolutionIndex", 0);  // Ĭ�ϵ�һ���ֱ���
    }

}
