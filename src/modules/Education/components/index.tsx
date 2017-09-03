import * as React from 'react';
import '../styles/styles.scss';

export const Education = () => {

  const handleEducation = () => {
    console.log('handleEducation')
  }

  return (
    <div className="education-container">
      <button className="primary education-button" onClick={handleEducation}>
        Начать обучение
      </button>
    </div>
  )
}