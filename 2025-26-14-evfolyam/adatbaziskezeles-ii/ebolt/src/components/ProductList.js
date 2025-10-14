import React from 'react';
import Product from './Product';
import Title from './Title';
import { ProductConsumer } from '../context';
import { ThemeConsumer } from './context/ThemeContexts';
//"ProductList" osztály létrehozása és elérhetővé tétele (amely a React Component osztályából öröklődik):
class ProductList extends React.Component {
  render() {
    return (
      <ThemeConsumer>
        {({ theme }) => (
          <ProductConsumer>
            {(value) => (
              value.products.length > 0 ?	//Ha van termék-találat
                <div className={theme ? 'py-5 bg-slate-900' : 'py-5 bg-slate-200'}>
                  <div className="container">
                    <div>
                      <Title className="text-light" name="our" title="products" />
                      <div className="row">
                        {value.products.map((product) => {
                          return <Product key={product.id} product={product} />;
                        })}
                      </div>
                    </div>
                  </div>
                </div>
                :	//Ha nincs terméktalálat, akkor mást írjon ki
                <div className={theme ? 'py-5 bg-slate-900' : 'py-5 bg-slate-200'}>
                  <div className="row">
                    <div className="col-10 mx-auto text-center text-title text-primary">
                      <text style={{
                        color: 'red'
                      }}>Bocsi, de nincs találat!</text>
                    </div>
                    <div className="col-10 mx-auto text-center text-title text-primary">
                      <text style={{
                        color: 'balck'
                      }}>Ellenőrizd, hogy jól írtad-e be</text>
                    </div>
                  </div>
                </div>

            )
            }
          </ProductConsumer>
        )}
      </ThemeConsumer>
    );
  }
}
//Ezen kód elérhetővé tétele a többi fájl számára "ProductList" néven:
export default ProductList;
