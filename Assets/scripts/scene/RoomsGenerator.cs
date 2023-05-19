using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField]
    private Room roomPrefab;
    [SerializeField]
    private Room hardRoomPrefab;
    [SerializeField]
    private Room bossRoomPrefab;
    [SerializeField]
    private Room magazRoomPrefab;
    [SerializeField]
    private Room secretRoomPrefab;

    [SerializeField]
    private int minCountOfRooms = 17;
    [SerializeField]
    private int maxCountOfRooms = 27;

    private IEnumerator Generate()
    {
        Graph graph = new Graph();
        int countOfRooms = Random.Range(minCountOfRooms, maxCountOfRooms);
        var infos = graph.Generate(countOfRooms);
        var g = 0;
        var curentRoom = roomPrefab;

        foreach (var pos in infos.Keys)
        {
            g++;
            if (g == countOfRooms)
            {
                curentRoom = bossRoomPrefab;
            }
            else if (g == countOfRooms / 3)
            {
                curentRoom = magazRoomPrefab;
            } else if (g == (countOfRooms / 3) * 2)
            {
                curentRoom = secretRoomPrefab;
            }
            else
            {
                if (Random.Range(0, countOfRooms) < g )
                {
                    curentRoom = hardRoomPrefab;
                } else
                {
                    curentRoom = roomPrefab;
                }
            }

            var room = Instantiate(curentRoom, new Vector3(pos.x, pos.y) * 31f, Quaternion.identity);
            room.Setup(infos[pos]);

            yield return 0;
        }

    }

    void Start()
    {
        StartCoroutine(Generate());
    }

}
