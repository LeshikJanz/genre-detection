import { request } from "./base";
import { ISample } from "interfaces";

export const createNewSample = (sample: ISample) => {
  return request
    .post(`Samples`, sample)
    .then((sample: ISample) => sample);
};

export const getSamples = () => {
  return request
    .get(`Samples`, {})
    .then((samples: ISample[]) => samples);
};
