import React, { useContext, useReducer, useState } from "react";
import { HomeContextType } from "./../../types/context";
import HomeActionTypes from "./action";
import { State, Reducer } from "./state";

const HomeContext = React.createContext<HomeContextType | null>(null);
const HomeDispatch = React.createContext<any>(null);

interface IProps {
  children: React.ReactNode;
}

export function HomeContextProvider(props: IProps) {
  const { children } = props;
  const [value, dispatch] = useReducer(Reducer, props, State);
  const [actions] = useState(HomeActionTypes(dispatch));
  return (
    <HomeContext.Provider value={value}>
      <HomeDispatch.Provider value={actions}>
        {children}
      </HomeDispatch.Provider>
    </HomeContext.Provider>
  );
}

export function useHomeContext() {
  const state = useContext(HomeContext);
  const actions = useContext(HomeDispatch);
  return [state, actions];
}