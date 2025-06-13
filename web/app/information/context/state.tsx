import { produce } from "immer";
import { InformationStateType, Action } from "./../../types/context";
import InformationActionTypes from "./enum";
import { Donation } from "@/models/App.types";

export function State() {
  return {
    information: new Array<Donation>(),
    continuationToken: "",
    hasMoreData: true,
  };
}

export function Reducer(state: InformationStateType, action: Action) {
  const { type, payload } = action;
  switch (type) {
    case InformationActionTypes.getInformation:
      return produce(state, (draft: any) => {
        draft.information = payload.information;
      });
       default:
      return state;
  }
}