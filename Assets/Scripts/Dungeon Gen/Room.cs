using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int width;
    public int height;
    public int x;
    public int y;

    private bool updatedDoors = false;

    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;
    public List<Door> doors = new List<Door>();

    private void Start(){
        //pressed play in wrong scene
        if (RoomController.instance == null) {
            Debug.Log("You pressed play in the wrong scene");
            return;
        }

        Door[] ds = GetComponentsInChildren<Door>();
        foreach (Door d in ds) {
            doors.Add(d);
            switch (d.doorType) {
                case Door.DoorType.right:
                    rightDoor = d;
                    break;
                case Door.DoorType.left:
                    leftDoor = d;
                    break;
                case Door.DoorType.top:
                    topDoor = d;
                    break;
                case Door.DoorType.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        RoomController.instance.RegisterRoom(this);
    }

    private void Update() {
        if (name.Contains("End") && !updatedDoors) {
            RemoveUnconnectedDoors();
            updatedDoors = true;
        }
    }

    public void RemoveUnconnectedDoors() {
        foreach(Door door in doors) {
            switch (door.doorType) {
                case Door.DoorType.right:
                    if (GetRight() == null) {
                        //door.gameObject.SetActive(false);
                        door.GetComponent<SpriteRenderer>().enabled = false;
                        door.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    break;
                case Door.DoorType.left:
                    if (GetLeft() == null) {
                        door.GetComponent<SpriteRenderer>().enabled = false;
                        door.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    break;
                case Door.DoorType.top:
                    if (GetTop() == null) {
                        door.GetComponent<SpriteRenderer>().enabled = false;
                        door.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    break;
                case Door.DoorType.bottom:
                    if (GetBottom() == null) {
                        door.GetComponent<SpriteRenderer>().enabled = false;
                        door.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    break;
            }
        }
    }

    public Room GetRight() {
        if (RoomController.instance.RoomExist(x+1, y)) {
            return RoomController.instance.FindRoom(x+1, y);
        }
        return null;
    }

    public Room GetLeft() {
        if (RoomController.instance.RoomExist(x - 1, y)) {
            return RoomController.instance.FindRoom(x - 1, y);
        }
        return null;
    }

    public Room GetTop() {
        if (RoomController.instance.RoomExist(x, y + 1)) {
            return RoomController.instance.FindRoom(x , y + 1);
        }
        return null;
    }

    public Room GetBottom() {
        if (RoomController.instance.RoomExist(x, y - 1)) {
            return RoomController.instance.FindRoom(x, y - 1);
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    public Vector3 GetRoomCenter() {
        return new Vector3(x * width, y * height);
    }
    
}
