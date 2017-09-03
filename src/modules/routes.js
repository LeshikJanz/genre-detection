import React from 'react';
import { Route, IndexRoute } from 'react-router';
import { urls } from "urls";
import { Base } from "./Main/Base";
import { Main } from "./Main/index";
import { Header } from "./Header/index";
import { Registration } from "./Registration";
import Learn from "./Learn/containers";
import Education from "./Education/containers";

/**
 * Routing between pages using React-Router-Redux
 *
 * See: https://github.com/reactjs/react-router-redux
 */
export default(
  <Route path={urls.index} component={Header}>
    <Route component={Base}>
      <IndexRoute component={Main}/>
      <Route path={urls.registration} component={Registration}></Route>
      <Route path={urls.learn} component={Learn}></Route>
      <Route path={urls.education} component={Education}></Route>
    </Route>
  </Route>
);