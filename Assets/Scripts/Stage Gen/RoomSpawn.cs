using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * file: RoomSpawn.cs
 * author: Brian Song
 * class: CS 4700 - Game Development
 * 
 * assignment: Program 4
 * date last modified: 10/31/2022
 * 
 * purpose: This script generates a random array that will be used to create a randomly generated stage
 * value of input: The result returns and array
 */
public class RoomSpawn: MonoBehaviour
{
    public int openingDir; //1 - bottom door; 2 - top door; 3 - left door; 4 - right door required

    private RoomTemplate templates; //will add to room templates arrays in initalization
    private bool spawned = false;   //whether the rooms have been spawned or not

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("SpawnRoom", 0.1f);
    }

    public void SpawnRoom() {
        if (!spawned) {
            int rand;
            switch (openingDir) {
                case 1:
                    //Spawn room with a bottom door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation, transform.root);
                    break;
                case 2:
                    //Spawn room with a top door
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation, transform.root);
                    break;
                case 3:
                    //Spawn room with a left door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation, transform.root);
                    break;
                case 4:
                    //Spawn room with a right door
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation, transform.root);
                    break;
            }
            spawned = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("SpawnPoint")) {
            if (!other.GetComponent<RoomSpawn>().spawned && !spawned && !other.transform.parent.CompareTag("Entry")) {
                //spawn walls to block any openings 
                switch (openingDir) {
                    case 1:
                        Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation, transform.root);
                        break;
                    case 2:
                        Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation, transform.root);
                        break;
                    case 3:
                        Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation, transform.root);
                        break;
                    case 4:
                        Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation, transform.root);
                        break;
                }
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
