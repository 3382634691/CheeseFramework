using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class EditorListener
{
    /*static EditorListener()
    {
        // ע�� SceneView.duringSceneGui �¼�
        //SceneView.duringSceneGui += OnSceneGUI;
        EditorApplication.update += Update;
    }

    private static void Update()
    {
        Event e = Event.current;
        //DebugEX.Log(e == null);
        //DebugEX.Log("update");
        if (Event.current != null && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.A)
        {
            DebugEX.Log("AAAA");
            //ExecuteYourFunction();
            Event.current.Use(); // ʹ�� Event.current.Use() ����ֹ�¼��������ط�ʹ��
        }

        // ʹ����ͨ�� Input.GetKeyDown Ҳ���Լ�ⰴ��
        if (Input.GetKeyDown(KeyCode.F8))
        {
            //ExecuteYourFunction();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DebugEX.Log("���A������");
        }
        *//*if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.A)
        {
            Debug.Log("����A����Window����а���....");
        }*//*
    }

    *//* private static void ExecuteYourFunction()
     {
         // �������������Ҫִ�еĴ���
         Debug.Log("F8 �������£�ִ�в���...");
         // ����������ִ������Ҫ���κβ���
     }*//*

     private static void OnSceneGUI(SceneView sceneView)
     {
         Event e = Event.current;
         if (e.type == EventType.KeyDown && e.keyCode == KeyCode.F8)
         {
             // ִ������Ҫ�Ĳ���
             //ExecuteYourFunction();
             // ʹ�� e.Use() ����ֹ�¼��������ط�ʹ��
             e.Use();
         }

         if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.A)
         {
             //Debug.Log("����A����Window����а���....");
         }
     }

     private static void ExecuteYourFunction()
     {
         // �������������Ҫִ�еĴ���
         Debug.Log("F8 �������£�ִ�в���...");
         // �������ִ��ĳ�����ܺ���
         // YourFunction();
     }*/
}
