using UnityEngine;
using System.Collections;

[CreateAssetMenu]

public class PowerUpDrop : ScriptableObject
{
    public Sprite powerupSprite;
    public string powerupName;
    public int dropChance;

    public PowerUpDrop(string powerupName, int dropChance)
    {
        this.powerupName = powerupName;
        this.dropChance = dropChance;
    }
    
}
