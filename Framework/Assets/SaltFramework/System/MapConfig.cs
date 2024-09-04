using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MapConfig : Manager<MapConfig>
{
    // Tip: NPC��Transform
    public Transform npcsTrans;

    // Tip: ģ�͵�Transform
    public Transform modelsTrans;

    // Tip: ����Ч����Transform
    public Transform particleTrans;

    //Tip: ��������
    public Transform landTran;

    // Tip: NPC���ַ�����ʶ
    private const string npcTr = "Npc";

    // Tip: ����ģ�͵��ַ�����ʶ
    private const string sceneTr = "SceneModel";

    // Tip: ����Ч�����ַ�����ʶ
    private const string particleTr = "Particle";

    //Tip: �����λ��
    private const string landTrName = "Land";

    // Tip: ��ͼ��������
    private MapConfigData configData;

    //Tip: ��ʱ����༭��Npc�����ݴ�������������ʱ����༭��ʱ����
    private Dictionary<int, Transform> tempEditNpcs = new Dictionary<int, Transform>();

    //Tip: ��ʱ����༭��Npc�����ݴ�������������ʱ����༭��ʱ����
    private Dictionary<int, Transform> tempEditModel = new Dictionary<int, Transform>();

    /// <summary>
    /// Init:
    /// ��ʼ������
    /// </summary>
    public void InitData()
    {
        npcsTrans = GameObject.Find(npcTr)?.transform;
        modelsTrans = GameObject.Find(sceneTr)?.transform;
        particleTrans = GameObject.Find(particleTr)?.transform;
        landTran = GameObject.Find(landTrName)?.transform;
    }





    public MapDialogData Getmapdialogdatas(Transform item, ItemBase npc)
    {

        return null;
    }


    // �ݹ鷽����ȡ�������������Ϣ
    DecryptObjectData[] GetChildModels(Transform parent)
    {
        List<DecryptObjectData> childDataList = new List<DecryptObjectData>();

        foreach (Transform child in parent)
        {
            var childData = new DecryptObjectData
            {
                x = child.localPosition.x,
                y = child.localPosition.y,
                z = child.localPosition.z,
                scalex = child.localScale.x,
                scaley = child.localScale.y,
                scalez = child.localScale.z,
                rotatex = child.localEulerAngles.x,
                rotatey = child.localEulerAngles.y,
                rotatez = child.localEulerAngles.z,
            };

            childDataList.Add(childData);
        }

        return childDataList.ToArray();
    }


    /// <summary>
    /// Save:
    /// ���泡����������
    /// </summary>
    private void SavePartitleData()
    {
        var data = Getmapparticledatas();
        if (data == null)
            return;
        configData.mapparticledatas = data;
    }

    /// <summary>
    /// Save:
    /// ���泡����������
    /// </summary>
    private void SaveLandData()
    {
        var data = Getmaplanddata();
        if (data == null)
            return;
        configData.maplanddata = data;
    }

    /// <summary>
    /// Get:
    /// ��ȡ������������
    /// </summary>
    /// <returns></returns>
    public List<MapParticleData> Getmapparticledatas()
    {
        var datas = new List<MapParticleData>();
        if (particleTrans == null)
        {
            Debug.LogError("Npc Transform not found.");
            return null;
        }
        for (int i = 0; i < particleTrans.childCount; i++)
        {
            var item = particleTrans.GetChild(i);
            var npc = item.GetComponent<ParticleBase>();
            var data = new MapParticleData();
            data.x = item.localPosition.x;
            data.y = item.localPosition.y;
            data.z = item.localPosition.z;
            data.scalex = item.localScale.x;
            data.scaley = item.localScale.y;
            data.scalez = item.localScale.z;
            data.rotatex = item.localEulerAngles.x;
            data.rotatey = item.localEulerAngles.y;
            data.rotatez = item.localEulerAngles.z;
            data.ID = npc?.ID ?? 0;
            datas.Add(data);
        }
        return datas;
    }




    /// <summary>
    /// Get:
    /// ��ȡ������������
    /// </summary>
    /// <returns></returns>
    public MapLandData Getmaplanddata()
    {
        var data = new MapLandData();
        if (landTran == null)
        {
            Debug.LogError("Land Transform not found.");
            return null;
        }
        data.x = landTran.localPosition.x;
        data.y = landTran.localPosition.y;
        data.z = landTran.localPosition.z;
        data.scalex = landTran.localScale.x;
        data.scaley = landTran.localScale.y;
        data.scalez = landTran.localScale.z;
        data.rotatex = landTran.localEulerAngles.x;
        data.rotatey = landTran.localEulerAngles.y;
        data.rotatez = landTran.localEulerAngles.z;

        var decryptObjs = landTran.GetChildFromName("DecryptObject", true);
        if (decryptObjs != null && decryptObjs.Length > 0)
        {
            var list = new DecryptObjectData[decryptObjs.Length];
            data.decryptObjectdatas = list; 
        }

        return data;
    }

}
