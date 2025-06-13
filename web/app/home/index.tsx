import { View } from "react-native";
import DonationRequest from '@/screens/DonationRequest';
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import { HomeContextProvider } from "./context";

export default function Index() {
  return (
    <GestureHandlerRootView>
      <HomeContextProvider>
        <View
          style={{
            flex: 1,
            // justifyContent: "center",
            // alignItems: "center",
          }}
        >
          <DonationRequest/>
        </View>
      </HomeContextProvider>
    </GestureHandlerRootView>
  );
}
