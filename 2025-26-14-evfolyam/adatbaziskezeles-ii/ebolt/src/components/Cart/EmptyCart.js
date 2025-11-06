... //React importálása
import { Link } from 'react-router-dom/cjs/react-router-dom'
import { ButtonContainer } from '../Button'

...//Alapraméretezett, EmptyCard nevű függvény, amelyet ki is exportálunk
    return (
        <div className="container mt-5">
            <div className="row">
                <div className="col-10 mx-auto text-center text-title text-primary">
                    <...> //Egy szöveges elem írja ki, hogy a kosár üres
                </div>
                <div className="col-10 mx-auto  text-center">
                    <Link to="/">
                        <ButtonContainer>
                            vissza a vásárláshoz
                        </ButtonContainer>
                    ...
					//Az összes elem és zárójel megfelelő bezárása