//Az App.js mndig automatikusan létrejön.
//Ez a központi JavaScript fájl a projektben.
import React, { useState, useEffect } from 'react';
import data from './data';
//Behívjuk a másik a másik fájlból az "Article" elemet:
import Article from './Article';

const getStorageTheme = () => {
  let theme = 'light-theme';//Alapból világos megjelenéssel kezd
  if (localStorage.getItem('theme')) {
    theme = localStorage.getItem('theme');
  }
  return theme;
};

function App() {
  const [theme, setTheme] = useState(getStorageTheme());

  const toggleTheme = () => {
	  //Fénymód váltásakor mindig az ellentéte kell:
    if (theme === 'light-theme') {
      setTheme('dark-theme');
    } else {
      setTheme('light-theme');
    }
  };

  useEffect(() => {
    document.documentElement.className = theme;
    localStorage.setItem('theme', theme);
  }, [theme]);
  //Megformázzuk fénymód váltó gombot:
  return (
    <main>
      <nav>
        <div className="nav-center">
          <h1>React pelda</h1>
          <button className="btn" onClick={toggleTheme}>
            váltás
          </button>
        </div>
      </nav>
      <section className="articles">
        {data.map((item) => {
          return <Article key={item.id} {...item} />;
        })}
      </section>
    </main>
  );
}

export default App; //Erre az egészre "App" néven hivatkozhatunk a többi fájlban
