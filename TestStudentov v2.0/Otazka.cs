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

        public virtual void VypisOtazku()
        {
            Console.WriteLine(text);
            Console.WriteLine("----------");
            foreach(Moznost m in moznosti)
            {
                Console.WriteLine(m.text);
            }
        }

        public virtual int VyhodnotOtazku()
        {
            return 0;
        }
    }

    class SingleOtazka : Otazka
    {
        public override int VyhodnotOtazku()
        {

            for (int i = 0; i < this.Odpovedi.Length; i++)
            {
                if (this.Odpovedi[i].spravnost) return 1;
                
            }

            return 0;
            //da sa aj foreach
        }

        public override void VypisOtazku()
        {
            Console.WriteLine("Single choice");
            base.VypisOtazku();
        }
    }

    class MultiOtazka : Otazka
    {
        public override int VyhodnotOtazku()
        {
            int body = 0;
            for (int i = 0; i < this.Odpovedi.Length; i++)
            {
                if (this.Odpovedi[i].spravnost) body++;

                else
                {
                    body--;
                }
            }

            return body;
            
        }

        public override void VypisOtazku()
        {
            Console.WriteLine("Multiple choice");
            base.VypisOtazku();
        }
    }
}
