using System.Collections.Generic;using UnityEngine;using Newtonsoft.Json;public class ModelCfg  {	public int ID { get; set; }	public int ResourceID { get; set; }	public string Path { get; set; }	 	public static string configName = "ModelCfg";	public static ModelCfg config { get; set; }	public static LanguageConfigData languageConfigData;	public string version { get; set; }	public List<ModelCfg> datas { get; set; }	public static ModelCfg Get(int id)	{		if (config == null)		{			config = ConfigManager.Instance.Readjson<ModelCfg>(configName);			languageConfigData = ConfigManager.Instance.ReadLanguageJson(configName);;		}		foreach (var item in config.datas)		{			if (item.ID == id)			{ 					return item;			}		}		return null;	}	public static List<ModelCfg> GetList()	{		if (config == null)		{			config= ConfigManager.Instance.Readjson<ModelCfg>(configName);		}		return config.datas;	}	public static string GetLangugeText(int id, Language language)	{		if (config == null)		{			config = ConfigManager.Instance.Readjson<ModelCfg>(configName);			languageConfigData = ConfigManager.Instance.ReadLanguageJson(configName);;		}		if (languageConfigData.languageItemDatas.ContainsKey(id))		{			foreach (var data in languageConfigData.languageItemDatas[id])			{				if (data.language == language)				return data.value;			}		}		return "";	}	}