import * as React from "react";

export const Main = () => {

  const handleSubmit = (form) => {
    console.log('form');
    console.log(form);
    const array = [];
    array['abc'] = 1;
    console.log('array');
    console.log(array);
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <textarea name="text" id="" cols="30" rows="10"></textarea>
        <button type="submit">Submit</button>
      </form>
    </div>
  )
};