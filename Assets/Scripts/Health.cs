using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Assignable Values")]
    [SerializeField, ValidateInput("ValidateMaxHealth", "Cannot be negative value, or equal to 0.")] private int maxHealth;

    [SerializeField] UnityEvent onDieEvent;
    public bool isDead;

    [Header("Current Life")]

    [SerializeField] UnityEvent onTakeDamageEvent;

    [ProgressBar("Health", 100, EColor.Red)]
    [SerializeField] private int currentHealth;

    [SerializeField] Animator animator;
        
    private void Reset()
    {
        maxHealth = 100;
    }

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        isDead = false;

        currentHealth = maxHealth;
    }

    #region On validate
    private void OnValidate()
    {
        if (maxHealth > 100)
        {
            maxHealth = 100;
        }
    }
    bool ValidateMaxHealth(int value)
    {
        if (value <= 0)
        {
            return false;
        }

        return true;
    }
    #endregion

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            Debug.LogError("damage must be positive");
            return;
        }

        onTakeDamageEvent.Invoke();

        TakeDamageAnim();

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(DieRoutine());
    }

    public void HealDamage(int heal)
    {
        currentHealth = Mathf.Clamp(currentHealth + heal, 0, maxHealth);

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    IEnumerator DieRoutine()
    {
        isDead = true;
        onDieEvent.Invoke();

        yield return new WaitForSeconds(2);

        gameObject.SetActive(false);

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    private void TakeDamageAnim()
    {
        if (animator != null)
        {
            this.animator.SetTrigger("hurt");
        }
        else {

            Debug.Log("No animator to access on " + gameObject.name);
        }
    }
}
