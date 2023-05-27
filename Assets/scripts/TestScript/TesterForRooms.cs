using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TesterForRooms : MonoBehaviour
{
    [SerializeField] private List<GameObject> rooms;
    [SerializeField] private bool edit = true;
    private List<Vector2> pref = new List<Vector2>();

    private Vector2Int[] all = 
    {
        new Vector2Int(0, 1),
        new Vector2Int(1, 0),
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0)
    };
    void Start()
    {
        var dxdy = new Vector2Int[] {};
        var mx = 4;
        var app = -1;
        while (edit)
        {
            for (int i = 0; i < mx; i++)
            {
                dxdy.Append(all[i]);
            }
            foreach (var room in rooms)
            {
                room.GetComponent<Room>().Setup(new HashSet<Vector2Int>(dxdy));
            }
            StartCoroutine(Wait());
            app = mx switch
            {
                0 => 1,
                4 => -1,
                _ => app
            };
            mx += app;
            dxdy = new Vector2Int[] { };
        }
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
