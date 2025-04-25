import { View, Text } from "react-native";
import { GestureHandlerRootView } from 'react-native-gesture-handler';

export default function Profile() {
  return (
    <GestureHandlerRootView>
      <View
        style={{
          flex: 1,
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Text>
          Profile
        </Text>
        {/* <Profile/> */}
      </View>
    </GestureHandlerRootView>
  );
}
