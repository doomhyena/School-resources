// src/slides.js

const slides = [
 {
    title: "GitHub Copilot",
    subtitle: "Csontos Kincső Anasztázia – Szoftverfejlesztő és Tesztelő",
    content: "A fejlesztők mesterséges intelligencia társa.",
    image: "https://upload.wikimedia.org/wikipedia/commons/0/0a/GitHub_Copilot_Logo.svg",
  },
  {
    title: "Mi az a GitHub Copilot?",
    content: "Egy mesterséges intelligencia-alapú kódgeneráló eszköz, amit a GitHub és az OpenAI közösen fejlesztett ki.",
    image: "https://miro.medium.com/v2/resize:fit:1200/1*Xbo3S9ocOXqpqQMdUeU9hw.png",
  },
  {
    title: "Mire képes?",
    content: "Kommentekből kódot ír, kódot egészít ki, refaktorál, teszteket generál és még sok mást.",
    image: "https://docs.github.com/assets/images/help/copilot/copilot-suggestion.png",
  },
  {
    title: "Támogatott nyelvek",
    content: "Többek között: JavaScript, Python, Java, C#, Go, TypeScript, Ruby és még sok más.",
    image: "https://github.blog/wp-content/uploads/2021/06/copilot_editor.png",
  },
  {
    title: "Hogyan működik?",
    content: "A Codex nevű nyelvi modellen alapszik, amely több milliárd sor nyílt forráskódon lett tanítva.",
    image: "https://openai.com/content/images/2022/05/copilot-diagram.png",
  },
  {
    title: "Példa – Komment alapján kód",
    content: "/* Kiszámítja két szám összegét */ → Copilot: function osszeg(a, b) { return a + b; }",
    image: "https://user-images.githubusercontent.com/674621/124457397-98d46180-dd6c-11eb-9e62-02482b54bd7e.png",
  },
  {
    title: "Példa – Python kódgenerálás",
    content: "# Hello világ → print('Hello, világ!')",
    image: "https://camo.githubusercontent.com/def43f007cdb25d220d2b1b050650fe3cc258e7e659a1de91863d2f5ccbd9899/68747470733a2f2f692e6962622e636f2f70787635554d752f636f64652d73756767657374696f6e2e706e67",
  },
  {
    title: "VS Code integráció",
    content: "A Copilot könnyen telepíthető bővítményként a VS Code szerkesztőbe.",
    image: "https://code.visualstudio.com/assets/docs/introvideos/copilot/copilot-extension.gif",
  },
  {
    title: "Fejlesztők véleményei",
    content: "Pozitív: gyorsítja a munkát. Negatív: néha pontatlan, vagy túl „okos”.",
    image: "https://builtin.com/sites/default/files/styles/ckeditor_optimize/public/inline-images/github-copilot-1.png",
  },
  {
    title: "Etikai kérdések",
    content: "Kié a generált kód? Jogilag és erkölcsileg is vitatott terület.",
    image: "https://miro.medium.com/v2/resize:fit:1200/format:webp/1*bnoA9DmlLNO3bCmD71Y0aA.png",
  },
  {
    title: "A jövő: Copilot X",
    content: "Chat-alapú Copilot, terminál és pull request magyarázatok, még okosabb támogatás.",
    image: "https://github.blog/wp-content/uploads/2023/03/copilot-x.png",
  },
  {
    title: "Alternatívák",
    content: "Amazon CodeWhisperer, TabNine, Replit Ghostwriter – de Copilot a legismertebb.",
    image: "https://miro.medium.com/v2/resize:fit:1200/format:webp/1*iUwTLaYf0R1-BN_9cQ5elQ.png",
  },
  {
    title: "Összegzés",
    content: "Copilot egy eszköz, nem varázslat. Jól használva hatalmas segítség lehet a fejlesztésben.",
    image: "https://images.ctfassets.net/h67z7i6sbjau/6VV3FQUz5cuGBGJEljEU8g/62dc44b4c3a77a79cf180a9b8f5b18d7/copilot-intro.png",
  },
  {
    title: "Személyes véleményem",
    content: "Hasznos segédeszköz, de nem szabad elfelejteni gondolkodni közben. Az AI nem helyettesíti a tudást.",
    image: "https://media.giphy.com/media/qgQUggAC3Pfv687qPC/giphy.gif",
  },
  {
    title: "Köszönöm a figyelmet!",
    content: "Kérdések? Kommentek? Bugok?",
    image: "https://media.giphy.com/media/l0MYt5jPR6QX5pnqM/giphy.gif",
  },
];

export default slides;
