#if DouYin
using StarkSDKSpace;
#endif
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileTools
{
    // �����洢�ļ�ϵͳ
#if DouYin
    private static StarkFileSystemManager dyFileSystem;
    // �û����ݴ洢��·��
    public static string dyFilePath;
#endif
    public static void Init()
    {
#if DouYin
        DebugEX.LogError("webgl�ļ�ϵͳ��ʼ��");
        dyFileSystem = StarkSDK.API.GetStarkFileSystemManager();
        dyFilePath = StarkFileSystemManager.USER_DATA_PATH;
        DebugEX.LogError("webgl�ļ�ϵͳ��ʼ������");
#endif
    }

    public static string ReadAllText(string path)
    {
#if DouYin && !UNITY_EDITOR
        return dyFileSystem.ReadFileSync(path, "utf8");
#else

        return File.ReadAllText(path);
#endif
    }

    public static void Delete(string path)
    {
#if DouYin && !UNITY_EDITOR
        dyFileSystem.UnlinkSync(path);
#else

        File.Delete(path);
#endif
    }


    public static bool Exists(string path)
    {
#if DouYin && !UNITY_EDITOR
        return dyFileSystem.AccessSync(path);
#else

        return File.Exists(path);
#endif
    }

    public static void CreateDirectory(string path)
    {
#if DouYin && !UNITY_EDITOR
         dyFileSystem.MkdirSync(path);
#else

        Directory.CreateDirectory(path);
#endif
    }


    public static void WriteAllText(string path, string value)
    {
#if DouYin && !UNITY_EDITOR
        dyFileSystem.WriteFileSync(path,value);
#else

        File.WriteAllText(path, value);

#endif
    }


    //public static void tt() 
    //{

    //    dyFileSystem.GetSavedFileList();
    //}

}
