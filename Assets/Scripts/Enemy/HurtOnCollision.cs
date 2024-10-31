using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurtOnCollision : MonoBehaviour
{
    [SerializeField] private int damageOnCol;
    [SerializeField] private int refreshTimer;

    Dictionary<Collider, Coroutine> _all;

    private void Awake()
    {
        _all = new Dictionary<Collider, Coroutine>();
    }

    private void Reset()
    {
        damageOnCol = 15;
        refreshTimer = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var c = StartCoroutine(damageRefresh(refreshTimer, other));

            _all.Add(other, c);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var c = _all[other];
        StopCoroutine(c);
        _all.Remove(other);
    }

    IEnumerator damageRefresh(int value, Collider other)
    {
        while (true)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damageOnCol);

            yield return new WaitForSeconds(value);
        }

    }
}
