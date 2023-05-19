using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class obelisk : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnDestroy()
    {
        boss.GetComponent<Enemy>().PureDamage(5, new List<string>());
        transform.parent.parent.GetComponent<StageController>().UpdateState();
        this.enabled = false;
    }
}
