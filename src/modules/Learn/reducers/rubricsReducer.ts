import { createReducer } from 'utils/createReducer';
import { getRubricsDone } from "../../actions";
import { IRubric } from "interfaces";

/**
 * Initial state for rubric reducer
 */
const initialState = [];

export default createReducer({
    [getRubricsDone]: (state: any, payload: IRubric[]) => ([
      ...state,
      ...payload
    ])
  },
  initialState
);
