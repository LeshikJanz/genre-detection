import { put, takeEvery, select } from 'redux-saga/effects'
import {
  educationInit, educationError, getRubricsInit, getRubricsDone, educationDone,
  getSamplesDone, getSamplesInit
} from "../actions";
import { Task } from "redux-saga";
import { getRubrics } from "api/rubric";
import { createNewSample, getSamples } from "../../api/sample";
import { ISample } from "interfaces";

export function* educationInitSaga({ payload }: ISample): Iterator<Object | Task> {
  try {
    yield createNewSample(payload);
    yield put(educationDone());
  } catch (error) {
    yield put(educationError(error));
    console.error(error);
  }
}

export function* getRubricsSaga(): Iterator<Object | Task> {
  try {
    const rubrics = yield getRubrics();
    yield put(getRubricsDone(rubrics))
  } catch (error) {
    console.error(error);
  }
}

export function* getSamplesSaga(): Iterator<Object | Task> {
  try {
    const samples = yield getSamples();
    yield put(getSamplesDone(samples))
  } catch (error) {
    console.error(error);
  }
}


export function* learnSaga() {
  yield takeEvery(educationInit().type, educationInitSaga);
  yield takeEvery(getRubricsInit().type, getRubricsSaga);
  yield takeEvery(getSamplesInit().type, getSamplesSaga);
}