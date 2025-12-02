import React, { Component } from "react";
import { storeProducts, detailProduct } from "./data";
const ProductContext = React.createContext(); //Ebbe foglaljuk bele a vázat

class ProductProvider extends Component {
    state = {
        products: [],
        detailProduct: detailProduct,
        cart: [],
        modalOpen: false,
        modalProduct: detailProduct,
        cartSubTotal: 0,
        cartTax: 0,
        cartTotal: 0
    };
    componentDidMount() {
        this.setProducts();
    }
	//Szűrés a termékekre szöveg alapján:
    filterProducts = (value) => {
        value = value.toLowerCase();//Hogy a kis-nagy betű különbség ne kavarjon be
        let products = [];
        storeProducts.forEach(item => {
            if(item.title.toLowerCase().includes(value) || item.info.toLowerCase().includes(value)){ //a terméknév és leírás átnézése
                const singleItem = { ...item };
                products = [...products, singleItem];
            }
        });
        this.setState(() => {
            return { products };
        }, this.checkCartItems);
    }

    setProducts = () => {
        let products = [];
        storeProducts.forEach(item => {
            const singleItem = { ...item }; //... = határozatlan elemszám
            products = [...products, singleItem];
        });
        this.setState(() => {
            return { products };
        }, this.checkCartItems);
    };

    getItem = id => {
        const product = this.state.products.find(item => item.id === id);
        return product;
    };
    handleDetail = id => {
        const product = this.getItem(id);
        this.setState(() => {
            return { detailProduct: product };
        });
    };
	//Kosárhoz adás:
    addToCart = id => {
        let tempProducts = [...this.state.products];
        const index = tempProducts.indexOf(this.getItem(id));
        const product = tempProducts[index];
        product.inCart = true;
        product.count = 1;
        const price = product.price;
        product.total = price;

        this.setState(() => {
            return {
                products: [...tempProducts],
                cart: [...this.state.cart, product],
                detailProduct: { ...product }
            };
        }, this.addTotals);
    };
    openModal = id => {
        const product = this.getItem(id);
        this.setState(() => {
            return { modalProduct: product, modalOpen: true };
        });
    };
    closeModal = () => {
        this.setState(() => {
            return { modalOpen: false };
        });
    };
	//Kosárban lévő adott termék mennyiségénk növelése:
    increment = id => {
        let tempCart = [...this.state.cart];
		//Az ID-je alapján azonosítjuk:
        const selectedProduct = tempCart.find(item => {
            return item.id === id;
        });
        const index = tempCart.indexOf(selectedProduct);
        const product = tempCart[index];
        product.count = product.count + 1;
        product.total = product.count * product.price; //Az ár is kövesse a változást
        this.setState(() => {
            return {
                cart: [...tempCart]
            };
        }, this.addTotals);
    };
	//Kosárban lévő adott termék mennyiségénk csökkentése:
    decrement = id => {
        let tempCart = [...this.state.cart];
		//Az ID-je alapján azonosítjuk:
        const selectedProduct = tempCart.find(item => {
            return item.id === id;
        });
        const index = tempCart.indexOf(selectedProduct);
        const product = tempCart[index];
        product.count = product.count - 1;
        if (product.count === 0) {
            this.removeItem(id);
        } else {
            product.total = product.count * product.price; //Az ár is kövesse a változást
            this.setState(() => {
                return { cart: [...tempCart] };
            }, this.addTotals);
        }
    };
	//Végösszegek (+adó) kiszámítása:
    getTotals = () => {
        let subTotal = 0; //Adók előtti végösszeg
        this.state.cart.map(item => (subTotal += item.total));//Termékenként nézz meg az ahhoz rendelt árat
        const tempTax = subTotal * 0.1;//10% adó
        const tax = parseFloat(tempTax.toFixed(2));//2 tizedesre kerekítés
        const total = subTotal + tax;
        return {
            subTotal,
            tax,
            total
        };
    };
	//Fizetendő összegek átvitele a megfelelő mezőkbe/változókba:
    addTotals = () => {
        const totals = this.getTotals();
        this.setState(
            () => {
                return {
                    cartSubTotal: totals.subTotal,
                    cartTax: totals.tax,
                    cartTotal: totals.total
                };
            },
            () => {
                // console.log(this.state);
            }
        );
    };
	//Egy termék eltávolítása a kosárból:
    removeItem = id => {
        let tempProducts = [...this.state.products];
        let tempCart = [...this.state.cart];

        const index = tempProducts.indexOf(this.getItem(id));
        let removedProduct = tempProducts[index];
        removedProduct.inCart = false;
        removedProduct.count = 0;
        removedProduct.total = 0;

        tempCart = tempCart.filter(item => {
            return item.id !== id;
        });

        this.setState(() => {
            return {
                cart: [...tempCart],
                products: [...tempProducts]
            };
        }, this.addTotals);
    };
	//Teljes kosár ürítése:
    clearCart = () => {
        this.setState(
            () => {
                return { cart: [] };
            },
            () => {
                this.setProducts();
                this.addTotals();
            }
        );
    };
	//Hogy minden eddigi függvény megfelelően behívódjon/működjön:
    render() {
        return (
            <ProductContext.Provider
                value={{
                    ...this.state,
                    handleDetail: this.handleDetail,
                    addToCart: this.addToCart,
                    openModal: this.openModal,
                    closeModal: this.closeModal,
                    increment: this.increment,
                    decrement: this.decrement,
                    removeItem: this.removeItem,
                    clearCart: this.clearCart,
                    filterProducts: this.filterProducts
                }}
            >
                {this.props.children}
            </ProductContext.Provider>
        );
    }
}

const ProductConsumer = ProductContext.Consumer;
//Ezek elérhetővé tétele a projekt többi részében:
export { ProductProvider, ProductConsumer };
