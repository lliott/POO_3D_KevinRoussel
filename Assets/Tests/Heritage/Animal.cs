using System;
using UnityEngine;

namespace TU_Challenge.Heritage
{

    public abstract class Animal
    {
        internal abstract string Crier();

        internal bool isFed;

        public Action OnDie;

        internal abstract void Die();
    }
}
