using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BarrierBlockInstantiateController : MonoBehaviour
{
    private GameDataManager _gameDataManager;
    
    private GameObject[] BarrierBlockInstantiateTransforms = new GameObject[1];
    private GameObject[] InstantiatedBarrierBlock = new GameObject[1];
    
    [Header("Input Values")] 
    public Color[] Colors;

    private GameObject _barrierBlock;

    private void Awake()
    {
        _gameDataManager = GetComponent<GameDataManager>();
        BarrierBlockInstantiateTransforms = GameObject.FindGameObjectsWithTag("BlockInstantiateTransform");
        _barrierBlock = Resources.Load<GameObject>("Prefabs/BarrierBlock");
    }

    private void Start()
    {
        InstantiateBlock();
    }

    private void InstantiateBlock()
    {
        for (int i = 0; i < BarrierBlockInstantiateTransforms.Length; i++)
        {
            int randomIndex = Random.Range(_gameDataManager.GameData.BarrierBlockMinimumIndex, _gameDataManager.GameData.BarrierBlockMaximumIndex);
            for (int j = 0; j < InstantiatedBarrierBlock.Length; j++)
            {
                if (InstantiatedBarrierBlock[j]!=null &&InstantiatedBarrierBlock[j].activeSelf==false)
                {
                    GameObject obj = InstantiatedBarrierBlock[j];
                    obj.SetActive(true);
                    obj.transform.position = new Vector3(BarrierBlockInstantiateTransforms[i].transform.position.x, 0F,
                        BarrierBlockInstantiateTransforms[i].transform.position.z);
                    obj.GetComponent<BarrierBlockController>().SetHealth(randomIndex);
                    int randomIndex2 = Random.Range(0, Colors.Length);
                    obj.GetComponent<Renderer>().material.color = Colors[randomIndex2];
                    break;
                }
                if(j==InstantiatedBarrierBlock.Length-1)
                {
                    GameObject obj =  Instantiate(_barrierBlock, new Vector3(BarrierBlockInstantiateTransforms[i].transform.position.x, 0F,
                            BarrierBlockInstantiateTransforms[i].transform.position.z),
                        Quaternion.identity);
                    obj.GetComponent<BarrierBlockController>().SetHealth(randomIndex);
                    InstantiatedBarrierBlock = InstantiatedBarrierBlock.Concat(new GameObject[]{obj}).ToArray();
                    int randomIndex2 = Random.Range(0, Colors.Length);
                    obj.GetComponent<Renderer>().material.color = Colors[randomIndex2];
                    break;
                }
            }
        }
    }
}
