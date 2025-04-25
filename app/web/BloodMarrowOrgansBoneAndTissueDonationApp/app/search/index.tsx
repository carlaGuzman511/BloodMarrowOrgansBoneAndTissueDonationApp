import { Link } from "expo-router";
import { View, Text, Button } from "react-native";
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import Search from "@/screens/Search";

export default function SearchScreen() {
  return (
    <GestureHandlerRootView>
      <View
        style={{
          flex: 1,
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Search/>
        {/*
        <Link 
          href="/search/A"
          push asChild
        >
          <Button
            title="Push to A"
          />
        </Link>
        <Link 
          href="/search/B"
          push asChild
        >
          <Button
            title="Push to B"
          />
        </Link>
        <Link 
          href="/search/C"
          push asChild
        >
          <Button
            title="Push to C"
          />
        </Link> */}
      </View>
    </GestureHandlerRootView>
  );
}
