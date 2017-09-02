import * as React from 'react';
import './styles/style.scss';

export const Learn = (props) => {

  const handleSubmit = (e) => {
    e.preventDefault();
    const { name, language, text } = e.target;
  }

  return (
    <form onSubmit={handleSubmit}>
      <div className="form-element">
        <label htmlFor="name">Наименование рубрики</label>
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
      <button className="primary" type="submit" disabled={props.invalid}>Submit</button>
    </form>
  )
}