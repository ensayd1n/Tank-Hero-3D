using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneInterfaceController : MonoBehaviour
{
   private GameDataManager _gameDataManager;
   private TankComponentController _tankComponentController;
   public Text MoneyText;
   public GameObject SkillsPanel;
   public Button TankTurretSkill;
   public Button TankSideTurretSkill;
   public Button TankDroneSkill;
   public Button ShieldSkill;
   public GameObject DieButton;
   public GameObject WonButton;

   private void Awake()
   {
      _gameDataManager = GetComponent<GameDataManager>();
      _tankComponentController = GameObject.FindGameObjectWithTag("Tank").GetComponent<TankComponentController>();
   }

   private void Start()
   {
      WriterText(MoneyText,_gameDataManager.GameData.Money);

      StartCoroutine(ChoseSkillByTimer(10));
   }

   public void WriterText(Text textname,int index)
   {
         textname.GetComponent<Text>().text = Convert.ToString(index);
   }

   public void LoadScene(int loadSceneIndex)
   {
      _gameDataManager.Save();
      SceneManager.LoadScene(loadSceneIndex);
   }

   public void SkillsLevelController()
   {
      if (_tankComponentController.TankTurretLevel > 1)
      {
         TankTurretSkill.interactable = false;
      }
      if (_tankComponentController.TankSideTurretLevel>2)
      {
         TankSideTurretSkill.interactable = false;
      }
      if (_tankComponentController.TankDroneLevel>2)
      {
         TankDroneSkill.interactable = false;
      }

      if (_tankComponentController.Shield.activeSelf != false)
      {
         ShieldSkill.interactable = false;
      }
   }

   public void SelectedDroneButton()
   {
      switch (_tankComponentController.TankDroneLevel)
      {
         case 0: _tankComponentController.Drons[0].SetActive(true);
            break;
         case 1: _tankComponentController.Drons[0].SetActive(false);
            _tankComponentController.Drons[1].SetActive(true);
            break;
         case 2: _tankComponentController.Drons[0].SetActive(false);
            _tankComponentController.Drons[0].SetActive(false);
            _tankComponentController.Drons[2].SetActive(true);
            break;
      }

      _tankComponentController.TankDroneLevel++;
      Time.timeScale = 1;
   }
   public void SelectedBarrelButton()
   {
      switch (_tankComponentController.TankTurretLevel)
      {
         case 0: _tankComponentController.TankTurrets[0].SetActive(false);
            _tankComponentController.TankTurrets[1].SetActive(true);
            break;
         case 1: _tankComponentController.TankTurrets[1].SetActive(false);
            _tankComponentController.TankTurrets[2].SetActive(true);
            break;
      }

      _tankComponentController.TankTurretLevel++;
      Time.timeScale = 1;
   }
   public void SelectedSideBarrelButton()
   {
      switch (_tankComponentController.TankSideTurretLevel)
      {
         case 0: _tankComponentController.TankSideTurrets[0].SetActive(true);
            break;
         case 1: _tankComponentController.TankSideTurrets[0].SetActive(false);
            _tankComponentController.TankSideTurrets[1].SetActive(true);
            break;
         case 2: _tankComponentController.TankSideTurrets[0].SetActive(false);
            _tankComponentController.TankSideTurrets[0].SetActive(false);
            _tankComponentController.TankSideTurrets[2].SetActive(true);
            break;
      }

      _tankComponentController.TankSideTurretLevel++;
      Time.timeScale = 1;
   }
   public void SelectedShieldButton()
   {
      _tankComponentController.Shield.SetActive(true);
      Time.timeScale = 1;
   }

   private IEnumerator ChoseSkillByTimer(float time)
   {
      yield return new WaitForSeconds(time);
      SkillsLevelController();
      SkillsPanel.SetActive(true);
      Time.timeScale = 0;
      StartCoroutine(ChoseSkillByTimer(time));
   }
}
