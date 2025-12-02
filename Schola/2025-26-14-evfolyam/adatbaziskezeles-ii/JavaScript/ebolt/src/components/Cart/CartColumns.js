...//React beimportálása
import { ThemeConsumer } from '../context/ThemeContexts';

...//Egy kiexportált, alapraméretezett, CartColumns nevű függvény
    return (
        <ThemeConsumer>
        {({ theme }) => (
        <div className="container-fluid text-center d-none d-lg-block">
          <div ...> //Ez a div egy sor legyen
               <div className="col-10 mx-auto col-lg-2">
                   <p className={theme ? "text-uppercase text-light" : "text-uppercase"}>Termékek</p>  
               </div>
                <div className="col-10 mx-auto col-lg-2">
                    <p className={theme ? "text-uppercase text-light" : "text-uppercase"}>Termék neve</p>
                </div>
                <div className="col-10 mx-auto col-lg-2">
                    <p className={theme ? "text-uppercase text-light" : "text-uppercase"}>ár</p>
                </div>
                <div className="col-10 mx-auto col-lg-2">
                    <p className={theme ? "text-uppercase text-light" : "text-uppercase"}>mennyiség</p>
                </div>
                <div className="col-10 mx-auto col-lg-2">
                    <p className={theme ? "text-uppercase text-light" : "text-uppercase"}>töröl</p>
                </div>
                <div className="col-10 mx-auto col-lg-2">
                    <p className={theme ? "text-uppercase text-light" : "text-uppercase"}>összesen</p>
                </div>
          </div>   
        </div>
          )}
          </ThemeConsumer>
    )
}
