import * as React from 'react';

export const Learn = (props) => {


  const handleSubmit = (e) => {
    e.preventDefault();

    console.log('sample');
    console.log(e.target.sample.value);
  }

  return (
    <form onSubmit={handleSubmit}>
      <textarea name="sample" id="" cols="30" rows="10"></textarea>
      <button type="submit">Submit</button>
    </form>
  )
}