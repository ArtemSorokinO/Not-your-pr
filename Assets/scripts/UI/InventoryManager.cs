using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public string[] inventory = new string[3];
    bool isFull = false;
    [SerializeField] private GameObject ExplosionPrefab;

    public string[] canBeStore;
    public Sprite[] canBeStoreSprite;
    Dictionary<string, Sprite> canBeStoreImages = new Dictionary<string, Sprite>();

    [SerializeField] private Button[] slots;
    //[SerializeField] private Button firstSlot;
    //[SerializeField] private Button secondSlot;
    //[SerializeField] private Button thirdSlot;

    [SerializeField] private Sprite empty;
    private void Awake()
    {
        for (int i = 0; i < canBeStore.Length; i++)
        {
            canBeStoreImages[canBeStore[i]] = canBeStoreSprite[i];
        }

        PutToInventory("Estus");
        PutToInventory("SecretKey");
        PutToInventory("Explosion");

        Merchant.merchantSignal += PutToInventory;
    }

    private void OnDisable()
    {
        Merchant.merchantSignal -= PutToInventory;
    }

    public bool IsFull()
    {
        foreach (var t in inventory)
            if (t.NullIfEmpty() == null) return false;

        return true;
    }
    public void PutToInventory(string itemName)
    {
        isFull = IsFull();
        if (!isFull && canBeStore.Contains(itemName))
        {
            for (int i = 0; i < inventory.Length; i++) if (inventory[i].NullIfEmpty() == null)
            {
                inventory[i] = itemName;
                slots[i].image.sprite = canBeStoreImages[itemName];
                return;
            } 
        }
    }

    public void RemuveFromInventory(int slot)
    {
        slots[slot].image.sprite = empty;
        inventory[slot] = null;
    }

    public void ExecuteSlot(int slot)
    {
        if (inventory[slot] == "Estus")
        {
            Debug.Log("Hmmmmmm, Estused!!!");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().hill(10);
            RemuveFromInventory(slot);
        }
        else if (inventory[slot] == "SecretKey")
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
            var door = GameObject.FindGameObjectWithTag("DoorToSecret");
            if (player.IsTouching(door.GetComponent<Collider2D>()))
            {
                door.GetComponent<SecretRoomSpawner>().Open();
                RemuveFromInventory(slot);
            }
        }
        else if (inventory[slot] == "Explosion")
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Instantiate(ExplosionPrefab, player.position, Quaternion.identity);
            RemuveFromInventory(slot);
            
        }
        else if (inventory[slot] == "BossSpawner")
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
            var door = GameObject.FindGameObjectWithTag("BossSpawner");
            if (player.IsTouching(door.GetComponent<Collider2D>()))
            {
                door.GetComponent<Animator>().SetTrigger("spawnBoss");
                RemuveFromInventory(slot);
            }
        }

    }
}
