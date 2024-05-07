using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "PowerUp/SpeedBuff")]

public class SpeedBuff : PowerUp
{
    public float amount;

    public override void Apply(GameObject target)
    {
        gunController gunController = target.transform.Find("gun").GetComponent<gunController>();
        if (gunController != null)
        {
            gunController.fireRate += amount;
        }
        else
        {
            Debug.LogError("gunController not found on gun object.");
        }
    }
}