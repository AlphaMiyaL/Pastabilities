using UnityEngine;

public class RoomGen : MonoBehaviour
{
    public static int[,] GenerateRandomArray(int n, int dif) {
        int[,] arr = new int[n,n];
        int rand = Random.Range(0, n * n);
        arr[rand / n, rand-(rand/n)] = 1;
        for (int i=0; i< n /(3 - dif)+1; i++) {
            bool repeat = true;
            while (repeat) {
                rand = Random.Range(0, n * n);
                if (arr[rand / n, rand - (rand / n)] != 1 || arr[rand / n, rand - (rand / n)] != 2) {
                    arr[rand / n, rand - (rand / n)] = 2;
                    repeat = false;
                }
            }
        }
        arr[rand / n, rand - (rand / n)] = 3;
        return arr;
    }
}
