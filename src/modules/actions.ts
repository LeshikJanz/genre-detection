import { createAction } from "../utils/createAction";

export const getRubricsInit = createAction('GET_RUBRICS_INIT');
export const getRubricsDone = createAction('GET_RUBRICS_DONE');
export const getRubricsError = createAction('GET_RUBRICS_ERROR');

export const getSamplesInit = createAction('GET_SAMPLES_INIT');
export const getSamplesDone = createAction('GET_SAMPLES_DONE');
export const getSamplesError = createAction('GET_SAMPLES_ERROR');

export const educationInit = createAction('EDUCATION_INIT');
export const educationDone = createAction('EDUCATION_DONE');
export const educationError = createAction('EDUCATION_ERROR');
