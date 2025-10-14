//Az oldalon megjelenő feliratos fülek adatait innen olvassa be:
const articles = [
  {
    id: 1, //Azonosító
    title: 'Cikk 1', //Rublika címe
    date: new Date(2025, 9, 9), //Dátum
    length: 11, //Olvasás várható ideje (perc)
    snippet: `Cikk 1`, //Részlet
  },
  {
    id: 2,
    title: 'dhygthdyhydhdygth',
    date: new Date(2025, 9, 8),
    length: 5,
    snippet: `sygsgísgsgyísgyísg`,
  },
  {
    id: 3,
    title: 'dhysghdgh',
    date: new Date(2018, 7, 11),
    length: 5,
    snippet: `ydththdthdth`,
  },
  {
    id: 4,
    title: 'ysdhdthdthytdh',
    date: new Date(2015, 5, 4),
    length: 5,
    snippet: `ythdthdthdthydth`,
  },
]
//"articles" néven hivatozhassunk rá máshol:
export default articles
