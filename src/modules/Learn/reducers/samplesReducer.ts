import { createReducer } from 'utils/createReducer';
import { IRubric } from "interfaces";
import { getSamplesDone } from "../../actions";

/**
 * Initial state for sample reducer
 */
const initialState = [];

export default createReducer({
    [getSamplesDone]: (state: any, payload: IRubric[]) => ([
      ...state,
      ...payload
    ])
  },
  initialState
);
