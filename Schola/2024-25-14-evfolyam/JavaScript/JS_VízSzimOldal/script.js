var szelesseg = 300;

var talaj = new Array(szelesseg).fill(1);
talaj[0] = talaj[szelesseg-1] = 100;

var altPI = Math.PI * 4; //PI értékének négyszerese kell tartalomnak
var elhelyezes;
var eltolas = Math.random() + 1.1; //Random szám generálása
for (x = 1; x < szelesseg/2; x++){
  elhelyezes = (x / (szelesseg/2)) * altPI;
  talaj[x] = tmp = 30 + 10 * ( ( Math.sin( elhelyezes ) + Math.sin( eltolas * elhelyezes ) ) / 2 ); //A matematikai modul sinus függvénye kell
}

var szint = tmp;
for (x = szelesseg/2; x < szelesseg-1; x++) {
  talaj[x] = szint;
  szint = Math.min(100, Math.max(0, szint+Math.random()*8-4) ); //Hiányzó részek: legkisebb, legnagyobb, random érték függvényei
}

var viz = new Array(szelesseg).fill(0);
viz[0] = viz[szelesseg-1] = 0;
viz[parseInt(szelesseg/2)] = 250; //int értékké parsolás

var energia = new Array(szelesseg).fill(0);

var wrap = document.getElementById("wrap"); //tartalomként legyen kiválasztva a "wrap" ID-jű elem
var html = "<div class='ww'></div><div class='gw'></div>";
for (x = 0; x < szelesseg; x++) {
  var col = document.createElement("div"); //tartalomként jöjjön létre egy div elem
  col.classList.add('col'); //ruházzuk is fel a 'col' formázással
  col.innerHTML = html; //a belső html tartalom pedig a 'html' nevű változó legyen
  wrap.appendChild(col);
}
var colLista = document.getElementById("wrap").children;

for (var i=0; i<colLista.length; i++) {
  (function(j){
    colLista[i].addEventListener("mousedown", function () {
      var ido = new Date(); //tartalom egy sima dátum típusú elem legyen
      var index = j;
      window.onmouseup = function(){
        var kulonbseg=new Date()-ido;
        window.onmouseup=null;
        viz[index] = kulonbseg;
      }
    });
  })(i);
}

function frameSzamolo() {
  //Itt 2 db tömb típusú objektum jön létre:
  var vizSeged  = new Array(szelesseg).fill(0);
  var energiaSeged = new Array(szelesseg).fill(0); 
  
  for (x = 1; x < szelesseg-1; x++) { 
    if ( talaj[x] + viz[x] - energia[x] > talaj[x-1] + viz[x-1] + energia[x-1] ) {
      var folyas = Math.min(viz[x], talaj[x] + viz[x] - energia[x] - talaj[x-1] - viz[x-1] - energia[x-1]) / 4; //A ()-en belül felsoroltak minimumát keressük
      vizSeged[x-1]  += folyas;
      vizSeged[x]    += -folyas;
      energiaSeged[x-1] += -energia[x-1] / 2 - folyas;
    }

    if ( talaj[x] + viz[x] + energia[x] > talaj[x+1] + viz[x+1] - energia[x+1] ) {
      var folyas = Math.min(viz[x], talaj[x] + viz[x] + energia[x] - talaj[x+1] - viz[x+1] + energia[x+1]) / 4; //A ()-en belül felsoroltak minimumát keressük
      vizSeged[x+1]  += folyas;
      vizSeged[x]    += -folyas;
      energiaSeged[x+1] += -energia[x+1] / 2 + folyas;
    } 
  }

  for (x = 1; x < szelesseg-1; x++) { 
    viz[x]  = viz[x] + vizSeged[x];
    energia[x] = energia[x] + energiaSeged[x]; 
  }
}

function frameRajzolo(felulet, viz) {
  for (var i = 0; i < felulet.length; i++) {
    var col = colLista[i].children;
	//Ennél a 2 elemnél a stíluselemek közül a magasságot akarom beállítani:
    col[0].style.height = Math.min(100-felulet[i], viz[i])+"%"; //A ()-en belüli 2 érték kisebbikét keressük
    col[1].style.height = felulet[i]+"%";
  }
}

function render(){
  requestAnimationFrame(render);
  frameSzamolo();
  frameRajzolo(talaj, viz);
}
requestAnimationFrame(render);