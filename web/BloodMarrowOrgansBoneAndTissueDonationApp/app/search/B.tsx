import { View, Text } from "react-native";
import { GestureHandlerRootView } from 'react-native-gesture-handler';

export default function B() {
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
          B  
        </Text>
      </View>
    </GestureHandlerRootView>
  );
}
