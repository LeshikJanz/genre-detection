import { combineReducers } from "redux";
import { routerReducer } from "react-router-redux";
import rubricReducer from "modules/Learn/reducers/rubricsReducer";
import sampleReducer from "modules/Learn/reducers/samplesReducer";

export default combineReducers({
  routing: routerReducer,
  rubrics: rubricReducer,
  samples: sampleReducer
});
