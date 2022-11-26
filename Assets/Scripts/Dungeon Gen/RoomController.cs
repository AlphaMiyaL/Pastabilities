using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class RoomInfo{
    public string name;
    public int x;
    public int y;
}

public class RoomController : MonoBehaviour
{
    public static RoomController instance;
    public List<Room> loadedRooms = new List<Room>();
    
    private string currentWorldName = "TopFloor";
    private RoomInfo currentLoadRoomData;
    private Room currRoom;
    private Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();
    private bool isLoadingRoom = false;
    private bool spawnedBossRoom = false;
    private bool updatedRooms = false;

    private void Awake() {
        instance = this;

    }

    private void Update() {
        UpdateRoomQueue();
    }

    private void UpdateRoomQueue() {
        if (isLoadingRoom) {
            return;
        }

        if (loadRoomQueue.Count == 0) {
            if (!spawnedBossRoom) {
                StartCoroutine(SpawnBossRoom());
            }
            else if (spawnedBossRoom && !updatedRooms) {
                foreach (Room room in loadedRooms) {
                    room.RemoveUnconnectedDoors();
                }
                UpdateRooms();
                updatedRooms = true;
            }
            return;
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
        
    }

    private IEnumerator SpawnBossRoom() {
        spawnedBossRoom = true;
        yield return new WaitForSeconds(0.5f);
        if (loadRoomQueue.Count == 0) {
            Room bossRoom = loadedRooms[loadedRooms.Count - 1];
            Vector2Int tempRoom = new Vector2Int(bossRoom.x, bossRoom.y);
            Destroy(bossRoom.gameObject);
            Room roomToRemove = loadedRooms.Single(r => r.x == tempRoom.x && r.y == tempRoom.y);
            loadedRooms.Remove(roomToRemove);
            LoadRoom("End", tempRoom.x, tempRoom.y);
        }
    }

    public void LoadRoom(string name, int x, int y) {
        if (RoomExist(x,y)) {
            return;
        }
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.x = x;
        newRoomData.y = y;

        //Enqueue rooms for SceneManager
        loadRoomQueue.Enqueue(newRoomData);
    }

    IEnumerator LoadRoomRoutine(RoomInfo info) {
        string roomName = currentWorldName + info.name;
        //Additive will allow our scenes to overlap
        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while(loadRoom.isDone == false) {
            yield return null;
        }
    }

    public void RegisterRoom(Room room) {
        if (!RoomExist(currentLoadRoomData.x, currentLoadRoomData.y)) {
            room.transform.position = new Vector3(
            currentLoadRoomData.x * room.width,
            currentLoadRoomData.y * room.height,
            0);
            room.x = currentLoadRoomData.x;
            room.y = currentLoadRoomData.y;
            room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.x + ", " + room.y;
            room.transform.parent = transform;

            isLoadingRoom = false;
            if (loadedRooms.Count == 0) {
                CameraController.instance.currRoom = room;
            }
            loadedRooms.Add(room);
        }
        else {
            Destroy(room.gameObject);
            isLoadingRoom = false;
        }
    }

    public bool RoomExist(int x, int y) {
        return loadedRooms.Find(item => item.x == x && item.y == y) != null;
    }

    public Room FindRoom(int x, int y) {
        return loadedRooms.Find(item => item.x == x && item.y == y);
    }

    public string GetRandomRoomName() {
        string[] possibleRooms = new string[] {
            "Empty",
            "Room1",
            "Room2",
            "Room3",
            "Room5",
            "Room6"
            //"Basic"
        };

        return possibleRooms[Random.Range(0, possibleRooms.Length)];
    }

    public void OnPlayerEnterRoom(Room room) {
        CameraController.instance.currRoom = room;
        currRoom = room;

        StartCoroutine(RoomCoroutine());
    }

    public IEnumerator RoomCoroutine() {
        yield return new WaitForSeconds(0.5f);
        UpdateRooms();
    }

    public void UpdateRooms() {
        foreach (Room room in loadedRooms) {
            if (currRoom != room) {
                EnemyController[] enemies = room.GetComponentsInChildren<EnemyController>();
                if (enemies != null) {
                    foreach (EnemyController enemy in enemies) {
                        enemy.notInRoom = true;
                        Debug.Log("Not in room");
                    }
                    foreach (Door door in room.GetComponentsInChildren<Door>()) {
                        door.doorCollider.SetActive(false);
                    }
                }
                else {
                    foreach (Door door in room.GetComponentsInChildren<Door>()) {
                        door.doorCollider.SetActive(false);
                    }
                }
            }
            else {
                EnemyController[] enemies = room.GetComponentsInChildren<EnemyController>();
                if (enemies.Length > 0) {
                    foreach (EnemyController enemy in enemies) {
                        enemy.notInRoom = false;
                        Debug.Log("In room");
                    }
                    foreach (Door door in room.GetComponentsInChildren<Door>()) {
                        door.doorCollider.SetActive(true);
                    }
                }
                else {
                    foreach (Door door in room.GetComponentsInChildren<Door>()) {
                        door.doorCollider.SetActive(false);
                    }
                }
            }
        }
    }
}
