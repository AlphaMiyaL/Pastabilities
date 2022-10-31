using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject entryRoom;        //Room that will initialize all the other rooms, randomly generated layout
    public GameObject rooms;            //Empty gameObject where rooms will be created in
    public int roomN;                   //Size of array for rooms
    public int dif;         
    public int[,] roomLayout;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(entryRoom, transform.position, transform.rotation, rooms.transform);
        //roomLayout = GenerateRandomArray(roomN, dif);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public static int[,] GenerateRandomArray(int n, int dif) {
        int[,] arr = new int[n, n];
        int rand = Random.Range(0, n * n-1);
        arr[rand / n, rand - n*(rand / n)] = 1;
        for (int i = 0; i < n / (3 - dif); i++) {
            bool repeat = true;
            while (repeat) {
                rand = Random.Range(0, n * n-1);
                if (arr[rand / n, rand - n * (rand / n)] != 1 || arr[rand / n, rand - n * (rand / n)] != 2) {
                    arr[rand / n, rand - n * (rand / n)] = 2;
                    repeat = false;
                }
            }
        }
        arr[rand / n, rand - n * (rand / n)] = 3;
        return arr;
    }*/
}
