using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudentov_v2._0
{
    class DBOtazek
    {//pozret static vs nie static. ked je static tak sa neinicializuje - len tak btw
        public DBOtazek()
        {
            SingleOtazka o = new SingleOtazka();
            o.text = "Kolko je 1+1";
            o.Moznosti = new Moznost[] // pred rovna sa moze byt Moznost[] moznosti miesto o.Moznosti
            {
                new Moznost("1",false),
                new Moznost("2",true),
                new Moznost("3",false)
            };
            Otazky.Add(o);

            o = new SingleOtazka();
            o.text = "Kolko je 1+2";
            o.Moznosti = new Moznost[]  
            {
                new Moznost("1",false),
                new Moznost("2",false),
                new Moznost("3",true)
            };
            Otazky.Add(o);

            MultiOtazka m = new MultiOtazka();
            m.text = "Ktory z nich je operacny system";
            m.Moznosti = new Moznost[]  
            {
                new Moznost("OS X",true),
                new Moznost("OS Z",false),
                new Moznost("Windows",true)
            };
            Otazky.Add(m);



        }
        public ArrayList Otazky = new ArrayList();
        
        

    }
}
