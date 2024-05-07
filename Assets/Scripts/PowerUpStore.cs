using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStore : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<PowerUpDrop> lootList = new List<PowerUpDrop>();

    PowerUpDrop GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<PowerUpDrop> possibleDrops = new List<PowerUpDrop>();
        foreach (PowerUpDrop drop in lootList)
        {
            if(randomNumber <= drop.dropChance)
            {
                possibleDrops.Add(drop);
            }
        }
        if(possibleDrops.Count > 0)
        {
            PowerUpDrop droppedItem = possibleDrops[Random.Range(0, possibleDrops.Count)];
            return droppedItem;
        }
        return null;
    }

    public void InstantiatePowerUpDrop(Vector3 spawnPosition)
    {
        PowerUpDrop droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.powerupSprite;
        }
    }

}
