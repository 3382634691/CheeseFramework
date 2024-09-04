using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public BaseData baseData;
    public List<LevelData> levelData;
}

public class BaseData
{
    //Tip: ��ǰ���е�������½�,��������������Ľ���
    public int chapterMax;
    //Tip: ��ǰ���е��½�
    public int currentChapter;
    //Tip: ��ǰ�����Ĺؿ�
    public int currentLevel;
    //Tip: �Ƿ��ǵ�һ�ν���
    public bool firstEntry;
}

public class LevelData 
{
    //Tip: ��ǰ�½�
    public int chapter;
    //Tip: ��ǰ�ؿ�
    public int level;
    //Tip: �Ѿ���ɵ�����Id
    public List<int> completedTask;
    //Tip: �ؿ��Ƿ��Ѿ����
    public bool completed;
    //Tip: �Ի������������
    public List<LevelWhithDialogData> levelWhithDialogDatas;
    //Tip: ģ�͵�λ�ô�������
    public List<LevelWithModePositionData> levelWithModePositionDatas;
}

public class LevelWithModePositionData
{
    public int ownId;
    public double localPosX;
    public double localPosY;
    public double localPosZ;
}

/// <summary>
/// �Ի��������
/// </summary>
public class LevelWhithDialogData
{
    public int ownId;
    public double localPosX;
    public double localPosY;
    public double localPosZ;
    public double localScaleX;
    public double localScaleY;
    public double localScaleZ;
}
