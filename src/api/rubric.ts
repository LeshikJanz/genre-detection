import { request } from "./base";
import { IRubric } from "interfaces";

export const getRubrics = () => {
  return request
    .get(`Rubrics`, {})
    .then((rubrics: IRubric[]) => rubrics);
};
