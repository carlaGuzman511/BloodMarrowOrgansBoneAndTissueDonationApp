import { View, Text } from "react-native";
import { GestureHandlerRootView } from 'react-native-gesture-handler';

export default function A() {
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
          A  
        </Text>
      </View>
    </GestureHandlerRootView>
  );
}
