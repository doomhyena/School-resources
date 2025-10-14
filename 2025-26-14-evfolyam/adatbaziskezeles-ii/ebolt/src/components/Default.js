//Alap hibaoldal arra az esetre, ha nem sikerült betölteni a dolgokat
import React, { Component } from 'react'
//"Default" osztály létrehozása és elérhetővé tétele (amely a Component osztályból öröklődik):
export default class Default extends Component {
    render() {
        console.log(this.props);//Mögöttes ellenőrzéshez
        return (
            <div className="container">
                <div className="row">
                    <div className="col-10 mx-auto text-center text-title">
                        <h1>Hiba</h1>
                        <h1 className="display-3">404</h1>
                        <h2>Az oldal nem jó</h2>
                        <h3>Az URL 
                            <span className="text-danger">
                              {this.props.location.pathname}
                            </span>{""}
                            nem található</h3>
                    </div>
                </div>
            </div>
        )
    }
}
