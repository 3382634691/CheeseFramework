using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameTest : MonoBehaviour
{

    private void Start()
    {
		//PythonScriptRun.RunPythonScript(@"UnityLoad.py");\
		CmdCtr();

	}
     private void CmdCtr()
    {
        //���е�cmdstr�ŵ�������Ҫ���õ�����
        ProcessCommand("cmd.exe", "python UnityLoad.py");
    }

	public static void ProcessCommand(string command, string argument)
	{
		//UnityEngine.Debug.Log(argument);
		ProcessStartInfo info = new ProcessStartInfo(command);
		//����Ӧ�ó���ʱҪʹ�õ�һ�������в�����
		//���Ƕ���cmd��˵��������Ч�ģ���������ΪUseShellExecute��ֵ����Ϊfalse��
		//���Ƕ���svn�ĳ���TortoiseProc.exe�ǿ���ʹ�õ�һ������
		//info.Arguments = argument;
		//�Ƿ񵯴�
		info.CreateNoWindow = true;
		//��ȡ������ָʾ������������ʱ�Ƿ����û���ʾ����Ի����ֵ��
		info.ErrorDialog = true;
		//��ȡ������ָʾ�Ƿ�ʹ�ò���ϵͳ shell �������̵�ֵ��
		info.UseShellExecute = false;

		if (info.UseShellExecute)
		{
			info.RedirectStandardOutput = false;
			info.RedirectStandardError = false;
			info.RedirectStandardInput = false;
		}
		else
		{
			info.RedirectStandardOutput = true; //��ȡ������ָʾ�Ƿ�Ӧ�ó���Ĵ������д�� StandardError ���е�ֵ��
			info.RedirectStandardError = true; //��ȡ������ָʾ�Ƿ�Ӧ�ó���Ĵ������д�� StandardError ���е�ֵ��
			info.RedirectStandardInput = true;//��ȡ������ָʾӦ�ó���������Ƿ�� StandardInput ���ж�ȡ��ֵ��
			info.StandardOutputEncoding = System.Text.Encoding.UTF8;
			info.StandardErrorEncoding = System.Text.Encoding.UTF8;
		}
		//����(������)�� Process ����� StartInfo ����ָ���Ľ�����Դ��������������������
		Process process = Process.Start(info);
		//StandardInput����ȡ����д��Ӧ�ó������������
		//���ַ�����д���ı������������ֹ����
		process.StandardInput.WriteLine(argument);
		//��ȡ������һ��ֵ����ֵָʾ StreamWriter ��ÿ�ε��� Write(Char) ֮���Ƿ񶼽��仺����ˢ�µ���������
		process.StandardInput.AutoFlush = true;

		if (!info.UseShellExecute)
		{
			UnityEngine.Debug.Log(process.StandardOutput);
			UnityEngine.Debug.Log(process.StandardError);
		}
		//�ر�
		process.Close();
	}


	// Update is called once per frame
	void Update()
    {
		
    }
}
