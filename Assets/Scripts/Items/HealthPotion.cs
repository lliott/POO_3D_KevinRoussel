using UnityEngine;

public class HealthPotion : BaseItem
{
    public int healAmount = 100;

    public override void PickUp(GameObject player)
    {
        base.PickUp(player);

        Health playerHealth = player.GetComponent<Health>();

        if (playerHealth != null)
        {
            playerHealth.HealDamage(healAmount);

            Debug.Log($"player healed for {healAmount}");

        } else {

            Debug.LogWarning("nothing to heal");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other.gameObject);
        }
    }
}

