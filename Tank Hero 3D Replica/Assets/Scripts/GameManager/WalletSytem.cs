using System;
using UnityEngine;

public class WalletSytem : MonoBehaviour
{
   private GameDataManager GameDataManager;

   private void Awake()
   {
      GameDataManager = GetComponent<GameDataManager>();
   }


   public void IncreaseMoney(int IncreasIndex)
   {
      GameDataManager.GameData.Money += IncreasIndex;
      GameDataManager.Save();
   }

   public void ReduceMoney(int reduceIndex)
   {
      GameDataManager.GameData.Money -= reduceIndex;
      GameDataManager.Save();
   }
}
