import React, { createContext, Component } from 'react';

const ThemeContext = createContext();

class ThemeProvider extends Component { //A ThemeProvider osztály a Component osztály utódosztálya
  state = {
    theme: false,
  };

  toggleTheme = () => {
    this.setState((prevState) => ({ ... })); //Ezesetben a theme állítódjon a prevState.theme ellenkező állapotára
  };

  render() {
    return (
      <ThemeContext.Provider value={{ theme: this.state.theme, toggleTheme: this.toggleTheme }}>
        {this.props.children}
      </ThemeContext.Provider>
    );
  }
}

const ThemeConsumer = ThemeContext.Consumer;

... { ... }; //Tegyük elérhetővé a projekt többi részében a ThemeProvider, ThemeConsumer és ThemeContext elemeket
