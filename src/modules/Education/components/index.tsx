import * as React from 'react';
import '../styles/styles.scss';
import { is } from "redux-saga/utils";

export const Education = ({ rubrics, samples }) => {
    const generateСharacteristicVector = (fullDictionary) =>
      rubrics.map(r => ({
        ...r,
        characteristicVector: [
          ...fullDictionary.map(f => r.dictionaries.find(d => d.name == f.name) || {
            ...f,
            freq: 0
          }),
          { freq: 0.000001 }],
        weightVectors: [...fullDictionary.map(f => 0), 0]
      }));

    const multiplyVectors = (v1, v2) => v1.reduce((sum, elem, i) => sum + elem * v2[i], 0);

    const decrementFun = (v1, v2) => v1.map((w, i) => v2[i] - w);

    const incrementFun = (v1, v2) => v1.map((w, i) => w + v2[i]);

    const checkAppropriarity = (updatedRubrics) => {
      let isAppropriate;

      do {
        isAppropriate = false;

        for (let i = 0; i < updatedRubrics.length; i++) {
          let isCorrected = false;
          for (let j = 0; j < updatedRubrics.length; j++) {
            updatedRubrics[j].decisionCoefficient = multiplyVectors(updatedRubrics[i].characteristicVector.map(c => c.freq),
              updatedRubrics[j].weightVectors);
          }
          for (let j = 0; j < updatedRubrics.length; j++) {
            if (i !== j) {
              if (updatedRubrics[i].decisionCoefficient <= updatedRubrics[j].decisionCoefficient) {
                isCorrected = isAppropriate = true;
                updatedRubrics[j].weightVectors = decrementFun(updatedRubrics[i].characteristicVector.map(c => c.freq), updatedRubrics[j].weightVectors);
              }
            }
          }
          if (isCorrected) {
            updatedRubrics[i].weightVectors = incrementFun(updatedRubrics[i].characteristicVector.map(c => c.freq), updatedRubrics[i].weightVectors);
          }
        }
      }
      while (isAppropriate);
    }

    const generateFunDecisions = (rubricsWithCharacteristicVector) => {
      const updatedRubrics = rubricsWithCharacteristicVector.map(r => ({
        ...r,
        decisionCoefficient: multiplyVectors(r.characteristicVector.map(c => c.freq), r.weightVectors)
      }));

      checkAppropriarity(updatedRubrics);
    };

    const handleEducation = () => {
      const fullDictionary = rubrics.reduce((sum, r) => sum.concat(r.dictionaries), []);
      const rubricsWithCharacteristicVector = generateСharacteristicVector(fullDictionary);
      const funDecision = generateFunDecisions(rubricsWithCharacteristicVector);
    };

    return (
      <div className="education-container">
        <button className="primary education-button" onClick={handleEducation}>
          Начать обучение
        </button>
      </div>
    )
  }
;