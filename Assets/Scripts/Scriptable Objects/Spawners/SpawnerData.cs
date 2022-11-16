using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "spawner.asset", menuName = "Spawners/Spawner")]
public class SpawnerData : ScriptableObject
{
    public GameObject itemToSpawn;
    public int minSpawn;
    public int maxSpawn;

}
