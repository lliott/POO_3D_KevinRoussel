using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Poisson : Animal
    {
        private string v;
        public bool isAlive = true;

        public Poisson(string v)
        {
            this.v = v;
        }

        internal override string Crier()
        {
            return "bloop bloop";
        }

        internal override void Die()
        {
            isAlive = false;
            OnDie.Invoke();
        }

        internal bool IsAlive()
        {
            if (isAlive) return true;
            return false;
        }
    }
}
