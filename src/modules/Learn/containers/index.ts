import { connect } from 'react-redux';
import { Learn } from "../components/index";
import { educationInit, getRubricsInit } from "../actions";
import { compose, lifecycle, withState } from 'recompose';

const mapStateToProps: any = (state): any => ({
  rubrics: state.rubrics
});

const mapDispatchToProps = (dispatch) => {
  return {
    addSample: (text) => dispatch(educationInit(text)),
    getRubrics: () => dispatch(getRubricsInit())
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
