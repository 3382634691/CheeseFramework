using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ImportFileEdit : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;
    public List<string> items = new List<string>();
    public Label fileLabel;
    public string fileName;
    public int fileType;
    public string selectName;
    //VisualElement root;
    [MenuItem("Window/ImportFileEdit")]
    public static void ShowExample()
    {
        Rect _rect = new Rect(0, 0, 400, 150);
        ImportFileEdit window = (ImportFileEdit)EditorWindow.GetWindowWithRect(typeof(ImportFileEdit), _rect, true, "��Դ����");
        window.Show();
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UIToolKit/ImportFileEdit.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);
        fileLabel = root.Q<Label>("FileName");

        var yesBtn = root.Q<Button>("YesBtn");
        var cancelBtn = root.Q<Button>("CancelBtn");
        yesBtn.clicked += () =>
        {
            CheckFile();
            Close();
        };
        cancelBtn.clicked += () =>
        {
            Close();
        };
        // ���������б�DropDown��
        DropdownField dropdown = root.Q<DropdownField>("type");
        items = new List<string>();
        if (fileType == 1)
        {
            items.Add("None");
            items.Add("Effect");
            items.Add("Music");
        }
        else
        {
            items.Add("None");
            items.Add("Effect");
            items.Add("Music");
            items.Add("Material");
            items.Add("Sprite");
            items.Add("Model");
        }
        
        dropdown.choices = items;
        dropdown.value = items[fileType];
        selectName = items[fileType];
        dropdown.RegisterValueChangedCallback(evt =>
        {
            DropValueChanged(evt.newValue);
        });
        fileLabel.text = Path.GetFileName(fileName);


        var iconItem = root.Q<VisualElement>("icon");
        Texture2D texture = null;
        if (selectName == "Effect" || selectName == "Music")
            texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/UIToolKit/Icon/import2.png");
        else if (selectName == "Material")
            texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/UIToolKit/Icon/import4.png");
        else if (selectName == "Sprite")
            texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/UIToolKit/Icon/import1.png");
        else
            texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/UIToolKit/Icon/import3.png");

        iconItem.style.backgroundImage = texture;


    }


    public void DropValueChanged(string val)
    {
        selectName = val;
    }

    public void CheckFile()
    {
        var val = selectName;
        var triggerPath = "";
        if (val == "Effect")
            triggerPath = "Resources/Audio/Effect";
        else if (val == "Music")
            triggerPath = "Resources/Audio/Music";
        else if (val == "Material")
            triggerPath = "GameResource/Materials";
        else if (val == "Sprite")
            triggerPath = "GameResource/Sprites";
        else if (val == "Model")
            triggerPath = "GameResource/Model";
        FileMove(fileName, triggerPath);
    }

    public void FileMove(string assetPath,string triggerAssetPath)
    {
        string orginPath = assetPath;
        string newPath ="Assets/"+ triggerAssetPath+"/"+Path.GetFileName(assetPath);
        //DebugEX.LogSuccess("�ļ�����ɹ�",newPath);
        DebugEX.LogFrameworkMsg("�ļ��ѱ��Զ�����", newPath);
        AssetDatabase.MoveAsset(orginPath, newPath);
        AssetDatabase.MoveAsset(orginPath+".meta", newPath+".meta");
        // ������·��
        //������Ҫѡ�е��ļ�/�ļ���
        Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath<Object>(newPath);
        //��Project����Ǹ�����ʾ
        UnityEditor.EditorGUIUtility.PingObject(obj);
        //��Project����Զ�ѡ�У�����Inspector�����ʾ����
        UnityEditor.Selection.activeObject = obj;
        AssetDatabase.Refresh();

        Texture2D selectedTexture = Selection.activeObject as Texture2D;
        if (selectedTexture == null)
        {
            Debug.LogWarning("No texture selected.");
            return;
        }

        string texturePath = AssetDatabase.GetAssetPath(selectedTexture);
        if (string.IsNullOrEmpty(texturePath))
        {
            Debug.LogWarning("Selected object is not a texture asset.");
            return;
        }
        TextureImporter textureImporter = AssetImporter.GetAtPath(texturePath) as TextureImporter;
        if (textureImporter == null)
        {
            Debug.LogWarning("Failed to get TextureImporter.");
            return;
        }

        textureImporter.textureType = TextureImporterType.Sprite;
        textureImporter.SaveAndReimport(); // ���沢���µ�������

    }

    public void InitFile(string fileName, int filetype)
    {
        this.fileName = fileName;
        this.fileType = filetype;
        //fileLabel.text = fileName;
    }
}
