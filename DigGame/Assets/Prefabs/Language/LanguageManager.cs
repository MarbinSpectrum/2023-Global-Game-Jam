using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.IO;
using ExcelDataReader;

public class LanguageManager : FieldObjectSingleton<LanguageManager>
{
    public string filePath;
    public string nowLanguage;

    private Dictionary<string, Dictionary<string, string>> languageData 
        = new Dictionary<string, Dictionary<string, string>>();

    public void Start()
    {
        StartCoroutine(runLoadData());
    }

    public IEnumerator runLoadData()
    {
        var textAsset = Resources.Load(filePath);

        string data = File.ReadAllText(Application.dataPath + "/Resources/DigGameLanguage.xlsx");

        {
            using(var stream = File.Open(Application.dataPath + filePath, FileMode.Open, FileAccess.Read,FileShare.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    for(int i = 0; i < result.Tables.Count; i++)
                    {
                        int C = result.Tables[i].Columns.Count;
                        int R = result.Tables[i].Rows.Count;

                        List<string> languageTag = new List<string>();
                        for (int j = 0; j < C; j++)
                            languageTag.Add(result.Tables[i].Rows[0][j].ToString().Replace('\r', ' ').Trim());
                        List<string> KeyTag = new List<string>();
                        for (int j = 0; j < R; j++)
                            KeyTag.Add(result.Tables[i].Rows[j][0].ToString().Replace('\r', ' ').Trim());

                        for (int j = 1; j < R; j++)
                        {
                            for (int k = 1; k < C; k++)
                            {
                                string language = languageTag[k];
                                if (languageData.ContainsKey(language) == false)
                                    languageData.Add(language, new Dictionary<string, string>());
                                string keyValue = KeyTag[j];
                                string valueData = result.Tables[i].Rows[j][k].ToString().Replace('\r', ' ').Trim();
                                languageData[language].Add(keyValue, valueData);
                            }
                        }
                    }
                }
            }


            yield break;

        }
    }

    public static string GetText(string pKey)
    {
        if (instance.languageData.ContainsKey(instance.nowLanguage) == false)
            return string.Empty;
        if(instance.languageData[instance.nowLanguage].ContainsKey(pKey))
            return instance.languageData[instance.nowLanguage][pKey];
        return string.Empty;
    }
}
