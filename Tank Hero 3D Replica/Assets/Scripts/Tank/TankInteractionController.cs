using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInteractionController : MonoBehaviour
{
    private GameDataManager _gameDataManager;
    private GameSceneInterfaceController _gameSceneInterfaceController;

    private void Start()
    {
        _gameDataManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameDataManager>();
        _gameSceneInterfaceController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSceneInterfaceController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BarrierBlock") && other.gameObject.activeSelf!=false)
        {
            _gameSceneInterfaceController.DieButton.SetActive(true);
            Time.timeScale = 0;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            _gameDataManager.GameData.Level += 1;
            _gameDataManager.GameData.BarrierBlockMinimumIndex *= _gameDataManager.GameData.Level;
            _gameDataManager.GameData.BarrierBlockMaximumIndex *= _gameDataManager.GameData.Level;
            _gameDataManager.Save();
            Time.timeScale = 0;
            _gameSceneInterfaceController.WonButton.SetActive(true);
        }
    }
}
