import React from 'react';

function QuizResult({ score, total}) {
    return (
        <div classname="result-container">
            <h2>Kvíz vége!</h2>
            <p>Elért pontszám: {score} / {total}</p>
            <button onClick={() => window.location.reload}>Újra probálom!</button>
        </div>
    )
}

export default QuizResult;