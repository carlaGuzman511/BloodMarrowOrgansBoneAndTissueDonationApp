import InformationActionTypes from "./enum";

async function onGetInformation(dispatch: any, payload: any) {
  dispatch({
    type: InformationActionTypes.getInformation,
    payload: payload,
  });
}

const InformationActionFactory = (dispatch: any) => {
  return {
    onGetInformation: (payload: any) => onGetInformation(dispatch, payload),
  };
};

export default InformationActionFactory;
