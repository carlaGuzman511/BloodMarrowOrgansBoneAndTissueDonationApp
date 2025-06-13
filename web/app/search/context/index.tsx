import React, { useContext, useReducer, useState } from "react";
import { SearchContextType } from "./../../types/context";
import SearchActionFactory from "./action";
import { State, Reducer } from "./state";

const SearchContext = React.createContext<SearchContextType | null>(null);
const SearchDispatch = React.createContext<any>(null);

interface IProps {
  children: React.ReactNode;
}

export function SearchContextProvider(props: IProps) {
  const { children } = props;
  const [value, dispatch] = useReducer(Reducer, props, State);
  const [actions] = useState(SearchActionFactory(dispatch));
  return (
    <SearchContext.Provider value={value}>
      <SearchDispatch.Provider value={actions}>
        {children}
      </SearchDispatch.Provider>
    </SearchContext.Provider>
  );
}

export function useSearchContext() {
  const state = useContext(SearchContext);
  const actions = useContext(SearchDispatch);
  return [state, actions];
}