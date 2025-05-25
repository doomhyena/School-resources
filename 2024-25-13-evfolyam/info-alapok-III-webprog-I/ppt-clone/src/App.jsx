import { useState } from "react";
import Slide from './components/Slide.jsx';
import slides from './data/slides.js';

function App() {
  const [index, setIndex] = useState(0);

  return (
    <div className="relative">
      <Slide slide={slides[index]} index={index} />

      <div className="absolute bottom-8 left-0 right-0 flex justify-between px-8">
        
        <button onClick={() => setIndex(Math.max(0, index - 1))} className="btn">Előző</button>
        <button onClick={() => setIndex(Math.min(slides.length - 1, index + 1))} className="btn">Következő</button>
      </div>
    </div>
  );
}

export default App;
