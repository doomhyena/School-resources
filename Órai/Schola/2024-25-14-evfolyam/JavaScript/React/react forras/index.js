import React from "react"; //Alapraméretezett funkciók importálása
import ReactDOM from "react-dom/client"; //Specifikus metódusokhoz, pl. ha a React-on kívüli részeket kell elérni
import "./index.css"; //index.css behivatkozása
import App from "./App"; //App.js behivatkozása

const root = ReactDOM.createRoot(document.getElementById("root")); //React komponensek megjelenítéséhez a böngészőben
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
