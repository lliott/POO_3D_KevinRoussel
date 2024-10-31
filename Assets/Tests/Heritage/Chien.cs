using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chien : Animal
    {
        private string v;

        public Chien(string v)
        {
            this.v = v;
        }

        internal override string Crier()
        {
            if (!isFed)
            {
                return "Ouaf (j'ai faim)";

            } else {

                return "Ouaf (viens on joue ?)";
            }
        }
        internal override void Die()
        {
            OnDie.Invoke();
        }
    }
}
