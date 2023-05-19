using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Openings doors;

    [SerializeField]
    private Openings wallsDoors;

    private HashSet<Vector2Int> setupedConfig;

    public void Setup(HashSet<Vector2Int> config)
    {
        setupedConfig = config;

        foreach (var wall in wallsDoors.GetOpenings())
        {
            bool contains = setupedConfig.Contains(wall.Pos);
            wall.GameObject.SetActive(!contains);
        }

        foreach (var door in doors.GetOpenings())
        {
            bool contains = config.Contains(door.Pos);
            door.GameObject.SetActive(contains);
        }
    }

    public void OpenDoors()
    {
        foreach (var wall in doors.GetOpenings())
        {
            wall.GameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void CloseDoors()
    {
        foreach (var wall in doors.GetOpenings())
        {
            wall.GameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}