/**
 * Identifiable interface
 */
export
declare interface Identifiable {
  id?: any;
}

/**
 * Decision interface
 */
export
declare interface IDecision {
  name: string,
  freq: number
}

/**
 * Rubric interface
 */
export
declare interface IRubric extends Identifiable {
  name: string,
  samplesCount: number,
  funDecisions?: IDecision[]
}

/**
 * Knowledge interface
 */
export
declare interface ISample extends Identifiable {
  dictionaries: IDecision[],
  vectors?: IDecision[],
  rubricId: string
}