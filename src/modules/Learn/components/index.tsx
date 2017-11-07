import * as React from 'react';
import '../styles/style.scss';
import { DELIMETER_CHARS, STOP_WORDS, NUMBER_KEY_WORDS, DELIMETER_CHARS_REG } from "../constants/index";
import * as _ from 'lodash';

export const Learn = ({ allRubrics, updateRubric }) => {
  const updateFrequence = (m, word: string) => {
    if (word.length > 3 && !STOP_WORDS.find(w => w === word)) {
      return m.has(word) ? m && m.set(word, m.get(word) + 1) : m && m.set(word, 1)
    }
    return m;
  };

  const composeDictionaries = (curRubric, newDict) =>
    curRubric.dictionaries ? curRubric.dictionaries.map(d => {
      const word = newDict.find(n => n.name == d.name) || { freq: 0 };
      d.freq = (d.freq * curRubric.samplesCount + word.freq) / (curRubric.samplesCount + 1);
      return d;
    }) : newDict;

  const generateDictionary = (text) => {
    const regex = new RegExp(`[${DELIMETER_CHARS_REG}]+`, 'g');

    let dictionaries = [];
    _.words(text.value.toLowerCase(), regex)
      .reduce(updateFrequence, new Map())
      .forEach((w, i, map) => dictionaries.push({ name: i, freq: w / map.size }));

    return dictionaries.sort((a, b) => b.freq - a.freq)
      .slice(0, NUMBER_KEY_WORDS);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const { rubrics, language, text } = e.target;
    const rubricId = rubrics.options[rubrics.selectedIndex].value;

    // Creating dictionaries for current sample
    const dictionaries = generateDictionary(text);

    // Compose current rubric with sample text
    const curRubric = allRubrics.find(r => r.id === rubricId);
    const commonDict = composeDictionaries(curRubric, dictionaries);

    curRubric.dictionaries = commonDict;
    curRubric.samplesCount = curRubric.samplesCount ? curRubric.samplesCount + 1 : 1;

    updateRubric(curRubric);
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="form-element">
        <label htmlFor="name">Рубрики</label>
        <select name="rubrics">
          {
            allRubrics.map((r, i) => <option key={i} value={r.id}>{r.name}</option>)
          }
        </select>
      </div>
      <div className="form-element">
        <label htmlFor="language">Язык</label>
        <select name="language" id="">
          <option>Русский</option>
          <option>English</option>
          <option>Spanish</option>
          <option>German</option>
        </select>
      </div>
      <div className="form-element">
        <label htmlFor="text">Текст образца</label>
        <textarea name="text" id="" cols="30" rows="10"></textarea>
      </div>
      <button className="primary" type="submit">Отправить</button>
    </form>
  )
}