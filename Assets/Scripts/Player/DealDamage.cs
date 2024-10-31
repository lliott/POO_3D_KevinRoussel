using UnityEngine;
using UnityEngine.Events;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private GameObject damageZone;

    [Header("To Enemy")]
    [SerializeField] private int dealDamage;

    [SerializeField] UnityEvent onGiveDamageEnemyEvent;

    [Header("To Other")]
    [SerializeField] private int dealDamageToNeutral;

    [SerializeField] UnityEvent onGiveDamageNeutralEvent;

    private Animator animator;

    private void Reset()
    {
        dealDamage = 10;
        dealDamageToNeutral = 1;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (damageZone == null)
        {
            Debug.Log("DamageZone is not specified, cannot perform actions");
        }
    }

    private void FixedUpdate()
    {
        PlayAttackAnim();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //deal damage function
            if (other.gameObject.CompareTag("Enemy"))
            {
                onGiveDamageEnemyEvent.Invoke();

                other.gameObject.GetComponent<Health>().TakeDamage(dealDamage);

            } else if (other.gameObject.CompareTag("Decor")) {

                onGiveDamageNeutralEvent.Invoke();

                other.gameObject.GetComponent<Health>().TakeDamage(dealDamageToNeutral);
            }
        }
    }

    private void PlayAttackAnim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attacking");
        }
    }
}
