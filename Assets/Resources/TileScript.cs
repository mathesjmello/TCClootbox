﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool walkable = true;
    public bool currentTile = false;
    public bool target = false;
    public bool selectable = false;

    public List<TileScript> proximityList = new List<TileScript>();

    // Breadth First Search (BFS)
    public bool visited = false;
    public TileScript parent = null;
		public int distance = 0;


    void Start()
    {
        
    }

    void Update()
    {
    	if(currentTile)
    	{
    		GetComponent<Renderer>().material.color = Color.magenta;
    	}
    	else if (target) {
    		GetComponent<Renderer>().material.color = Color.green;
    	}
    	else if (selectable) {
    		GetComponent<Renderer>().material.color = Color.red;
    	}
    	else {
    		GetComponent<Renderer>().material.color = Color.white;	
    	}
    }

    public void Reset() 
    {
    	proximityList.Clear();

    	currentTile = false;
    	target = false;
    	selectable= false;

    	visited = false;
    	parent = null;
    	distance = 0;
    }

    public void FindNear(float jumpHeight)
    {
    	Reset();
    	CheckTile(Vector3.forward, jumpHeight);
    	CheckTile(-Vector3.forward, jumpHeight);
    	CheckTile(Vector3.right, jumpHeight);
    	CheckTile(-	Vector3.right, jumpHeight);
    }

    public void CheckTile(Vector3 direction, float jumpHeight)
    {
    	Vector3 jumpLimit = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
    	Collider[] colliders = Physics.OverlapBox(transform.position + direction, jumpLimit);

    	foreach (Collider item in colliders)
    	{
    		TileScript tile = item.GetComponent<TileScript>();
    		if ( tile != null && tile.walkable )
    		{
    			RaycastHit hit;
    			if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
    			{
    				proximityList.Add(tile);	
    			}
    		}
    	}
    }
}
