using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "PowerUp/SpeedBuff")]
public class SpeedBuff : PowerUp
{
    public float amount;
    public float duration;

    public override void Apply(GameObject target)
    {
        MonoBehaviour behaviour = target.GetComponent<MonoBehaviour>();
        if (behaviour != null)
        {
            gunController gunController = target.transform.Find("gun").GetComponent<gunController>();
            if (gunController != null)
            {
                gunController.fireRate -= amount;

                behaviour.StartCoroutine(RemovePowerUp(gunController));
            }
            else
            {
                Debug.LogError("gunController not found on gun object.");
            }
        }
        else
        {
            Debug.LogError("No MonoBehaviour component found on target.");
        }
    }
    IEnumerator RemovePowerUp(gunController gunController)
    {
        yield return new WaitForSeconds(duration);
        gunController.fireRate += amount;
    }
}
