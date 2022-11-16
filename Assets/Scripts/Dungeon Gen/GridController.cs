using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [System.Serializable]
    public struct Grid {
        public int columns, rows;
        public float verticalOffset, horizontalOffset;

    }

    public Room room;
    public Grid grid;
    public GameObject gridTile;
    public List<Vector2> availPts = new List<Vector2>();

    private void Awake() {
        room = GetComponentInParent<Room>();
        grid.columns = room.width - 1;
        grid.rows = room.height - 1;
        GenerateGrid();
    }

    public void GenerateGrid() {
        grid.verticalOffset += room.transform.localPosition.y;
        grid.horizontalOffset += room.transform.localPosition.x;

        for (int y=0; y<grid.rows; y++) {
            for (int x=0; x<grid.columns; x++) {
                GameObject tile = Instantiate(gridTile, transform);
                tile.GetComponent<Transform>().position = 
                    new Vector2(x-(grid.columns-grid.horizontalOffset), y-(grid.rows-grid.verticalOffset));
                tile.name = "X: " + x + ", Y: " + y;
                availPts.Add(tile.transform.position);
                tile.SetActive(false);
            }
        }

        GetComponentInParent<ObjectRoomSpawner>().InitObjectSpawning();
    }
}
