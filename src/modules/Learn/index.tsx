import * as React from 'react';
import './styles/style.scss';
import { DELIMETER_CHARS, STOP_WORDS, NUMBER_KEY_WORDS, DELIMETER_CHARS_REG } from "./constants/index";
import * as _ from 'lodash';

export const Learn = (props) => {
  const updateFrequence = (m, word: string) => {
    if ( word.length > 3 && !STOP_WORDS.find(w => w === word) ) {
      return m.has(word) ? m && m.set(word, m.get(word) + 1) : m && m.set(word, 1)
    }
    return m;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const { name, language, text } = e.target;
    const regex = new RegExp(`[${DELIMETER_CHARS_REG}]+`, 'g');

    let wordsDict = [];
    _.words(text.value.toLowerCase(), regex)
      .reduce(updateFrequence, new Map())
      .forEach((w, i) => wordsDict.push({ name: i, freq: w }));

    wordsDict = wordsDict.sort((a, b) => b.freq - a.freq)
      .slice(0, NUMBER_KEY_WORDS);

    console.log('wordsDict');
    console.log(wordsDict);
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="form-element">
        <label htmlFor="name">Рубрики</label>
        <input name="name" type="text"/>
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
      <button className="primary" type="submit" disabled={props.invalid}>Отправить</button>
    </form>
  )
}