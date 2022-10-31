using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;    //Array of rooms with bottom door available
    public GameObject[] topRooms;       //Array of rooms with top door available
    public GameObject[] leftRooms;      //Array of rooms with left door available
    public GameObject[] rightRooms;     //Array of rooms with right door available

    public List<GameObject> rooms;

    public GameObject boss;             //Boss Icon to spawn

    public void SpawnBoss() {
        Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
    }
}
