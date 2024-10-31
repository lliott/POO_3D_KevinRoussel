using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        private string _name;
        private int _pattes = 4;

        public Chat (string Name)
        {
            this._name = Name;
        }

        internal string Name => _name;

        internal override string Crier()
        {
            if (!isFed)
            {
                return "Miaou (j'ai faim)";

            } else if (isFed) {

                return "Miaou (c'est bon laisse moi tranquille humain)";
            }
            return "";
        }

        internal virtual int Pattes()
        {
            return _pattes;
        }
        internal override void Die()
        {
            OnDie.Invoke();
        }

    }
}
