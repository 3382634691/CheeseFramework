using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ArchiveManager : Manager<ArchiveManager>
{
    //-------------- �浵ϵͳ -------------- 
    //һ������MapConfigҪ��Ĵ浵��ֻҪ��һЩ������������ʹ��
    //��һ��������Ϸ�浵����Ƶ����Ϊ�˷���ֱ�Ӵ浽��ע�����PlayPefer��

    private const string mapconfigPath = "Assets/Resources/Config/Map/";  //����·��    
    //Tip: ���������ô���·��
    private const string languageconfigPath = "Assets/Config/Language/";
    //Tip: ��Ϸ�����ļ�Ŀ¼
    private const string gameconfigPath = "Assets/Resources/Config/GameConfig/";

    private const string languageResPath = "Config/Language/";
    private const string gameconfigResPath = "Config/GameConfig/";
    private const string mapconfigResPath = "Config/Map/";
    private const string keyconfigResPath = "Config/InputKey/";

    //Tip: �ؿ���Դ���ļ�����
    private const string mapConfigName = "mapconfig";
    //Tip: �������ļ�����
    private const string languageFileName = "language";
    //Tip: ��Ϸ�����ļ�����
    private const string gameconfigFileName = "gameconfig";
    //Tip: ��Ϸ�б��������
    private const string saveFileName = "data.json";

    /// <summary>
    /// Save:
    /// �����ͼ����
    /// ��ͼ���ݱ�����Resource�ļ�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public void SaveMapConfigToJsonFile<T>(T data, int Chapter, int Level)
    {
        var path = mapconfigPath + mapConfigName + "_" + Chapter + "_" + Level + ".json";
        SaveToJsonFile<T>(path, data);
    }

    /// <summary>
    /// Save:
    /// �������������
    /// ������Resource�ļ�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public void SaveLanguageConfigToJsonFile<T>(T data)
    {
        var path = languageconfigPath + languageFileName+".json";
        SaveToJsonFile<T>(path, data);
    }

    /// <summary>
    /// Save:
    /// �������������
    /// ������Resource�ļ�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public void SaveGameConfigToJsonFile<T>(T data)
    {
        var path = gameconfigPath + gameconfigFileName+".json";
        SaveToJsonFile<T>(path, data);
    }


    /// <summary>
    /// Save:
    /// �Զ�������Ϸ��json�ļ�
    /// </summary>
    public void SaveDataToJsonFile()
    {
        SaveDataToJsonFile<SaveData>(GameBase.Instance.saveData);
    }

    /// <summary>
    /// Save:
    /// ������Ϸ����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public void SaveDataToJsonFile<T>(T data)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        SaveToJsonFile<T>(path, data);
    }

    /// <summary>
    /// Delete:
    /// ɾ����ͼ���ñ��ļ�
    /// </summary>
    /// <param name="Chapter"></param>
    /// <param name="Level"></param>
    public void DeleteMapConfig(int Chapter, int Level)
    {
        var path = mapconfigPath + mapConfigName + "_" + Chapter + "_" + Level + ".json";
        DeleteFile(path);
    }

    /// <summary>
    /// Delete:
    /// ɾ���浵�ļ�
    /// </summary>
    public void DeleteData()
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        DeleteFile(path);
    }

    /// <summary>
    /// Load:
    /// ���ص�ͼ����  
    /// ��ͼ������Resouce�ļ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadMapConfigFromJson<T>(int Chapter, int Level)
    {
        var val = ResourceManager.LoadPrefabSync(mapconfigResPath + mapConfigName + "_" + Chapter + "_" + Level ) as TextAsset;
        return LoadFromJsonFile<T>(val.text);
    }

    /// <summary>
    /// Load:
    /// ���ض���������
    /// ����������Resouce�ļ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadLanguageConfigFromJson<T>()
    {

        //var path = languageconfigPath + languageFileName;
        var val = ResourceManager.LoadPrefabSync(languageResPath + languageFileName) as TextAsset;
        return LoadFromJsonFile<T>(val.text);
    }

    /// <summary>
    /// Load:
    /// ���ض���������
    /// ����������Resouce�ļ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadGameConfigFromJson<T>()
    {
        //var path = gameconfigPath + gameconfigFileName;
        var val = ResourceManager.LoadPrefabSync(gameconfigResPath + gameconfigFileName) as TextAsset;
        return LoadFromJsonFile<T>(val.text);
    }

    /// <summary>
    /// Load:
    /// ����浵���ݴ�Json�ļ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadDataFromJson<T>()
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        string jsonString = File.ReadAllText(path);
        return LoadFromJsonFile<T>(jsonString);
    }

    /// <summary>
    /// Exist:
    /// �Ƿ����һ�������ļ�
    /// </summary>
    /// <returns></returns>
    public bool ExistDataFile()
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        return File.Exists(path);
    }

    /// <summary>
    /// Load:
    /// ���عؿ��б�
    /// </summary>
    /// <returns></returns>
    public string[] LaodMapConfigDic()
    {
        /*        string directoryPath = Path.Combine(mapconfigPath);
                if (Directory.Exists(directoryPath))
                {
                    // ��ȡĿ¼�µ������ļ�·��
                    string[] files = Directory.GetFiles(directoryPath);
                    return files;
                }*/

        // ��ȡ "Resources/TextAssets" �ļ����µ����� TextAsset
        TextAsset[] textAssets = Resources.LoadAll<TextAsset>(mapconfigResPath);
        var vals = new string[textAssets.Length];
        // ���� TextAsset ���鲢��ÿ�� TextAsset ���ı�����ת��Ϊ�ַ���
        for (int i = 0; i < textAssets.Length; i++)
        {
            vals[i] = textAssets[i].name;
        }
        return vals;
        //return null;
    }


    /// <summary>
    /// Save:
    /// �������ݳ�Ϊjson��ʽ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <param name="data"></param>
    private void SaveToJsonFile<T>(string filePath, T data)
    {
        var directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
        string jsonString = JsonMapper.ToJson(data);
        File.WriteAllText(filePath, jsonString);
    }

    /// <summary>
    /// Delete:
    /// ɾ���ļ�
    /// </summary>
    /// <param name="path"></param>
    public void DeleteFile(string path)
    {
        //var filePath = Path.Combine(Application.persistentDataPath, path);
        // ����ļ��в����ڣ��򴴽��ļ���
        if (File.Exists(path))
            File.Delete(path);
    }

    /// <summary>
    /// Load:
    /// �������ݲ��ҷ����л�Ϊʵ��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    private T LoadFromJsonFile<T>(string val)
    {
        // ���ļ���ȡ JSON �ַ���
        string jsonString = val;
        // �� JSON �ַ��������л�Ϊ����
        return JsonMapper.ToObject<T>(jsonString);
    }

    /// <summary>
    /// Get��
    /// ��ȡ�½ڴ浵
    /// </summary>
    /// <returns></returns>
    public List<LevelData> GetDataFile()
    {
        return GameBase.Instance.saveData.levelData;
    }

    /// <summary>
    /// ��ȡ��ǰ�ؿ��浵
    /// </summary>
    /// <returns></returns>
    public LevelData GetLevelData(int chapter, int level)
    {
        foreach (var item in GameBase.Instance.saveData.levelData)
        {
            if (item.chapter == chapter && item.level == level)
            {
                return item;
            }
        }
        return new LevelData();
    }

    /// <summary>
    /// Clear:
    /// ����ؿ��浵��������ɾ���浵
    /// </summary>
    /// <param name="chapter">�½�</param>
    /// <param name="level">�ؿ�</param>
    public void ClearLevelData(int chapter, int level) 
    {
        LevelData data = null;
        foreach (var item in GameBase.Instance.saveData.levelData)
        {
            if (item.chapter == chapter && item.level == level)
                data = item;
        }
        if (data == null)
            return;
        if(data.completedTask != null)
            data.completedTask.Clear();
        data.completed = false;
        if (data.levelWithModePositionDatas != null)
            data.levelWithModePositionDatas.Clear();
    }



}