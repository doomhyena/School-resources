//4 változó a stopper órában szereplő idő értékeknek:
let ora = 0;
let perc = 0;
let mperc = 0;
let milli = 0;
//Épp fut-e a mérőóra:
let timer = false;

function start(){
    timer = true;

    kezeloFuggveny();
}

function stop(){
    timer = false;
    kezeloFuggveny();
}

function reset(){
    location.reload();
}

let date = document.querySelector('#date')
    let myDate = new Date()
    date.innerHTML = `${myDate.getDate()}/${myDate.getMonth()+1}/${myDate.getFullYear()}`
    	//A HTML szegmens miatt az AltGr+7 féle idézőjelet használtam
		// A '/' jel nem művelet volt, hanem szó szerinti szövegformázás
		//Változók tartalmát így hivatkoztuk be: ${VáltozóNeve}
		//A +1 a hónapnál az indexek miatti elcsúszás fixálására kellett

function kezeloFuggveny(){
    if(timer == true){
        milli = milli + 1;
        if(milli == 100){
            mperc = mperc + 1;
            milli = 0;
        }
		//(később a mérés 10 milliszekundumonként ugrik előre)
		/*Ha milli eléri a 100-at (100x10 milliszekundum), akkor
		  az kiad egy teljes másodpercet, így az nő 1-el, a milli 
		  pedig nullázódik a következő másodpercet lemérésére.*/
        if(mperc == 60){
            perc = perc + 1;
            mperc = 0;
        }

        if(perc == 60){
            ora = ora + 1;
            perc = 0;
        }
		//Idő értékek kijelzése:
			/*	- a kijelző mindig kétjegyű értékeket mutat 
				- egyjegyű érték esetén kerüljön egy 0 számjegy az elejére
				- pl.: 01 : 45 : 08
				- emiatt a kijelzésre alternatv változókat használunk
			*/
        let altMilli = milli
        let altMperc = mperc;
        let altPerc = perc;
        let altOra = ora;

		/* többjegyű szám esetén marad az érték, egyjegyű esetén 
		   viszont elé kell rakni egy 0-t (mind a 4 alt időváltózóra)*/
       if(milli<10){
        altMilli = "0" + milli;
       }

        if(mperc<10){
           altMperc = "0" + mperc;
        }

        if(perc<10){
            altPerc = "0" + perc;
        }
        if(ora<10){
            altOra = "0" + ora;
        }
		//10 milliszekundumonként ismétlődjön ez az egész mérés:
        setTimeout("kezeloFuggveny()", 10);
		//Időzített ismétlődés: setTimeout(MiTörténjen,HányEzredmásodpercenként);
		
		//Az imént kiszámolt kiírandó értékeket be kell vinni a megfelelő mezőbe:
        document.getElementById("milli").innerHTML=altMilli;
        document.getElementById("mperc").innerHTML=altMperc;
        document.getElementById("perc").innerHTML=altPerc;
        document.getElementById("ora").innerHTML=altOra;
    }
}

