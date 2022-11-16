using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRoomSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct RandomSpawner {
        public string name;
        public SpawnerData spawnerData;
    }

    public GridController grid;
    public RandomSpawner[] spawnerData;

    public void InitObjectSpawning() {
        foreach(RandomSpawner rs in spawnerData) {
            SpawnObjects(rs);
        }
    }

    private void SpawnObjects(RandomSpawner data) {
        int randomIteration = Random.Range(data.spawnerData.minSpawn, data.spawnerData.maxSpawn + 1);
        for(int i=0; i<randomIteration; i++) {
            int randPos = Random.Range(0, grid.availPts.Count-1);
            GameObject go = Instantiate(data.spawnerData.itemToSpawn, grid.availPts[randPos], Quaternion.identity, transform) as GameObject;
            grid.availPts.RemoveAt(randPos);
            Debug.Log("Spawned object");
        }
    }
}
