import { connect } from 'react-redux';
import { getSamplesInit, getRubricsInit, educationInit } from "modules/actions";
import { Education } from "../components/index";
import { compose, lifecycle, withState } from 'recompose';

const mapStateToProps: any = (state): any => ({
  rubrics: state.rubrics
});

const mapDispatchToProps = (dispatch) => {
  return {
    addSample: (text) => dispatch(educationInit(text)),
    getRubrics: () => dispatch(getRubricsInit()),
  }
};

export default compose(
  connect(mapStateToProps, mapDispatchToProps, null),
  lifecycle({
    componentDidMount() {
      this.props.getRubrics();
    }
  }))
(Education);
