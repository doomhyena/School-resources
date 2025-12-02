import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import logo from '../logo.svg';
import styled from 'styled-components';
import { ButtonContainer } from './Button';
import { ThemeContext } from './context/ThemeContexts';
import { FaRegMoon } from 'react-icons/fa';
import { GoSun } from 'react-icons/go';
import { AiOutlineMenu } from 'react-icons/ai'
import { ProductConsumer } from '../context';
import { NavLink } from 'react-router-dom';

class Navbar extends Component {
  static contextType = ThemeContext;

  constructor(props) {
    super(props);
    this.state = {
      isMobile: window.innerWidth <= 768, //Töréspont igazítása
      menuOpen: false,
    };

    this.handleResize = this.handleResize.bind(this);
    this.handleMenu = this.handleMenu.bind(this);
  }

  componentDidMount() {
    ...('...', this.handleResize); //Újraméretezési művelet figyelő az ablakra
  }

  componentWillUnmount() {
    ...('...', this.handleResize); //Újraméretezési művelet figyelő levétele az ablakról
  }

  handleResize() {
    this.setState({
      isMobile: window.innerWidth <= 768, //Töréspont igazítása
    });
  }

  handleMenu() {
    this.setState((prevState) => ({ menuOpen: !prevState.menuOpen }));
  }

  render() {
    const { theme, toggleTheme } = this.context;
    const { isMobile, menuOpen } = this.state;

    return (
      <div>
        {isMobile ? (
          //Mobil nézet:
          <MobileNavWrapper className="navbar nav-bar-expand-sm bg-slate-800 px-sm-5 w-100">
            <Link to="/" className="w-50">
              <img src={logo} alt="store" className="navbar-brand" />
            </Link>
            <div className="text-white w-50 menu" onClick={this.handleMenu}>
              <AiOutlineMenu className="menubar" />
            </div>
            {menuOpen && (
              <div className=" resmenu w-100 ">
                <NavLink to="/" className={({ isActive }) => isActive ? "text-primary" : "text-white hover"}>
                  Products
                </NavLink>
                <ProductConsumer>
                  {value => (<li style={{
                    listStyleType: 'none'
                  }}>
                    <input placeholder='Search for products' onChange={(e) => {
                      value.filterProducts(e.target.value);
                    }}>
                    </input>
                  </li>)
                  }
                </ProductConsumer>
                <Link className="text-white bg-transparent themes" onClick={toggleTheme}>
                  {theme ? <h6>Dark Mode <FaRegMoon /></h6> : <h6>Light Mode <GoSun /></h6>}
                </Link>
                <... className="ml-auto"> //Kosárhoz vezető link deklarációja
                  <ButtonContainer>
                    <i className="fas fa-cart-plus">my cart</i>
                  </ButtonContainer>
                </Link>
              </div>
            )}
          </MobileNavWrapper>
        ) : (
          //Asztali nézet:
          <DesktopNavWrapper className="navbar nav-bar-expand-sm bg-slate-800 px-sm-5">
            <Link to="/">
              <img src={logo} alt="store" className="navbar-brand" />
            </Link>
            <ul className="navbar-nav align-items-center">
              <li className="nav-item ml-5">
                <Link to="/" className="nav-link">
                  Products
                </Link>
              </li>
            </ul>
            <ul className="navbar-nav align-items-center">
              <ProductConsumer>
                {value => (<li className="nav-item ml-5">
                  <input placeholder='Search for products' onChange={(e) => {
                    value.filterProducts(e.target.value);
                  }}>
                  </input>
                </li>)
                }
              </ProductConsumer>
            </ul>
            <... className="ml-auto"> //Kosárhoz vezető link deklarációja
              <ButtonContainer>
                <i className="fas fa-cart-plus">my cart</i>
              </ButtonContainer>
            </Link>
            <div className="text-white bg-transparent themes mainmenu" onClick={toggleTheme}>
              {theme ? <FaRegMoon /> : <GoSun />}
            </div>
          </DesktopNavWrapper>
        )}
      </div>
    );
  }
}

const NavWrapper = styled.nav`
  .nav-link {
    color: var(--mainWhite) !important;
    font-size: 1.3rem;
    text-transform: capitalize;
  }
`;

const MobileNavWrapper = styled(NavWrapper)`
  /* Mobilos formázások hozzáadása, ha kell */
`;

const DesktopNavWrapper = styled(NavWrapper)`
  /* Asztali formázások hozzáadása, ha kell */
`;

...; //Alapraméretezetten exportáljuk Navbar néven ezt a kódot
