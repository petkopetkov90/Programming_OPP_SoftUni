using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString()
        {
            string randomElement = null;

            if (this.Count > 0)
            {
                int randomIndex = random.Next(0, this.Count);
                randomElement = this[randomIndex];
                this.RemoveAt(randomIndex);
            }

            return randomElement;
        }
    }
}
