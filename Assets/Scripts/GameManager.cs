﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region  singleton
    public static GameManager instance;
    #endregion

    public List<Item> itemList = new List<Item>();
    public List<Item> craftingRecipes = new List<Item>();

    public Transform canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentInfo = null;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    // [TESTE] - Adicionar Item no Inventário
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            InventoryManager.instance.AddItem(itemList[Random.Range(0, itemList.Count)]);
        }
    }

    public void OnCraftItemUse(CraftItemType itemType, int amount)
    {
        Debug.Log("Consumindo: " + itemType + "| Add amount: " + amount);
    }

    public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
    {
        if(currentInfo != null)
        {
            Destroy(currentInfo.gameObject);
        }
    }
}
