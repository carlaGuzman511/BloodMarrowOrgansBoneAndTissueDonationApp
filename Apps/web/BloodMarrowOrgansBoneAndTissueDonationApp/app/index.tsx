import { Text, View } from "react-native";

import Profile from '@/screens/Profile';
import DonationRequest from '@/screens/DonationRequest';
import Report from '@/screens/Report';
import Search from '@/screens/Search';
import Home from '@/screens/Home';
import DonorCardDetails from '@/components/DonorCardDetails';
import { NativeViewGestureHandler } from "react-native-gesture-handler";
import { GestureHandlerRootView } from 'react-native-gesture-handler';

export default function Index() {
  return (
    <GestureHandlerRootView>
      <View
        style={{
          flex: 1,
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Home/>
        {/* <DonationRequest/> */}
        {/* <Search/> */}

        {/* <Profile/> */}
        {/* <Report/> */}
      </View>
    </GestureHandlerRootView>
  );
}
