import { produce } from "immer";
import { SearchStateType, Action } from "./../../types/context";
import SearchActionTypes from "./enum";
import { DonationCenter } from "@/models/App.types";

export function State() {
  return {
    donationCenters: new Array<DonationCenter>(),
    filteredDonationCenters: new Array<DonationCenter>(),
  };
}

export function Reducer(state: SearchStateType, action: Action) {
  const { type, payload } = action;
  switch (type) {
    case SearchActionTypes.getDonationCenters:
      return produce(state, (draft: any) => {
        draft.donationCenters = payload.donationCenters;
        draft.filteredDonationCenters = payload.donationCenters;
      });
    case SearchActionTypes.filterDonationCentersByName:
      return produce(state, (draft: any) => {
        draft.filteredDonationCenters = state.donationCenters.filter((donationCenter: DonationCenter) => {
          return donationCenter.name.toLowerCase().includes(payload.toLowerCase());
        })
      });
    case SearchActionTypes.filterDonationCentersByAddress:
      return produce(state, (draft: any) => {
        draft.filteredDonationCenters = state.donationCenters.filter((donationCenter: DonationCenter) => {
          return donationCenter.address.toLowerCase().includes(payload.toLowerCase());
        })
      });
    default:
      return state;
  }
}