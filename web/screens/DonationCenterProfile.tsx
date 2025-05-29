import { Image, View, Text, TouchableOpacity } from "react-native";
import { useEffect, useState } from "react";
import { images, SIZES, FONTS, COLORS } from "../constants";
import { AntDesign, Entypo, EvilIcons, Feather, Ionicons, MaterialCommunityIcons } from "@expo/vector-icons";
import MapView, { Marker, Polyline }from 'react-native-maps';
import MapViewDirections from 'react-native-maps-directions';
import { SafeAreaView } from "react-native-safe-area-context";
import Header from "@/components/Header";
import { useRouter } from 'expo-router';
import axios from "axios";


const DonationCenterProfile = ({}) => {
    const [data, setData] = useState<any[]>([]);
        const API_URL = 'http://192.168.150.5:7140/api/donation-centers';
        const router = useRouter();
    
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
    
    const [origin, setOrigin] = useState<any>({
        latitude: -17.38524,
        longitude: -66.14841,
    });
    
    const [destination, setDestination] = useState<any>({
        latitude: -17.388818852963695,
        longitude: -66.2053439788403,
    });

    const onHeaderPress = () => {
        // navigation.navigate('Home');
    }

    const onPressEditable = () => {
        // navigation.navigate('EditProfile');
    }
    
    const renderProfile = () => {
        return(
            <View 
                style={{
                    alignItems:"center",
                    marginVertical: 22,
                }}
            >
                <Image
                    source={images.a}
                    resizeMode="contain"
                    style={{
                        height: 100,
                        width: 100,
                        borderRadius: SIZES.padding
                    }}
                />
                <Text style={{
                    ...FONTS.h2,
                    marginTop: 24, 
                }}>
                    Juan Perez
                </Text>
                <View
                    style={{
                        flexDirection:'row',
                        marginVertical:SIZES.padding,
                    }}
                >
                    <EvilIcons
                        name="location"
                        size={24}
                        color={COLORS.primary}
                    />
                    {/* <Text
                        style={{
                            ...FONTS.body4,
                            marginLeft:8,
                        }}
                    >
                        {address}
                    </Text> */}
                </View>
            </View>
        );
    }
    
    const renderButtons = () => {
        return(
            <View
                style={{
                    flexDirection:'row',
                    justifyContent:'space-between'
                }}
            >
                <TouchableOpacity
                    onPress={()=>{}}
                    style={{
                        backgroundColor:COLORS.secondary,
                        width:150,
                        height:50,
                        borderRadius:SIZES.padding,
                        flexDirection:'row',
                        alignItems:'center',
                        justifyContent:'center'
                    }}
                >
                    <Ionicons
                        name="person-add-outline"
                        size={24}
                        color={COLORS.white}
                    />
                    <Text
                        style={{
                            ...FONTS.body4,
                            color:COLORS.white,
                            marginLeft:12
                        }}
                    >
                        Call Now
                    </Text>
                </TouchableOpacity>
                <TouchableOpacity
                    onPress={()=>{}}
                    style={{
                        backgroundColor:COLORS.primary,
                        width:150,
                        height:50,
                        borderRadius:SIZES.padding,
                        flexDirection:'row',
                        alignItems:'center',
                        justifyContent:'center'
                    }}
                >
                    <Entypo
                        name="forward"
                        size={24}
                        color={COLORS.white}
                    />
                    <Text
                        style={{
                            ...FONTS.body4,
                            color:COLORS.white,
                            marginLeft:12
                        }}
                    >
                        Request
                    </Text>
                </TouchableOpacity>
            </View>
        );
    }

    const renderFeatures = () => {
        return(
            <View
                style={{
                    flexDirection:'row',
                    justifyContent:'space-between',
                    marginVertical:22
                }}
            >
                <View
                    style={{
                        flexDirection:'column',
                        alignItems:'center'
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.h1
                        }}
                    >
                        A+
                    </Text>
                    <Text
                        style={{
                            ...FONTS.body3
                        }}
                    >
                        Blood Type
                    </Text>
                </View>
                <View
                    style={{
                        flexDirection:'column',
                        alignItems:'center'
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.h1
                        }}
                    >
                        05
                    </Text>
                    <Text
                        style={{
                            ...FONTS.body3
                        }}
                    >
                        Donated
                    </Text>
                </View>
                <View
                    style={{
                        flexDirection:'column',
                        alignItems:'center'
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.h1
                        }}
                    >
                        02
                    </Text>
                    <Text
                        style={{
                            ...FONTS.body3
                        }}
                    >
                        Requested
                    </Text>
                </View>
            </View>
        );
    }

    const renderMap = () => {
        return(
            <View>
                <MapView
                    style={{
                        height: 50,
                        width: 100,
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

    const renderSettings = () => {
        return(
            <View
                style={{
                    flexDirection:"column"
                }}
            >
                <TouchableOpacity
                    style={{
                        flexDirection:"row",
                        alignItems:"center",
                        marginVertical:12
                    }}
                    onPress={()=>{}}
                >
                    <MaterialCommunityIcons
                        name="calendar-clock-outline"
                        size={24}
                        color={COLORS.primary}
                    />
                    <Text
                        style={{
                            ...FONTS.body3,
                            marginLeft:24
                        }}
                    >
                        Available For Donate
                    </Text>
                </TouchableOpacity>
                <TouchableOpacity
                    style={{
                        flexDirection:"row",
                        alignItems:"center",
                        marginVertical:12
                    }}
                    onPress={()=>{}}
                >
                    <Ionicons
                        name="share-outline"
                        size={24}
                        color={COLORS.primary}
                    />
                    <Text
                        style={{
                            ...FONTS.body3,
                            marginLeft:24
                        }}
                    >
                        Invite a Friend
                    </Text>
                </TouchableOpacity>
                <TouchableOpacity
                    style={{
                        flexDirection:"row",
                        alignItems:"center",
                        marginVertical:12
                    }}
                    onPress={()=>{}}
                >
                    <Feather
                        name="info"
                        size={24}
                        color={COLORS.primary}
                    />
                    <Text
                        style={{
                            ...FONTS.body3,
                            marginLeft:24
                        }}
                    >
                        Get Help
                    </Text>
                </TouchableOpacity>
                <TouchableOpacity
                    style={{
                        flexDirection:"row",
                        alignItems:"center",
                        marginVertical:12
                    }}
                    onPress={()=>{}}
                >
                    <AntDesign
                        name="logout"
                        size={24}
                        color={COLORS.primary}
                    />
                    <Text
                        style={{
                            ...FONTS.body3,
                            marginLeft:24
                        }}
                    >
                        Log Out
                    </Text>
                </TouchableOpacity>
            </View>
        );
    }

    return(
        <SafeAreaView 
            style={{flex: 1}}
        >
            <View>
                <Header
                    name='Profile'
                    onPress={onHeaderPress}
                    editable={true}
                    onPressEditable={onPressEditable}
                />
                {renderProfile()}
                {renderButtons()}
                {renderFeatures()}
                {renderSettings()}
                {renderMap()}
            </View>
        </SafeAreaView>
    );
}

export default DonationCenterProfile;