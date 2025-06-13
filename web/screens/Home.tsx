import {View, Image, Text, TouchableOpacity, ListRenderItem, FlatList } from 'react-native'
import React, { useEffect } from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { COLORS } from '@/constants'
import { Ionicons, MaterialCommunityIcons } from '@expo/vector-icons';
import { SIZES } from '@/constants';
import axios from "axios";
import { Donation } from '@/models/App.types';
import { useRouter } from 'expo-router';
import { LinearGradient } from 'expo-linear-gradient';
import { useInformationContext } from './../app/information/context';

const Home = () => {
    const API_URL = 'http://192.168.0.5:7140/api/donation-types';
    const router = useRouter();
    const [state, actions] = useInformationContext();

    useEffect(() => {
      fetchData();
    }, []);

    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        actions.onGetInformation({ information: response.data });
      } catch (error: any) {
        console.error('Error fetching information module:', error?.message);
      }
    };

    const renderItem: ListRenderItem<Donation> = ({ item }) => (
        <TouchableOpacity
            onPress={() => {
                router.push({
                    pathname: "/information/details",
                    params: item,
                  });           
            }}
            style={{
                height:350,
                width:350,
                borderColor:COLORS.black,
                borderWidth:2,
                backgroundColor:COLORS.black,
                borderRadius:10,
                alignItems:'center',
                justifyContent:'center',
                marginBottom:22,
                marginLeft:22
            }}
        >
            <Image
                source={{uri: item.image}}
                style={{
                    height:320,
                    width:320,
                    borderRadius:20,
                }}
            />
            <LinearGradient 
                colors={['transparent', 'rgba(0,0,0,0.8)']}
                style={{
                position:'absolute',
                width:320,
                height:320,
                padding:20,
                borderRadius:20,
                }}
            >
                <Text
                    style={{
                        color:"white",
                        fontSize:20,
                        fontWeight:'bold',
                        letterSpacing:1.5,
                        gap: 10,
                    }}
                >
                    {item.name}
                </Text> 
            </LinearGradient>
        </TouchableOpacity>
    );

    const renderHeader = () => {
        return(
            <View
                style={{
                    flexDirection:'row',
                    justifyContent:'space-between',
                    marginVertical:22,
                    backgroundColor:COLORS.black,
                }}
            >
                <TouchableOpacity
                    onPress={()=>{}}
                >
                    <MaterialCommunityIcons
                        name="view-dashboard"
                        size={28}
                        color={COLORS.primary}
                    />
                </TouchableOpacity>
                <View>
                    <View
                        style={{
                            height:6,
                            width:6,
                            backgroundColor:COLORS.primary,
                            borderRadius:3,
                            position:'absolute',
                            right:5,
                            top:5
                        }}
                    >
                    
                    </View>
                    <TouchableOpacity
                        onPress={()=>{}}
                    >
                        <Ionicons
                            name='notifications-outline'
                            size={28}
                            color={COLORS.black}
                        />
                    </TouchableOpacity>
                </View>
            </View>
        );
    }

    const renderFeatures = () => {
        return(
            <View
                style={{
                    marginVertical: SIZES.padding,
                    width:'100%',
                    flexDirection:'row',
                    justifyContent:'space-between',
                    flexWrap:'wrap'
                }}
            >
            </View>
        )
    }
    
    return(
        <SafeAreaView
            style={{
                flex:1,
                backgroundColor:COLORS.black
            }}
        >
            <FlatList
                data={state.information}
                keyExtractor={(item: Donation) => item.id.toString()}
                renderItem={renderItem}
                showsVerticalScrollIndicator={false}
                onEndReachedThreshold={0.2}
                onEndReached={() => {}}
                style={{
                    backgroundColor:COLORS.black
                }}
            />
        </SafeAreaView>
    )
}

export default Home