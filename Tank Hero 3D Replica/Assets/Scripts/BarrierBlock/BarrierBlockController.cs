using System;
using UnityEngine;
using UnityEngine.UI;

public class BarrierBlockController : MonoBehaviour
{
   private GameSceneInterfaceController _gameSceneInterfaceController;
   private GameDataManager _gameDataManager;
   
   [HideInInspector]public float BarrierBlockValue;
   private float Health;

   private void Awake()
   {
      _gameSceneInterfaceController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSceneInterfaceController>();
      _gameDataManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameDataManager>();
   }

   public void SetHealth(float HealthIndex)
   {
      this.BarrierBlockValue = HealthIndex;
      this.Health = this.BarrierBlockValue;
      Text HealthText =gameObject.transform.GetChild(0).transform.GetChild(0).gameObject .GetComponent<Text>();
      HealthText.text = Convert.ToString(this.Health);
   }

   public void ReduceHealth(float reduceIndex)
   {
      this.Health -= reduceIndex;
      Text HealthText =gameObject.transform.GetChild(0).transform.GetChild(0).gameObject .GetComponent<Text>();
      HealthText.text = Convert.ToString(this.Health);
      CheckHealth();
   }

   public void CheckHealth()
   {
      if (this.Health <= 0)
      {
         GameObject.FindGameObjectWithTag("GameManager").GetComponent<WalletSytem>().IncreaseMoney(Convert.ToInt16(BarrierBlockValue));
         _gameSceneInterfaceController.WriterText(_gameSceneInterfaceController.MoneyText,_gameDataManager.GameData.Money);
         gameObject.SetActive(false);
      }
   }
}
