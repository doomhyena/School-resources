import React from 'react'
//Eredmény kiírása:
function QuizResult(props) {
	return (
		<>
		<div className='show-score'>
			A pontszámod:{props.score} <br/>
			Összpontszám:{props.totalScore}
		</div>
		<button id="next-button" onClick={props.tryAgain}>Újra</button>
		</>
	)
}
//Láthatóvá tétel a többi fájlban:
export default QuizResult