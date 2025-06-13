import SearchActionTypes from "./enum";

async function onGetDonationCenters(dispatch: any, payload: any) {
  dispatch({
    type: SearchActionTypes.getDonationCenters,
    payload: payload,
  });
}

async function onFilterDonationCentersByAddress(dispatch: any, payload: any) {
  dispatch({
    type: SearchActionTypes.filterDonationCentersByAddress,
    payload: payload,
  });
}

async function onFilterDonationCentersByName(dispatch: any, payload: any) {
  dispatch({
    type: SearchActionTypes.filterDonationCentersByName,
    payload: payload,
  });
}

const SearchActionFactory = (dispatch: any) => {
  return {
    onGetDonationCenters: (payload: any) => onGetDonationCenters(dispatch, payload),
    onFilterDonationCentersByAddress: (payload: any) => onFilterDonationCentersByAddress(dispatch, payload),
    onFilterDonationCentersByName: (payload: any) => onFilterDonationCentersByName(dispatch, payload),
  };
};

export default SearchActionFactory;
