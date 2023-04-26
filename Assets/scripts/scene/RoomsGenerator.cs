using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField]
    private Room roomPrefab;

    private IEnumerator Generate()
    {
        Graph graph = new Graph();
        int countOfRooms = Random.Range(17, 27);
        var infos = graph.Generate(countOfRooms);

        foreach (var pos in infos.Keys)
        {
            var room = Instantiate(roomPrefab, new Vector3(pos.x, pos.y) * 31f, Quaternion.identity);
            room.Setup(infos[pos]);

            yield return 0;
        }
    }

    void Start()
    {
        StartCoroutine(Generate());
    }

}
