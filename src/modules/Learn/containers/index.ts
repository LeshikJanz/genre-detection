import { connect } from 'react-redux';
import { Learn } from "../components/index";
import { educationInit, getRubricsInit, updateRubricInit } from "../../actions";
import { compose, lifecycle, withState } from 'recompose';

const mapStateToProps: any = (state): any => ({
  allRubrics: state.rubrics
});

const mapDispatchToProps = (dispatch) => {
  return {
    addSample: (text) => dispatch(educationInit(text)),
    getRubrics: () => dispatch(getRubricsInit()),
    updateRubric: (rubric) => dispatch(updateRubricInit(rubric))
  }
};

export default compose(
  connect(mapStateToProps, mapDispatchToProps, null),
  lifecycle({
    componentDidMount() {
      this.props.getRubrics();
    }
  }))
(Learn);
