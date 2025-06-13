import React, { useContext, useReducer, useState } from "react";
import { InformationContextType } from "./../../types/context";
import InformationActionFactory from "./action";
import { State, Reducer } from "./state";

const InformationContext = React.createContext<InformationContextType | null>(null);
const InformationDispatch = React.createContext<any>(null);

interface IProps {
  children: React.ReactNode;
}

export function InformationContextProvider(props: IProps) {
  const { children } = props;
  const [value, dispatch] = useReducer(Reducer, props, State);
  const [actions] = useState(InformationActionFactory(dispatch));
  return (
    <InformationContext.Provider value={value}>
      <InformationDispatch.Provider value={actions}>
        {children}
      </InformationDispatch.Provider>
    </InformationContext.Provider>
  );
}

export function useInformationContext() {
  const state = useContext(InformationContext);
  const actions = useContext(InformationDispatch);
  return [state, actions];
}