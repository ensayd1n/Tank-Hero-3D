using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    public GameData GameData;

    private void Awake()
    {
        Load();
        Time.timeScale = 1;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(GameData,true);
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", json);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameData.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
            GameData = JsonUtility.FromJson<GameData>(json);
        }
        else if(!File.Exists(Application.persistentDataPath + "/GameData.json"))
        {
            ClearData();
        }
    }

    public void ClearData()
    {
        GameData.Level = 1;
        GameData.Money = 0;
        GameData.AmmoFireDuration = 1;
        GameData.AmmoDamageValueLevel = 1;
        GameData.AmmoDamageValue = 1;
        GameData.AmmoFireDurationLevel = 1;
        GameData.AmmoFireDurationLevelPrice = 20;
        GameData.AmmoFireDamageValueLevelPrice = 20;
        GameData.BarrierBlockMinimumIndex = 1;
        GameData.BarrierBlockMaximumIndex = 5;
        Save();
    }
}
