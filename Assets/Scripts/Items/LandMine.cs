using UnityEngine;

public class LandMine : BaseItem
{
    public int explosionDamageAmount = 100;
    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 0.5f;
    public LayerMask affectedLayers;

    public override void PickUp(GameObject player)
    {
        Explode(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other.gameObject);
        }
    }

    private void Explode(GameObject player)
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, affectedLayers);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            }

            Health health = nearbyObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(explosionDamageAmount);
            }
        }

        this.gameObject.SetActive(false);
    }
}
