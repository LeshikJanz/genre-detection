import { learnSaga } from "./Learn/sagas";

/**
 * Function combines sagas
 */
export default function* rootSaga() {
  yield [
    learnSaga(),
  ]
}
