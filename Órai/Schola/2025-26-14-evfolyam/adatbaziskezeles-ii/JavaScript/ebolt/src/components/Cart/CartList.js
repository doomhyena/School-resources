...//React importálása
...//CartItem beimportálása a megfelelő helyről

... ... function CartList({value}) { //Egyből exportáljuk, alapraméretezett függvény lesz
    const { cart} =value;
   
    return (
     <div className="container-fluid">
         {cart.map(item=>{ //(A map() ráhúz egy megadott műveletet a lista/tömb összes elemére, és visszaadja egy új listaként)
             return <CartItem key={item.id} item={item} value={value}/>
         })} 
    </div>
    );
}
