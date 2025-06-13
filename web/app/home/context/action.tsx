import HomeActionTypes from "./enum";

async function onGetDonationPosts(dispatch: any, payload: any) {
  dispatch({
    type: HomeActionTypes.getDonationPosts,
    payload: payload,
  });
}

const HomeActionFactory = (dispatch: any) => {
  return {
    onGetDonationPosts: (payload: any) => onGetDonationPosts(dispatch, payload),
  };
};

export default HomeActionFactory;
