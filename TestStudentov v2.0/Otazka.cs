using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudentov_v2._0
{
    class Otazka
    {
        public string text;

        private Moznost[] moznosti;

        public Moznost[] Moznosti
        {
            get
            {
                return moznosti;
            }
            set
            {
                moznosti = value;
            }
        }
        public Moznost[] Odpovedi;

        public void VypisOtazku()
        {
            Console.WriteLine(text);
            Console.WriteLine("----------");
            foreach(Moznost m in moznosti)
            {
                Console.WriteLine(m.text);
            }
        }
    }

    class SingleOtazka : Otazka
    {

    }

    class MultiOtazka : Otazka
    {

    }
}
