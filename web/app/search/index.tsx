import { Link } from "expo-router";
import { View, Text, Button } from "react-native";
import { GestureHandlerRootView } from 'react-native-gesture-handler';
import SearchDonationCenters from "@/screens/SearchDonationCenters";
import SearchUsers from "@/screens/SearchUsers";

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
        <SearchDonationCenters/>
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
