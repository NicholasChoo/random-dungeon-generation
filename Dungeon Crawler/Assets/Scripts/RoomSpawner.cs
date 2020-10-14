using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;

	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;

	public float waitTime = 4f;

	void Start()
	{
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}

	void Spawn()
	{
		if (spawned == false)
		{
			while (templates.listSize < templates.maxRooms)
            {
				while (openingDirection == 1)
				{
					rand = Random.Range(0, templates.bRoom.Length);
					Instantiate(templates.bRoom[rand], transform.position, templates.bRoom[rand].transform.rotation);
					spawned = true;
					if (spawned == true)
                    {
						break;
                    }
				}
				System.Threading.Thread.Sleep(10);
				while (openingDirection == 2)
				{
					rand = Random.Range(0, templates.tRoom.Length);
					Instantiate(templates.tRoom[rand], transform.position, templates.tRoom[rand].transform.rotation);
					spawned = true;
					if (spawned == true)
					{
						break;
					}
				}
				System.Threading.Thread.Sleep(10);
				while (openingDirection == 3)
				{
					rand = Random.Range(0, templates.lRoom.Length);
					Instantiate(templates.lRoom[rand], transform.position, templates.lRoom[rand].transform.rotation);
					spawned = true;
					if (spawned == true)
					{
						break;
					}
				}
				System.Threading.Thread.Sleep(10);
				while (openingDirection == 4)
				{
					rand = Random.Range(0, templates.rRoom.Length);
					Instantiate(templates.rRoom[rand], transform.position, templates.rRoom[rand].transform.rotation);
					spawned = true;
					if (spawned == true)
					{
						break;
					}
				}
				System.Threading.Thread.Sleep(10);
				while (openingDirection == 5)
				{
					rand = Random.Range(0, templates.spawnRoom.Length);
					Instantiate(templates.spawnRoom[rand], transform.position, templates.spawnRoom[rand].transform.rotation);
					spawned = true;
					if (spawned == true)
					{
						break;
					}
				}
			}
			if (templates.listSize >= templates.maxRooms)
            {
				if (openingDirection == 1)
                {
					Instantiate(templates.bEndRoom[0], transform.position, templates.bEndRoom[0].transform.rotation);
				}
				else if (openingDirection == 2)
				{
					Instantiate(templates.tEndRoom[0], transform.position, templates.tEndRoom[0].transform.rotation);
				}
				else if (openingDirection == 3)
				{
					Instantiate(templates.lEndRoom[0], transform.position, templates.lEndRoom[0].transform.rotation);
				}
				else if (openingDirection == 4)
				{
					Instantiate(templates.rEndRoom[0], transform.position, templates.rEndRoom[0].transform.rotation);
				}
				spawned = true;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		if (other.CompareTag("SpawnPoint"))
		{
			if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
			{
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
			spawned = true;
		}
	}
}
