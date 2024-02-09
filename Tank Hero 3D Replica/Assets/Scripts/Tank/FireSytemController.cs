using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireSytemController : MonoBehaviour
{
    private GameDataManager GameDataManager;
    
    private GameObject[] InstantiatedAmmo = new GameObject[1];

    private GameObject[] Barrels = new GameObject[1];
    private GameObject[] LeftSideBarrels = new GameObject[1];
    private GameObject[] RightSideBarrels = new GameObject[1];
    
    private GameObject _ammo;

    private void Awake()
    {
        GameDataManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameDataManager>();
        _ammo = Resources.Load<GameObject>("Prefabs/Ammo");
    }

    private void Start()
    {
        StartCoroutine(InstantiateAmmoByTimer(GameDataManager.GameData.AmmoFireDuration));
    }

    private void InstantiateAmmo(float time)
    {
        Barrels = GameObject.FindGameObjectsWithTag("Barrel");
        LeftSideBarrels = GameObject.FindGameObjectsWithTag("LeftSideBarrel");
        RightSideBarrels = GameObject.FindGameObjectsWithTag("RightSideBarrel");
        //Barels
        for (int i = 0; i < Barrels.Length; i++)
        {
            for (int j = 0; j < InstantiatedAmmo.Length; j++)
            {
                GameObject obj = InstantiatedAmmo[j];
                if (InstantiatedAmmo[j] != null && obj.activeSelf == false)
                {
                    InstantiatedAmmo[j].SetActive(true);
                    obj.transform.parent = null;
                    InstantiatedAmmo[j].transform.position = Barrels[i].transform.position;
                    break;
                }
                else if (j == InstantiatedAmmo.Length - 1)
                {
                    GameObject obj2 = Instantiate(_ammo, Barrels[i].transform);
                    obj2.transform.parent = null;
                    InstantiatedAmmo = InstantiatedAmmo.Concat(new GameObject[] { obj2 }).ToArray();
                    break;
                }
            }
        }
        //LeftSideBarrels
        for (int i = 0; i < LeftSideBarrels.Length; i++)
        {
            for (int j = 0; j < InstantiatedAmmo.Length; j++)
            {
                GameObject obj = InstantiatedAmmo[j];
                if (InstantiatedAmmo[j] != null && obj.activeSelf == false)
                {
                    InstantiatedAmmo[j].SetActive(true);
                    obj.transform.parent = null;
                    InstantiatedAmmo[j].transform.position = LeftSideBarrels[i].transform.position;
                    break;
                }
                else if (j == InstantiatedAmmo.Length - 1)
                {
                    GameObject obj2 = Instantiate(_ammo, LeftSideBarrels[i].transform);
                    obj2.transform.parent = null;
                    InstantiatedAmmo = InstantiatedAmmo.Concat(new GameObject[] { obj2 }).ToArray();
                    break;
                }
            }
        }
        //RightSideBarrels
        for (int i = 0; i < RightSideBarrels.Length; i++)
        {
            for (int j = 0; j < InstantiatedAmmo.Length; j++)
            {
                GameObject obj = InstantiatedAmmo[j];
                if (InstantiatedAmmo[j] != null && obj.activeSelf == false)
                {
                    InstantiatedAmmo[j].SetActive(true);
                    obj.transform.parent = null;
                    InstantiatedAmmo[j].transform.position = RightSideBarrels[i].transform.position;
                    break;
                }
                else if (j == InstantiatedAmmo.Length - 1)
                {
                    GameObject obj2 = Instantiate(_ammo, RightSideBarrels[i].transform);
                    obj2.transform.parent = null;
                    InstantiatedAmmo = InstantiatedAmmo.Concat(new GameObject[] { obj2 }).ToArray();
                    break;
                }
            }
        }
        Array.Clear(Barrels, 0, Barrels.Length);
        foreach (GameObject brl in Barrels)
        {
            if (brl != null)
            {
                Destroy(brl);
            }
        }
        
        Array.Clear(LeftSideBarrels, 0, LeftSideBarrels.Length);
        foreach (GameObject brl in LeftSideBarrels)
        {
            if (brl != null)
            {
                Destroy(brl);
            }
        }
        
        Array.Clear(RightSideBarrels, 0, RightSideBarrels.Length);
        foreach (GameObject brl in RightSideBarrels)
        {
            if (brl != null)
            {
                Destroy(brl);
            }
        }
        StartCoroutine(InstantiateAmmoByTimer(time));
    }

    private IEnumerator InstantiateAmmoByTimer(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        InstantiateAmmo(time);
    }
}
