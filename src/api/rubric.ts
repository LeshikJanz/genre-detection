import { request } from "./base";
import { IRubric } from "interfaces";

export const getRubrics = () => {
  return request
    .get(`Rubrics`, {})
    .then((rubrics: IRubric[]) => rubrics);
};

export const updateRubricById = (rubric: IRubric) => {
  return request
    .put(`Rubrics/${rubric.id}`, rubric)
    .then((rubrics: IRubric[]) => rubrics);
};
