using UnityEngine;
using UnityEngine.Events;

public class BaseItem : MonoBehaviour
{
    public string itemName;
    public bool canPickUp = true;

    [SerializeField] public UnityEvent OnPickUp;

    public virtual void PickUp(GameObject player)
    {
        if (canPickUp)
        {
            Debug.Log($"{itemName} picked up");

            OnPickUp?.Invoke();

            Destroy(gameObject);
        }
    }
}