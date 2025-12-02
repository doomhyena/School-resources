import React, { Component } from 'react'
import Title from '../Title';
import CartColumns from './CartColumns';
import EmptyCart from './EmptyCart';
import { ProductConsumer} from '../../context';
import CartList from './CartList';
import CartTotals from "./CartTotals";

...//Store osztály, ami a Component-ből öröklődik, alapraméretezett és ki is exportáljuk
    render() {
        return (
            <section>
                <ProductConsumer>
                    {value => {
                        const { cart } = value;
                        if (...) { //Ha nem üres a cart tartalma
                            return (
                                <React.Fragment>
                                    <div className='h-full'>
                                    <Title name="A Te" title="kosarad" />
                                    <CartColumns />
                                    <CartList value={value} />
                                    <CartTotals value={value} history={this.props.history} />
                                    </div>
                                </React.Fragment>
                            );
                        } else {
                            return(
                                <div className='h-full'>
                                    <EmptyCart />;
                                </div>
                            )
                            
                        }
                    }}
                </ProductConsumer>
            </section>
        );
    }
}
