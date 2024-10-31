using UnityEngine;

public class LandMine : BaseItem
{
    public int explosionDamageAmount = 100;

    public override void PickUp(GameObject player)
    {
        base.PickUp(player);

        Health playerHealth = player.GetComponent<Health>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(explosionDamageAmount);

            Debug.Log($"player damaged (kaboom) for {explosionDamageAmount}");

        } else {

            Debug.LogWarning("nothing to hurt");
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
