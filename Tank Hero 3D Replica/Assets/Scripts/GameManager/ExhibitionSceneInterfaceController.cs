using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExhibitionSceneInterfaceController : MonoBehaviour
{
    private GameDataManager _gameDataManager;
    private WalletSytem _walletSytem;
    
    public Text MoneyText;
    public Text IncreaseFireDurationLevelText;
    public Text IncreaseFireDurationLevelPriceText;
    public Text IncreaseFireDamageValueLevelText;
    public Text IncreaseFireDamageValueLevelPriceText;
    public Button IncreaseFireValueButton;
    public Button IncreaseFireDurationButton;

    private void Awake()
    {
        _gameDataManager = GetComponent<GameDataManager>();
        _walletSytem = GetComponent<WalletSytem>();
    }

    private void Start()
    { 
        WriterText(MoneyText,_gameDataManager.GameData.Money);
        WriterText(IncreaseFireDurationLevelText, _gameDataManager.GameData.AmmoFireDurationLevel);
        WriterText(IncreaseFireDamageValueLevelText, _gameDataManager.GameData.AmmoDamageValueLevel);
        WriterText(IncreaseFireDurationLevelPriceText,_gameDataManager.GameData.AmmoFireDurationLevelPrice);
        WriterText(IncreaseFireDamageValueLevelPriceText,_gameDataManager.GameData.AmmoFireDamageValueLevelPrice);
        ButtonForMoneyInteraction();
    }
    
    public void WriterText(Text textname,int index)
    {
        textname.GetComponent<Text>().text = Convert.ToString(index);
    }
    private void ButtonForMoneyInteraction()
    {
        if (_gameDataManager.GameData.Money < _gameDataManager.GameData.AmmoFireDurationLevelPrice)
        {
            IncreaseFireDurationButton.interactable = false;
        }
        if (_gameDataManager.GameData.Money < _gameDataManager.GameData.AmmoFireDamageValueLevelPrice)
        {
            IncreaseFireValueButton.interactable = false;
        }
    }
    public void IncreaserFireDurationLevelButton()
    {
        _gameDataManager.GameData.AmmoFireDurationLevel += 1;
        _gameDataManager.GameData.AmmoFireDuration -= 0.025F;
        _walletSytem.ReduceMoney(_gameDataManager.GameData.AmmoFireDurationLevelPrice);
        _gameDataManager.GameData.AmmoFireDurationLevelPrice *= _gameDataManager.GameData.AmmoFireDurationLevel;
        WriterText(MoneyText,_gameDataManager.GameData.Money);
        WriterText(IncreaseFireDurationLevelText, _gameDataManager.GameData.AmmoFireDurationLevel);
        WriterText(IncreaseFireDurationLevelPriceText,_gameDataManager.GameData.AmmoFireDurationLevelPrice);
        ButtonForMoneyInteraction();
        _gameDataManager.Save();
    }
    public void IncreaserAmmoDamageValueLevelButton()
    {
        _gameDataManager.GameData.AmmoDamageValueLevel += 1;
        _gameDataManager.GameData.AmmoDamageValue += 1F;
        _walletSytem.ReduceMoney(_gameDataManager.GameData.AmmoFireDamageValueLevelPrice);
        _gameDataManager.GameData.AmmoFireDamageValueLevelPrice *= _gameDataManager.GameData.AmmoDamageValueLevel;
        WriterText(MoneyText,_gameDataManager.GameData.Money);
        WriterText(IncreaseFireDamageValueLevelText, _gameDataManager.GameData.AmmoDamageValueLevel);
        WriterText(IncreaseFireDamageValueLevelPriceText,_gameDataManager.GameData.AmmoFireDamageValueLevelPrice);
        ButtonForMoneyInteraction();
        _gameDataManager.Save();
    }
    public void LoadScene(int loadSceneIndex)
    {
        _gameDataManager.Save();
        SceneManager.LoadScene(loadSceneIndex);
    }
}
