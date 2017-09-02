import * as React from "react";
import { urls } from "urls";
import { Link } from 'react-router';
import './styles/style.scss';

export const Header = (props) => (
  <div>
    <div className="header-container main-container">
      <h1>Welcome!</h1>
      <div className="link-container">
        <Link to={urls.learn}>Learn</Link>
        <Link to={urls.registration}>Registration</Link>
      </div>
    </div>
    {props.children}
  </div>

);