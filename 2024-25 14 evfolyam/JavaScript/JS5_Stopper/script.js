//Időegység változók:
let hour = 0;
let min = 0;
let sec = 0;
let milli = 0;
//A stopper épp megy-e?
let timer = false;
//Segédfüggvény a stopper indítására:
function start(){
    timer = true;

    idotMer();
}

function stop(){
    timer = false;
    idotMer();
}

function reset(){
    location.reload();
}

//Aktuális dátum mutatása a stopper óra felett:
let date = document.querySelector('#date')
    let myDate = new Date()
    date.innerHTML = `${myDate.getDate()}/${myDate.getMonth()+1}/${myDate.getFullYear()}`

//Időt mérő főfüggvény:
function idotMer(){
	/*Ha true értéken van a 'timer', akkor 10 ezredmásodpercenként
	fogja magát frissíteni.*/
    if(timer == true){
        milli = milli + 1;
        if(milli == 100){
            sec = sec + 1;
            milli = 0;
        }

        if(sec == 60){
            min = min + 1;
            sec = 0;
        }

        if(min == 60){
            hour = hour + 1;
            min = 0;
        }

        let ujMilli = milli
        let ujSec = sec;
        let ujMin = min;
        let ujHour = hour;

		/*A megjelenés 00:00:00 formában lesz, így tenni kell 
		róla, hogy pl. a "3" az "03"-ként szerepeljen (kétjegyű) */
		//1-1 alternatív változó a 4 időegységnek:
       if(milli<10){
        ujMilli = "0" + milli;
       }

        if(sec<10){
           ujSec = "0" + sec;
        }

        if(min<10){
            ujMin = "0" + min;
        }
        if(hour<10){
            ujHour = "0" + hour;
        }
		//A mérőfüggvény újbóli meghívása 10 ezredmásodpercenként:
        setTimeout("idotMer()", 10);
		
        document.getElementById("milli").innerHTML=ujMilli;
        document.getElementById("sec").innerHTML=ujSec;
        document.getElementById("min").innerHTML=ujMin;
        document.getElementById("hour").innerHTML=ujHour;
    }
}

