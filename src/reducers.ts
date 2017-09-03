import { combineReducers } from "redux";
import { routerReducer } from "react-router-redux";
import learnReducer from "modules/Learn/reducers/learnReducer";

export default combineReducers({
  routing: routerReducer,
  rubrics: learnReducer
});
