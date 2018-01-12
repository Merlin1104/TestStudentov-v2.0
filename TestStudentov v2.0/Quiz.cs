using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudentov_v2._0
{
    class Quiz
    {
        private Otazka[] otazky;

        public Quiz() //constructor
        {
            otazky = new Otazka[2];
            DBOtazek db = new DBOtazek();
            Random r = new Random();
            ArrayList vybranaCisla = new ArrayList();
            for (int i = 0; i < 2; i++) // zabezpeci ze nebudu dve rovnake otazky
            {
                int index;
                do
                {
                    index = r.Next(2);
                }
                while (vybranaCisla.Contains(index));

                otazky[i] = (Otazka)db.Otazky[index];
                vybranaCisla.Add(index);
            }
        }

        public void SpustQuiz()

        {
            foreach (Otazka o in otazky)
            {
                string uzivOdpoved;
                int[] poleUzivatelskychIndexov;
                o.VypisOtazku();
                do
                {
                    uzivOdpoved = Console.ReadLine();
                } while (!zkontrolujVstup(uzivOdpoved,o, out poleUzivatelskychIndexov));
                

            }

            Console.ReadLine();
        }

        private bool zkontrolujVstup(string uzivVstup,Otazka otazka, out int[] poleIndexu)
        {
            
            int index;
            if (otazka is SingleOtazka)
            {
                bool res =  jeCisloAJeVIndexu(uzivVstup, otazka,out index);
                poleIndexu = new int[] { index };
                return res;
            }
            else
            {
                string [] poleOdpovediuzivatela = uzivVstup.Split(' '); // splitni sa pomocou niecoho, v tomto pripade medzera a vytvori pole prvkov. A kazda skatulka je string
                poleIndexu = new int[poleOdpovediuzivatela.Length];
                for(int i = 0; i< poleOdpovediuzivatela.Length; i++)
                {
                    if (!jeCisloAJeVIndexu(poleOdpovediuzivatela[i], otazka, out index)) return false;
                    poleIndexu[i] = index;
                }
                return true;
            }
            
        }

        private bool jeCisloAJeVIndexu (string uzivatelskeCislo, Otazka otazka, out int index)
        {
            
            bool jeCislo = int.TryParse(uzivatelskeCislo, out index);
            if (!jeCislo)
            {
                return false;
            }
            else
            {
                return index > 0 && index < otazka.Moznosti.Length;
                
            }
        }

        

    } 
}
