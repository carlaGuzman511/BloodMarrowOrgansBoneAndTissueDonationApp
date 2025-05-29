import { View, Text, Image, Modal, FlatList, TouchableOpacity, ListRenderItem } from 'react-native'
import React from 'react'
import { EvilIcons } from '@expo/vector-icons';
import { COLORS, FONTS, SIZES } from '@/constants';
import { TouchableWithoutFeedback } from 'react-native';
import { DonationCenter } from '@/models/App.types';
import { SafeAreaView } from 'react-native-safe-area-context';
import { useState } from "react";
import { Donation } from '@/models/App.types';
import MapView, { Marker, Polyline }from 'react-native-maps';
import { LinearGradient } from 'expo-linear-gradient';

type Props = {
    item: DonationCenter,
    modalVisible: boolean,
    setModalVisible: (data: boolean) => void
}

const DonationCenterCardDetails = ({item, modalVisible, setModalVisible}: Props) => {
    
    const [origin, setOrigin] = useState<any>({
        latitude: item.latitude,
        longitude: item.longitude,
    });
        
    const [destination, setDestination] = useState<any>({
        latitude: -17.388818852963695,
        longitude: -66.2053439788403,
    });
    
    const renderItem: ListRenderItem<Donation> = ({ item }) => (
        <TouchableOpacity
            onPress={() => {}}
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
                    height:20,
                    width:20,
                    borderRadius:10,
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
    
    const renderDonationTypes = () => {
        return(
            <SafeAreaView
                style={{
                    flex:1,
                }}
            >
                <FlatList
                    data={item.donationTypes}
                    keyExtractor={(item: Donation) => item.id.toString()}
                    renderItem={renderItem}
                    showsVerticalScrollIndicator={false}
                    onEndReachedThreshold={0.2}
                    onEndReached={() => {}}
                />
            </SafeAreaView>
        )
    };

    const renderMap = () => {
        return(
            <View
                style={{
                    height: SIZES.height * 0.7,
                    width: SIZES.width,
                    borderTopLeftRadius: 30,
                    borderTopRightRadius: 30,
                    borderLeftWidth: 25,
                    borderRightWidth: 25,
                    alignItems:'center',
                    // justifyContent:'center'
                }}
            >
                <MapView
                    style={{
                        height: '50%',
                        width: '100%',
                    }}
                    initialRegion={{
                        latitude: origin.latitude,
                        longitude: origin.longitude,
                        latitudeDelta: 0.09,
                        longitudeDelta: 0.04,
                    }}
                >
                    <Marker
                        draggable
                        title = "Hospital Location"
                        coordinate={{
                            latitude: origin.latitude,
                            longitude: origin.longitude,
                        }}
                        onDragEnd={(destination: any) => setOrigin(destination.nativeEvent.coordinate)}
                    />
                    <Marker
                        draggable
                        title="Your Current Location"
                        coordinate={{
                            latitude: destination.latitude,
                            longitude: destination.longitude,
                        }}
                        onDragEnd={(destination: any) => setDestination(destination.nativeEvent.coordinate)}
                    />
                    <Polyline
                        coordinates={[origin, destination]}
                        strokeColor="red"
                        strokeWidth={8}
                    />
                </MapView>
            </View>
        );
    }

    return(
        <SafeAreaView>
            <Modal
                animationType='slide'
                transparent={true}
                visible={modalVisible}
            >
                <TouchableWithoutFeedback onPress={() => setModalVisible(false)}>
                    <View
                        style={{
                            flex:1,
                            alignItems:'center',
                            bottom:0
                        }}
                    >
                        <View
                            style={{
                                height: SIZES.height * 0.7,
                                width: SIZES.width,
                                backgroundColor: '#F5F5FF',
                                borderTopLeftRadius: 30,
                                borderTopRightRadius: 30,
                                position: 'absolute',
                                bottom:0,
                                alignItems:'center',
                            }}
                        >
                            <Image
                                source={{uri: item.image}}
                                resizeMode='contain'
                                style={{
                                    height:150,
                                    width: 150,
                                    borderRadius: 50,
                                    position:'absolute',
                                    top:-100
                                }}
                            />
                            <View
                                style={{
                                    marginTop: 50,
                                    alignItems:'center',
                                    flexDirection:'column',
                                }}
                            >
                                <Text
                                    style={{
                                        ...FONTS.h3,
                                        marginTop:24,
                                        fontWeight:'bold',
                                        textAlign: 'center',
                                        maxWidth: 350
                                    }}
                                >
                                    {item.name}
                                </Text>
                                <View
                                    style={{
                                        flexDirection:'row',
                                        alignItems:'center',
                                    }}
                                >
                                    <EvilIcons
                                        name="location"
                                        size={24}
                                        color={COLORS.primary}
                                    />
                                    <Text
                                        style={{
                                            ...FONTS.body4,
                                            marginLeft:8,
                                            textAlign: 'center',
                                            maxWidth: 320
                                        }}
                                    >
                                        {item.address}
                                    </Text>
                                </View>
                                <View
                                    style={{
                                        flexDirection:'row',
                                        alignItems:'center',
                                    }}
                                >
                                    <Text
                                        style={{
                                            ...FONTS.body4,
                                            marginLeft:8,
                                            textAlign: 'center',
                                            maxWidth: 320
                                        }}
                                    >
                                        {item.city}
                                    </Text>
                                </View>
                            </View>
                            {/* {item.donationTypes?.map((donationType: Donation) => (
                                <View>
                                    <Image
                                        source={{uri: donationType.image}}
                                        style={{
                                            height:20,
                                            width:20,
                                            borderRadius:10,
                                        }}
                                    />
                                    <Text
                                        style={{
                                            color:"white",
                                            fontSize:20,
                                            fontWeight:'bold',
                                            letterSpacing:1.5,
                                            gap: 10,
                                        }}
                                    >
                                        {donationType.name}
                                    </Text> 
                                </View>
                            ))} */}
                            {renderDonationTypes()}
                            {/* {renderMap()} */}
                        </View>
                    </View>
                </TouchableWithoutFeedback>
            </Modal>
        </SafeAreaView>  
    );
}
export default DonationCenterCardDetails;