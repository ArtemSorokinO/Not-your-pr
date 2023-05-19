using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonRoomDoorsController : MonoBehaviour
{
    private int countOfEnemyesIn = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && countOfEnemyesIn > 0)
        {
            gameObject.transform.parent.gameObject.GetComponent<Room>().CloseDoors();
        } else if (collider.gameObject.CompareTag("Enemy"))
        {
            countOfEnemyesIn++;
            gameObject.transform.parent.gameObject.GetComponent<Room>().CloseDoors();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            countOfEnemyesIn--;
            if (countOfEnemyesIn <= 0)
            {
                gameObject.transform.parent.gameObject.GetComponent<Room>().OpenDoors();
                GameObject.FindGameObjectWithTag("UIManager").GetComponent<Upgrade>().upSkillPoints(1);
            }
        }
    }
}
