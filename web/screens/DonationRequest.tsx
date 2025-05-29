import React, { useEffect, useState } from "react";
import axios from "axios";
import {
  View,
  FlatList,
  ListRenderItem,
} from "react-native";
import DonationCard from "@/components/DonationCard";
import { DonationPost } from "@/models/App.types";

const DonationRequest = () => {
    const [data, setData] = useState<DonationPost[]>([]);
    const API_URL = 'http://192.168.150.5:7140/donationPosts';
      
    useEffect(() => {
      fetchData();
    }, []);

    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setData(response.data);
      } catch (error) {
        console.error('Error fetching data:', error);
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
              data={data}
              keyExtractor={(item: DonationPost) => item.id.toString()}
              renderItem={renderItem}
              showsVerticalScrollIndicator={false}
              onEndReachedThreshold={0.2}
              onEndReached={() => {}}
            />
        </View>
    );
}

export default DonationRequest;