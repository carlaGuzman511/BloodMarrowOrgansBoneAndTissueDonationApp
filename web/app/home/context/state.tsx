import { produce } from "immer";
import { HomeStateType, Action } from "./../../types/context";
import HomeActionTypes from "./enum";
import { DonationPost } from "@/models/App.types";

export function State() {
  return {
    donationPosts: new Array<DonationPost>(),
  };
}

export function Reducer(state: HomeStateType, action: Action) {
  const { type, payload } = action;
  switch (type) {
    case HomeActionTypes.getDonationPosts:
      return produce(state, (draft: any) => {
        draft.donationPosts = payload.donationPosts;
      });
    default:
      return state;
  }
}