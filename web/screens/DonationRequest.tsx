import React, { useEffect } from "react";
import axios from "axios";
import {
  View,
  FlatList,
  ListRenderItem,
} from "react-native";
import DonationCard from "@/components/DonationCard";
import { DonationPost } from "@/models/App.types";
import { useHomeContext } from "@/app/home/context";

const DonationRequest = () => {
    const API_URL = 'http://192.168.0.5:7140/api/donation-posts';
    const [state, actions] = useHomeContext();

    useEffect(() => {
      fetchData();
    }, []);

    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        actions.onGetDonationPosts({ donationPosts: response.data });
      } catch (error) {
        console.error('Error fetching donation posts:', error);
      }
    };

    const renderItem: ListRenderItem<DonationPost> = ({ item }) => (
        <DonationCard 
            item={item} 
            onPress={() => {}} 
        />
      );

    return (
        <View style={{ flex: 1, paddingHorizontal: 22 }}>
            <FlatList
              data={state.donationPosts}
              // keyExtractor={(item: DonationPost) => item.id?.toString()}
              renderItem={renderItem}
              showsVerticalScrollIndicator={false}
              onEndReachedThreshold={0.2}
              onEndReached={() => {}}
            />
        </View>
    );
}

export default DonationRequest;