import { View } from "react-native";
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import SearchDonationCenters from "@/screens/SearchDonationCenters";
import { SearchContextProvider } from "./context/index";
import SearchUsers from "@/screens/SearchUsers";

export default function SearchScreen() {
  return (
    <GestureHandlerRootView>
      <SearchContextProvider>
        <View
          style={{
            flex: 1,
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <SearchDonationCenters/>
        </View>
      </SearchContextProvider>
    </GestureHandlerRootView>
  );
}
