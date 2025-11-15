using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Szia Világ!");
            // komment

            /*
                Ez egy többsoros megjegyzés. A többsoros megjegyzés a "/*" karakter
                sorozattal kezdődik
            */ // és a */ karakter sorozattal végződik

            /* Ez egy alternatív egy soros komment :) */

            // típus vátozó_neve = érték;

            float pelda = 3.14F;
            System.Console.WriteLine(pelda);

            //10-es szamrendszerben megadott egesz
            int egesz_szam = 42;
            System.Console.WriteLine(egesz_szam);

            //előjeltelen
            uint elojeltelen = 14U;
            System.Console.WriteLine(elojeltelen);

            //az f jelzés jelöli a fordító számára,
            //hogy ez egy float típus
            float lebegopontos = 3.14f;
            System.Console.Write(lebegopontos);

            //double esetén nem kell külön jelölni
            double d = 1124.333;
            System.Console.WriteLine(d);

            //egész szám hexadecimális formában
            int hexa = 0xff;
            System.Console.WriteLine(hexa);

            //hosszú egész oktális formátumban
            long okta = 07123235;
            System.Console.WriteLine(okta);

            //hosszú egész
            long hosszu = 1234L;
            System.Console.WriteLine(hosszu);

            //ulong esetén UL jelzi, hogy előjeltelen egész
            ulong elojeltelenhosszu = 1234UL;
            System.Console.WriteLine(elojeltelenhosszu);

            //decimal típus esetén m betű jelzi, hogy a szám egy decimal típus 
            decimal penz = 1224.3m;
            System.Console.WriteLine(penz);

            //A fordító a változó típusának string-et fog adni.
            var valtozo = "Ez egy szöveg";
            System.Console.WriteLine(valtozo);

            //futtatás közben fog eldőlni a típus.
            //az eredmény típus szöveg lesz. A 44 szöveggé fog konvertálódni
            dynamic dinamikus = "Ez egy " + 44;
            System.Console.WriteLine(dinamikus);

            /*
                \b – Backspace. Törli az előtte szereplő karaktert
                \t – Tab
                \n – Új sor
                \r – Sor elejére helyezi a kurzort
                \’ – Aposztróf karakter elhelyezése
                \” – Idézőjel karakter elhelyezése
                \\ – Visszafelé per jel
            */

            string szoszerint = @"Ez egy speciális\különlege's \t string";
            System.Console.WriteLine(szoszerint);

            /*
                Operátorok
                A kulcsszavak mellett az operátorok alkotják minden programozási nyelv gerincét. Ezek a szimbólumok műveleteket határoznak meg. A műveletek nem minden típus esetén értelmezettek.

                Alap műveleti operátorok
                Az alap műveleti operátorok szám típusok (egészek, float, decimal, double) esetén értelmezettek.

                + összeadás, összefűzés
                – kivonás
                * szorzás
                / osztás
                % maradékos osztás. Eredménye az osztás elvégzésekor keletkező maradék.
                Bitenkénti logikai operátorok
                A bitenkénti operátorok a Boole algebra alapműveletei szerinti műveleteket valósítanak meg. A műveletek csak egész számok esetén értelmezhetőek. Lebegőpontos és Decimal típus esetén fordítási hibát fogunk kapni.

                ~ bitenkénti negáció. Előjeles számtípusok esetén, ha a szám pozitív, akkor érdekes eredményt ad vissza negálás után, mivel az előjelbitet is negálja.
                A negatív előjelű számokat pedig a program kettes komplemens alaknak érzékeli.
                | bitenkénti VAGY (OR)
                & bitenkénti ÉS (AND)
                ^ bitenkénti KIZÁRÓ VAGY (XOR)
                << Biteltolás balra. A kifejezés jobb oldalán álló szám határozza meg az eltolás mértékét.
                >> Biteltolás jobbra. A kifejezés jobb oldalán álló szám határozza meg az eltolás mértékét.
                Logikai operátorok
                A logikai operátorok a program futásának logikai szervezésében vesznek részt. Ezen operátorok jellemzője, hogy bool típust adnak vissza eredményként.

                ! tagadás, negáció
                == egyenlőség
                != egyenlőség tagadása
                || VAGY művelet
                && ÉS művelet
                < Kisebb, mint művelet
                > Nagyobb, mint művelet
             */

            int x = 1;
            x += 3;
            x = x + 3;

            int a = 1;
            int b = 2;
            //a változóba a "b nagyobb, mint a" szöveg kerül, mivel a feltétel nem igaz
            string nagyobb = a > b ? "a nagyobb, mint b" : "b nagyobb, mint a";
            System.Console.WriteLine(nagyobb);

            //17 lesz az eredmény
            var kifejezes = 3 * 6 - 2 + 1 % 2;
            Console.WriteLine(kifejezes);

            //így már helyes és az eredmény 1
            var kifejezes2 = (3 * 6 - 2 + 1) % 2;
            Console.WriteLine(kifejezes2);

            Console.Write("A long tipus merete byte-ban: ");
            //8
            int bytes = sizeof(long);
            Console.WriteLine(bytes);

            //binárisan
            // 0000_0001 << 6 => 0100_0000
            int kettohat = 1 << 6;
            Console.WriteLine(kettohat);

            //binárisan
            //1111_0000 >> 2 => 0011_1100
            int balra = 240 >> 2;
            Console.WriteLine(balra);

            //true
            bool logika = 33 > 22;
            //false
            bool logika2 = (33 / 2) == 0;
            Console.WriteLine(logika);
            Console.WriteLine(logika2);

            string szoveg = "ez egy";
            szoveg += " szép mondat.";

            Console.WriteLine(szoveg);

            int y = 3;
            //4 lesz, mert inkrementálás után ír ki
            Console.WriteLine(++y);
            y = 3;
            //3 lesz, mert kiír és csak utána inkrementálja a változót
            Console.WriteLine(y++);
            //4 lesz, mert itt már a növelt értéket látjuk
            Console.WriteLine(y);

            Console.ReadKey();
        }
    }
}
