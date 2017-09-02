import * as React from "react";
import { urls } from "urls";
import { Link } from 'react-router';

export const Header = (props) => (
  <div>
    <h1>Welcome!</h1>
    <Link to={urls.index}>Go to main</Link><br/>
    <Link to={urls.learn}>Go to learn page</Link><br/>
    <Link to={urls.registration}>Go to registration</Link><br/>
    {props.children}
  </div>
);