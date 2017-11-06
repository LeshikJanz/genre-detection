import * as React from 'react';
import '../styles/styles.scss';

export const Education = ({ rubrics, samples }) => {

  const getVectors = () => samples.map(s => [...samples.map(m => m.dictionaries)])
    .map((v) => v.reduce((sum, k) => sum.concat(k)).concat({ freq: 0.01 }));

  const getEmptyFunctions = () =>
    rubrics.map(r => new Array(getVectors()[0].length).fill(0));

  const getRubricsWithInitVectorsAndFunDecisions = (vectors) => {
    const emptyFunctions = getEmptyFunctions();

    return rubrics.map((r, i) => {
      r.vectors = vectors.filter(s => s.rubricId === r.id);
      r.funDecions = emptyFunctions[i];
      return r;
    });
  };

  const getFunDecisions = () => {
    const vectors = getVectors();
    console.log('vectors');
    console.log(vectors);
    rubrics = getRubricsWithInitVectorsAndFunDecisions(vectors);
    console.log('rubrics');
    console.log(rubrics);

    let isFunctionsCorrect = false;

    do {
      isFunctionsCorrect = false;
      rubrics.forEach(r => {
        r.vectors.forEach(v => {
          v.forEach((w, i) => {
            w.freq * funDecisions
          })
        })
      })

      // samples.forEach(s => {
      //   if ( s.rubricId === )
      //     })

    } while (isFunctionsCorrect)
  };

  const handleEducation = () => {
    getFunDecisions();
  };

  return (
    <div className="education-container">
      <button className="primary education-button" onClick={handleEducation}>
        Начать обучение
      </button>
    </div>
  )
};