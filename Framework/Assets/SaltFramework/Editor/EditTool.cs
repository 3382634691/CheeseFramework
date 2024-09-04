using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class EditTool 
{
    public static System.Type GetScriptType(string scriptName)
    {
        // ��ȡ�Ѽ��صĳ���
        Assembly[] assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            // ��ÿ�������в���ָ�����Ƶ�����
            System.Type type = assembly.GetType(scriptName);
            if (type != null)
            {
                // ����ҵ����ͣ��򷵻�
                return type;
            }
        }
        return null;
    }


    public static GameObject CreatePrefabToScene(string path, string name)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        obj = GameObject.Instantiate(obj);
        obj.name = name;
        return obj;
    }


}
