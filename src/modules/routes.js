import React from 'react';
import { Route, IndexRoute } from 'react-router';
import { urls } from "urls";
import { Base } from "./Main/Base";
import { Main } from "./Main/index";
import { Header } from "./Header/index";

/**
 * Routing between pages using React-Router-Redux
 *
 * See: https://github.com/reactjs/react-router-redux
 */
export default (
  <Route path={urls.index} component={Header}>
    <Route component={Base}>
      <IndexRoute component={Main}/>
    </Route>
  </Route>
);