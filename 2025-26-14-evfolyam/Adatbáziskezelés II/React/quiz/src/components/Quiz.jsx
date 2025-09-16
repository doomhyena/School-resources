import React, { useState } from "react";
import QuizData from "../Data/QuizData";
import QuizResult from "./QuizResult";

function Quiz() {
  const [currentQ, setCurrentQ] = useState(0);
  const [score, setScore] = useState(0);
  const [isFinished, setIsFinished] = useState(false);

  const handleAnswer = (option) => {
    if (option === QuizData[currentQ].answer) {
      setScore(score + 1);
    }

    const nextQ = currentQ + 1;
    if (nextQ < QuizData.length) {
      setCurrentQ(nextQ);
    } else {
      setIsFinished(true);
    }
  };

  return (
    <div className="quiz-container">
      {isFinished ? (
        <QuizResult score={score} total={QuizData.length} />
      ) : (
        <div className="question-card">
          <h2>{QuizData[currentQ].question}</h2>
          <div className="options">
            {QuizData[currentQ].options.map((opt, index) => (
              <button key={index} onClick={() => handleAnswer(opt)}>
                {opt}
              </button>
            ))}
          </div>
          <p>
            Kérdés {currentQ + 1} / {QuizData.length}
          </p>
        </div>
      )}
    </div>
  );
}

export default Quiz;