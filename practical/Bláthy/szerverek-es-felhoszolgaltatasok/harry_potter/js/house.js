

function griff() {

    let houses = document.getElementsByClassName("row");
    houses.item(0).innerHTML = "";
    houses.item(1).innerHTML = "";

    renderGriff();
}

function mard() {

    let houses = document.getElementsByClassName("row");
    houses.item(0).innerHTML = "";
    houses.item(1).innerHTML = "";

    renderMard();
}

function hug() {

    let houses = document.getElementsByClassName("row");
    houses.item(0).innerHTML = "";
    houses.item(1).innerHTML = "";

    renderHug();
}

function holl() {

    let houses = document.getElementsByClassName("row");
    houses.item(0).innerHTML = "";
    houses.item(1).innerHTML = "";

    renderHoll();
}






function renderGriff() {
    let htmlString = "";

    htmlString += "<div class='row house_font'><h1>Griffendél</h1>";
    htmlString += "<div class='text-center'><img src='img/griffindor.png' class='house_kep'/></div>";
    htmlString += "<p>A Griffendél házat Griffendél Godrik alapította, körülbelül a Harry Potter-beli események előtt ezer évvel, valamikor a 10. század végén.</p>";
    htmlString += "<p>A Griffendél klubhelyisége az iskola egyik tornyában van, bejáratát a Kövér Dáma portréja rejti maga mögött. Rowling leírása szerint „az otthonos hangulatú kerek helyiség tele volt puha fotelekkel.” Mivel a Griffendélbe általában a bátrabbak kerülnek, címerállata egy oroszlán, színei pedig a skarlátvörös és az arany.</p>";
    htmlString += "<p>A Griffendél kísértete Sir Nicholas de Mimsy-Porpington, azaz ismertebb nevén Félig Fej Nélküli Nick. A ház vezetője Minerva McGalagony professzorasszony, aki egyben az iskola átváltoztatástan tanára és igazgatóhelyettese, később pedig igazgatója.</p>";
    htmlString += "<p>A ház kviddics-csapatának tagjai Harry Potter hat tanulóévében:</p>";
    htmlString += "<ul><li>Őrző: Oliver Wood, majd Ron Weasley</li>";
    htmlString += "<li>Terelők: Fred és George Weasley, majd Andrew Kirke és Ritchie Coote</li>";
    htmlString += "<li>Hajtók: Angelina Johnson, Alicia Spinnet, Katie Bell, majd Ginny Weasley, Katie Bell és Demelza Robbins, egyszer Dean Thomas</li>";
    htmlString += "<li>Fogó: Harry Potter, egyszer Ginny Weasley.</li></ul></div>";


    haz.insertAdjacentHTML("beforeend", htmlString);
}

function renderMard() {
    let htmlString = "";

    htmlString += "<div class='row house_font'><h1>Mardekár</h1>";
    htmlString += "<div class='text-center'><img src='img/slytherin.png' class='house_kep'/></div>";
    htmlString += "<p>A Mardekár házat Mardekár Malazár aranyvérű varázsló alapította, aki kezdetben Griffendél Godrik jó barátja volt. Később Mardekár elidegenedett a többiektől, mivel egyre több kikötést tett azzal kapcsolatban, milyen diákok kerülhetnek az iskolába.</p>";
    htmlString += "<p>Albus Dumbledore és a Teszlek Süveg szerint a Mardekár-házba azok kerülnek, akik ravaszak és becsvágyóak. Feltehető, hogy a ház tagjai között kevesebb a mugli származású, mint a többi házban, de azt nem mondhatjuk, hogy csak aranyvérűek tartoznának ide, például Tom Rowle Denem (Voldemort) és Perselus Piton apja is mugli volt.</p>";
    htmlString += "<p>A Mardekár klubhelyisége a pincében van, ahova Harry Potter és Ron Weasley másodikos korukban a Százfűlé-főzet segítségével be tudtak jutni. A helyiséget egy falba rejtett kőajtó védi. „A Mardekár klubhelyisége hosszú, alacsony mennyezetű terem volt. Durva kőfalait láncon lógó, kerek, zöld lámpák világították meg. A míves kandallópárkány alatt lobogott a tűz, fényében faragott székek és üldögélő mardekárosok körvonalai rajzolódtak ki.” Címerállata egy kígyó, színei a zöld és az ezüst.</p>";
    htmlString += "<p>A ház ismert vezetői Perselus Piton és Horatius Lumpsluck, mindketten bájitaltant tanítottak. Kísértete a Véres Báró.</p></div>";


    haz.insertAdjacentHTML("beforeend", htmlString);
}

