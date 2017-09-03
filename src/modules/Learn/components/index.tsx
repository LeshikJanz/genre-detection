import * as React from 'react';
import '../styles/style.scss';
import { DELIMETER_CHARS, STOP_WORDS, NUMBER_KEY_WORDS, DELIMETER_CHARS_REG } from "../constants/index";
import * as _ from 'lodash';

export const Learn = ({ rubrics, addSample }) => {
  const updateFrequence = (m, word: string) => {
    if ( word.length > 3 && !STOP_WORDS.find(w => w === word) ) {
      return m.has(word) ? m && m.set(word, m.get(word) + 1) : m && m.set(word, 1)
    }
    return m;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const { rubrics, language, text } = e.target;
    const rubricId = rubrics.options[rubrics.selectedIndex].value;

    const regex = new RegExp(`[${DELIMETER_CHARS_REG}]+`, 'g');

    let dictionaries = [];
    _.words(text.value.toLowerCase(), regex)
      .reduce(updateFrequence, new Map())
      .forEach((w, i, map) => dictionaries.push({ name: i, freq: w / map.size }));

    dictionaries = dictionaries.sort((a, b) => b.freq - a.freq)
      .slice(0, NUMBER_KEY_WORDS);

    addSample({ rubricId, dictionaries });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="form-element">
        <label htmlFor="name">Рубрики</label>
        <select name="rubrics">
          {
            rubrics.map((r, i) => <option key={i} value={r.id}>{r.name}</option>)
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