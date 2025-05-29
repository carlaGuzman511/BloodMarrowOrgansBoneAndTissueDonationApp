import { View } from "react-native";
import DonationRequest from '@/screens/DonationRequest';
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
        <DonationRequest/>
      </View>
    </GestureHandlerRootView>
  );
}
