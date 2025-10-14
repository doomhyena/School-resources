//App.js
import React from 'react' //React behívása
import Quiz from './components/Quiz' //Quiz.js tartalmának behívása
import "./App.css" //App.css tartalmának behívása
function App() {
	return (
		<>
			<Quiz/>
		</>
	)
}
//Elérhetővé tétel a többi fájl számára:
export default App