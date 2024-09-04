using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using static LevelEditor;

public class LevelLoadEditor : OdinMenuEditorWindow
{
    private BaseSetEditor baseSetEditor;
    public void Init(BaseSetEditor baseSetEditor)
    {
        this.baseSetEditor = baseSetEditor;
        LoadEditData();
    }
    [Title("�ؿ��б�")]
    [ReadOnly]
    public List<string> LevelList;

    [LabelText("�½�"), FoldoutGroup("����"), InfoBox("��ȷ���ùؿ��Ѿ�������ɣ����Կ�������Ĺؿ��б�����û�д˹أ� (�����ط���)")]
    public int Chapter;
    [LabelText("�ؿ�"), FoldoutGroup("����")]
    public int Level;

    [GUIColor(0, 1, 0)]
    [Button("���عؿ�", ButtonSizes.Large)]
    [FoldoutGroup("����")]
    private void LoadMap()
    {
        baseSetEditor.ResetScene();
        MapConfig.Instance.InitData();
        var data = ArchiveManager.Instance.LoadMapConfigFromJson<MapConfigData>(Chapter, Level);
        if (data == null)
        {
            DebugEX.LogError("��ȡ�ؿ���������ʧ��");
            return;
        }
      
        baseseteditor.SetData(data.Charpter, data.Level, data.aduioPaths);
        DebugEX.LogFrameworkMsg("�ؿ����سɹ���");
    }

    [GUIColor(1, 0f, 0f)]
    [Button("��ճ���", ButtonSizes.Medium)]
    [FoldoutGroup("����")]
    private void RestScene()
    {
        baseSetEditor.ResetScene();
    }

    [GUIColor(1, 0f, 0)]
    [Button("ɾ���ؿ�", ButtonSizes.Medium)]
    [FoldoutGroup("����")]
    private void DeleteLevel()
    {
        var window = GetWindow<TopTip>();
        window.InitData("ɾ���ؿ�","ȷ��ɾ���ؿ��������ļ�����ɾ��",()=> {
            ArchiveManager.Instance.DeleteMapConfig(Chapter, Level);
            LoadEditData();
            DebugEX.Log("ɾ���ؿ��ɹ�: "+Chapter+" - "+Level);
        });
        window.Show();
    }


    [GUIColor(1, 1, 1)]
    [Button("ˢ�¹ؿ��б�", ButtonSizes.Large)]
    [ButtonGroup("������")]
    private void LoadEditData()
    {
        LevelList = new List<string>();
        var list = ArchiveManager.Instance.LaodMapConfigDic();
        foreach (var item in list)
        {
            if (item.Contains("meta"))
                continue;
            var name = ParseAndPrintLevelInfo(Path.GetFileName(item)) + " [" + Path.GetFileName(item) + "]";
            LevelList.Add(name);
        }
    }

    /// <summary>
    /// Parse:
    /// �����ļ�����
    /// ��Ϊ�ؿ���Ϣ��״̬
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    string ParseAndPrintLevelInfo(string fileName)
    {
        // ʹ��������ʽ�����ļ���
        Match match = Regex.Match(fileName, @"mapconfig_(\d+)_(\d+).json");
       
        if (match.Success)
        {
            int chapter = int.Parse(match.Groups[1].Value);
            int level = int.Parse(match.Groups[2].Value);
            return "�� " + chapter + " �� " + " ��" + level + "��";
        }
        return "�ؿ�����ʧ��";
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        throw new System.NotImplementedException();
    }
}
