using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class ChatQuiBoite : Chat
    {
        private string _name;
        private int _pattes = 3;

        public ChatQuiBoite(string Name) : base(Name)
        {
            this._name = Name;
        }

        internal override int Pattes()
        {
            return _pattes;
        }
        internal override void Die()
        {
            OnDie.Invoke();
        }
    }
}
