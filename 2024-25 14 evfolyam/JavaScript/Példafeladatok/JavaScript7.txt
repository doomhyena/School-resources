/*A bekért szövegből tüntessük el az összes a, b és c betűket. 
Pl. nincsabc("Ez a példamondat") --> "Ez  példmondt"
  szövegváltozó.includes(karakter)
*/
function nincsabc(szöveg){
  let újszöveg = ; //a megoldás lesz
  //Ha nincs a keresett betűkből:
  if (!szöveg.includes(a) && !szöveg.includes(b) && !szöveg.includes(c)){
    return szöveg;
  }
  //Alapesetben viszont ez kell:
  for (let betü in szöveg){
    //Ha az adott betű nem a, nem b, és nem is c
    if (betü !== a && betü !== b && betü !== c){
      újszöveg += betu; //Akkor hozzájön a megoldáshoz
    }
  } return újszöveg;
}
