import { Link } from "expo-router";
import { View, Text, Button } from "react-native";
import { GestureHandlerRootView } from 'react-native-gesture-handler';

export default function Reports() {
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
          Reports
        </Text>
        <Link 
          href="/reports/A"
          push asChild
        >
          <Button
            title="Push to A"
          />
        </Link>
        <Link 
          href="/reports/B"
          push asChild
        >
          <Button
            title="Push to B"
          />
        </Link>
        <Link 
          href="/reports/C"
          push asChild
        >
          <Button
            title="Push to C"
          />
        </Link>
                
        {/* <Report/> */}
      </View>
    </GestureHandlerRootView>
  );
}
