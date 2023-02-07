using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.IO;
using ExcelDataReader;
using TMPro;

public class LanguageManager : FieldObjectSingleton<LanguageManager>
{
    public string filePath;
    public string csvfilePath;
    public string nowLanguage;

    private Dictionary<string, Dictionary<string, string>> languageData 
        = new Dictionary<string, Dictionary<string, string>>();

    public void Start()
    {
        StartCoroutine(runLoadData());
    }

    private void Update()
    {
        //text.text = Application.streamingAssetsPath + filePath + "\n" + loadSuccess;
    }

    public IEnumerator runLoadData()
    {
        //,자 형식으로 저장된 csv파일을 읽는다.
        TextAsset textAsset = Resources.Load<TextAsset>(csvfilePath);
        if (textAsset == null)
            yield break;

        //줄을 나눈다.
        string[] rows = textAsset.text.Split('\n');
        List<string> rowList = new List<string>();
        for (int i = 0; i < rows.Length; i++)
        {
            if (string.IsNullOrEmpty(rows[i]))
            {
                //아무것도 없는 객체
                continue;
            }
            string row = rows[i].Replace("\r", string.Empty);
            row = row.Trim();
            rowList.Add(rows[i]);
        }

        //제목줄
        string[] subjects = rowList[0].Split(',');

        for (int r = 1; r < rowList.Count; r++)
        {
            //해당 줄부터 데이터다.
            string[] values = rowList[r].Split(',');

            //키값을 얻는다.
            string keyValue = values[0].Replace('\r', ' ').Trim();

            for (int c = 1; c < values.Length; c++)
            {
                //해당칸의 언어를 가져온다.
                subjects[c] = subjects[c].Replace('\r', ' ').Trim();
                string language = subjects[c];
                if (languageData.ContainsKey(language) == false)
                    languageData.Add(language, new Dictionary<string, string>());

                //값을반환한다.
                values[c] = values[c].Replace('\r', ' ').Trim();

                //언어데이터를 추가한다.
                languageData[language].Add(keyValue, values[c]);
            }
        }
        yield break;
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
        {
            string str = "";
            string str2 = instance.languageData[instance.nowLanguage][pKey];
            //for (int i = 0; i < str2.Length; i++)
            //{
            //    if(i+1<str2.Length)
            //    {
            //        if(str2[i] == "\\" && str2)
            //    }
            //}

            return instance.languageData[instance.nowLanguage][pKey].Replace("\\n", "\n"); ;
        }
        return string.Empty;
    }
}
