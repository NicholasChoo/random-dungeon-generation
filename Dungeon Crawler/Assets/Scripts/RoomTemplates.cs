using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bRoom;
	public GameObject[] tRoom;
	public GameObject[] lRoom;
	public GameObject[] rRoom;
	public GameObject[] spawnRoom;
	public GameObject[] bEndRoom;
	public GameObject[] tEndRoom;
	public GameObject[] lEndRoom;
	public GameObject[] rEndRoom;

	public float waitTime;
	public GameObject closedRoom;
	private bool spawnedBoss;
	public GameObject boss;

	public int maxRooms;
	public List<GameObject> rooms;
	public int listSize;

	void Update()
	{
		listSize = rooms.Count;
		if (waitTime <= 0 && spawnedBoss == false)
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if (i == rooms.Count - 1)
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		}
		else
		{
			waitTime -= Time.deltaTime;
		}
	}
}