function renderHug() {
    let htmlString = "";

    htmlString += "<div class='row house_font'><h1>Hugrabug</h1>";
    htmlString += "<div class='text-center'><img src='img/hufflepuff.png' class='house_kep'/></div>";
    htmlString += "<p>A Hugrabug házat Hugrabug Helga alapította valamikor a 10. század végén. Rubeus Hagrid elmondása alapján sokak szerint ide a balfácánok kerülnek.</p>";
    htmlString += "<p>A Hugrabug-házban nagyra tartott értékek a hűség, becsületesség, sportszerűség és tisztességes munka. A Teszlek Süveg mindazonáltal azokat a tanulókat is ebbe a házba sorolja, akik nem rendelkeznek semmilyen kiemelkedő tulajdonsággal, mivel Hugrabug Helga az egyenlő bánásmód híve volt.</p>";
    htmlString += "<p>A házvezető Pomona Bimba professzornő, aki gyógynövénytant tanít a diákoknak. Kísértete a Pufók Fráter. Címerében egy borz szerepel (eredetileg sólyom volt), színei a sárga és a fekete.</p></div>";


    haz.insertAdjacentHTML("beforeend", htmlString);
}


function renderHoll() {
    let htmlString = "";

    htmlString += "<div class='row house_font'><h1>Hollóhát</h1>";
    htmlString += "<div class='text-center'><img src='img/ravenclaw.png' class='house_kep'/></div>";
    htmlString += "<p>A Hollóhát házat Hollóháti Hedvig alapította, a Harry Potter-beli események előtt közel ezer évvel.</p>";
    htmlString += "<p>A Hollóhát házban a legnagyobb értékeknek a bölcsesség, az ész és a tanulás szeretete számít. Jelmondata: „Magad azzal ékesíted, ha az elmédet élesíted”.</p>";
    htmlString += "<p>A Hollóhát klubhelyisége, akárcsak a Griffendélé, egy magas toronyban van. Harry Potter a hetedik tanévben bejut ide, amikor Hollóháti Hedvig diadémját keresi. A házat egy kilincs nélküli ajtó védi, rajta sasfej alakú kopogtatóval. A bebocsátást kérő koppant a kopogtatóval, mire a sasfej egy kérdést tesz fel. Ha a válasz helyes, az ajtó kinyílik. „A Hollóhát e késői órán néptelen klubhelyisége tágas, kerek terem volt, levegősebb a Roxfortban megszokott helyiségeknél. A falat ékesítő kék és bronzszínű selyemkárpitok sorát kecses boltíves ablakok szakították meg: a teremből nappal pazar kilátás nyílhatott a környező hegyekre. A kupolás mennyezetet díszítő festett csillagok tükröződtek a padlón szétterülő mélykék szőnyeg mintájában A berendezést asztalok, székek és könyvszekrények alkották, s az ajtóval szemközt, egy beugróban magas fehér márványszobor állt.” A ház címerállata egy sas, színei a kék és a bronz (a filmben kék és ezüstre változtatták).</p>";
    htmlString += "<p>Házvezetője Filius Flitwick professzor, a bűbájtant oktató tanár, kísértete a Szürke Hölgy, Hollóháti Hedvig lánya.</p></div>";


    haz.insertAdjacentHTML("beforeend", htmlString);
}