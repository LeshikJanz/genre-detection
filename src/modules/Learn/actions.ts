import { createAction } from "utils/createAction";

export const getRubricsInit = createAction('GET_RUBRICS_INIT');
export const getRubricsDone = createAction('GET_RUBRICS_DONE');
export const getRubricsError = createAction('GET_RUBRICS_ERROR');

export const educationInit = createAction('EDUCATION_INIT');
export const educationDone = createAction('EDUCATION_DONE');
export const educationError = createAction('EDUCATION_ERROR');
