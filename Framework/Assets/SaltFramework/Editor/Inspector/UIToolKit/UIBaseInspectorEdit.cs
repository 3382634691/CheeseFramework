using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(UIBaseInspector))]
public class UIBaseInspectorEdit : Editor
{
    public TextField textfield;
    public Button ModelBtn;
    public Button createBtn;
    UIBaseInspector uiBaseInspector;
    static bool isCreate = false;
    static string uiName = "UIBase";
    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Inspector/UIToolKit/UibaseTemplateKit.uxml");
        visualTree.CloneTree(root);
        uiBaseInspector = target as UIBaseInspector;
        textfield = root.Q<TextField>("uiName");
        ModelBtn = root.Q<Button>("ModelBtn");
        ModelBtn.clickable.clicked += ModelOnclick();
        createBtn = root.Q<Button>("createBtn");
        createBtn.clickable.clicked += CreateOnClick();
        textfield.RegisterValueChangedCallback(OnTextFieldValueChanged);
        Init();
        
        EditorApplication.hierarchyChanged += OnHierarchyChanged;
        return root;
    }

    private void OnTextFieldValueChanged(ChangeEvent<string> evt)
    {
        uiBaseInspector.name = evt.newValue;
    }

    public void OnHierarchyChanged()
    {
        Init();
    }


    private Action CreateOnClick()
    {
        return () =>{
            if (textfield.value != null && textfield.value != "")
            {
                CreateScriptFile(textfield.value);
                //SaveAsPrefab(uiBaseInspector.gameObject, textfield.value);
            }
        };
    }

    private Action ModelOnclick()
    {
        return () =>
        {
            GameObject obj = Resources.Load<GameObject>("System/UIBaseModel");
            obj = GameObject.Instantiate(obj);
            obj.name = "UIBaseModel";
            GameObjectUtility.SetParentAndAlign(obj, uiBaseInspector.gameObject);
        };
    }

    public void Init()
    {
        textfield.value = uiBaseInspector.name;
        uiName = uiBaseInspector.name;
    }

    public void CreateScriptFile(string newName)
    {
        string scriptPath = "Assets/Scripts/UI/" + newName + ".cs";
        uiName = newName;
        EditorPrefs.SetString("UIBaseData", uiName);
        if (!File.Exists(scriptPath))
        {
            string templatePath = "Assets/Scripts/Framework/Common/UIBase/UIBaseTemplate.text";
            string templateContent = File.ReadAllText(templatePath);
            templateContent = templateContent.Replace("{0}", newName);
            File.WriteAllText(scriptPath, templateContent);
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogWarning("�ű��ļ��Ѵ��ڣ�" + scriptPath);
        }
    }

    [DidReloadScripts]
    static void OnDidReloadScripts()
    {
        var bindScripts = EditorPrefs.GetString("UIBaseData");
        if (string.IsNullOrEmpty(bindScripts))
            return;
        System.Type newScriptType = GetScriptType(bindScripts);
        GameObject createObj = null;
        createObj = GameObject.Find(bindScripts);
        if (createObj != null)
        {
            EditorPrefs.SetString("UIBaseData", "");
            if (createObj.GetComponent(newScriptType) == null)
                createObj.AddComponent(newScriptType);
            SaveAsPrefab(createObj, bindScripts);
        }
        else
        {
            DebugEX.Log("Not Find", bindScripts);
        }
    }

    static void SaveAsPrefab(GameObject obj, string uiName)
    {
        // ѡ�񱣴�·��
        string prefabPath = "Assets/Resources/UI/" + uiName + ".prefab";
        // ����Ƿ��Ѵ���ͬ����Ԥ����
        if (AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)))
        {
            // ����Ѵ���ͬ��Ԥ���壬��ʾ���˳�
            if (!EditorUtility.DisplayDialog("��ʾ", "�Ѵ���ͬ��Ԥ���壬�Ƿ��滻��", "��", "��"))
            {
                return;
            }
        }
        obj.name = uiName;
        if(obj.GetComponent<UIBaseInspector>() != null)
            DestroyImmediate(obj.GetComponent<UIBaseInspector>());
        // ����ΪԤ����
        GameObject prefab = PrefabUtility.SaveAsPrefabAssetAndConnect(obj, prefabPath, InteractionMode.UserAction);
        //PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);

        DebugEX.LogFrameworkMsg("����UI�ɹ�", uiName);
        //DestroyImmediate(obj);
        // ˢ��AssetDatabase��ʹ�´�����Ԥ������Unity�пɼ�
        AssetDatabase.Refresh();
    }

  

    static System.Type GetScriptType(string scriptName)
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
}
