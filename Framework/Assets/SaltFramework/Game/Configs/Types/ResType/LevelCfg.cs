using System.Collections.Generic;using UnityEngine;using Newtonsoft.Json;public class LevelCfg  {	public int ID { get; set; }	public int Chapter { get; set; }	public int Level { get; set; }	public int[] Trigger { get; set; }	public bool Storymode { get; set; }	 	public static string configName = "LevelCfg";	public static LevelCfg config { get; set; }	public static LanguageConfigData languageConfigData;	public string version { get; set; }	public List<LevelCfg> datas { get; set; }	public static LevelCfg Get(int id)	{		if (config == null)		{			config = ConfigManager.Instance.Readjson<LevelCfg>(configName);			languageConfigData = ConfigManager.Instance.ReadLanguageJson(configName);;		}		foreach (var item in config.datas)		{			if (item.ID == id)			{ 					return item;			}		}		return null;	}	public static List<LevelCfg> GetList()	{		if (config == null)		{			config= ConfigManager.Instance.Readjson<LevelCfg>(configName);		}		return config.datas;	}	public static string GetLangugeText(int id, Language language)	{		if (config == null)		{			config = ConfigManager.Instance.Readjson<LevelCfg>(configName);			languageConfigData = ConfigManager.Instance.ReadLanguageJson(configName);;		}		if (languageConfigData.languageItemDatas.ContainsKey(id))		{			foreach (var data in languageConfigData.languageItemDatas[id])			{				if (data.language == language)				return data.value;			}		}		return "";	}	}