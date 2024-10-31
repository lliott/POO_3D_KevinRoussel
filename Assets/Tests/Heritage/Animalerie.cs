using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Animalerie
    {
        List<Animal> animalsList = new List<Animal>();

        private Animal animals;

        public event Action<Animal> OnAddAnimal;

        internal void AddAnimal(Animal c)
        {
            animalsList.Add(c);
            OnAddAnimal?.Invoke(c);
        }



        internal bool Contains(Animal c)
        {
            return animalsList.Contains(c);
        }

        internal Animal GetAnimal(int c)
        {
            return animalsList[c];
        }

        internal void FeedAll()
        {
            foreach (Animal c in animalsList)
            {
                c.isFed = true;
            }
        }
    }
}
