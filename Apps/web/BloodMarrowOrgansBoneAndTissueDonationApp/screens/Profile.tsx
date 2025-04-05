import { Image, View, Text, TouchableOpacity } from "react-native";
import { useEffect, useState } from "react";
import { images, SIZES, FONTS, COLORS } from "../constants";
import { AntDesign, Entypo, EvilIcons, Feather, Ionicons, MaterialCommunityIcons } from "@expo/vector-icons";
import * as Location from "expo-location";
import { SafeAreaView } from "react-native-safe-area-context";
import Header from "@/components/Header";

const Profile = () => {
    const [address, setAddress] = useState('Loading...');
    const [errorMsg, setErrorMsg] = useState('');
    useEffect(() => {
        const getPermissions = async () => {
            let { status } = await Location.requestBackgroundPermissionsAsync();
            if(status !== 'granted'){
                setErrorMsg('Permission to access location was denied');
                return;
            }
            let location = await Location.getCurrentPositionAsync();
            const text = JSON.stringify(location);
            const parsedData = JSON.parse(text);
            const longitude = parsedData.coords.Longitude;
            const latitude = parsedData.coords.Latitude;
            let address = await Location.reverseGeocodeAsync({
                longitude,
                latitude,
            });
            setAddress(`${address[0].name}, ${address[0].district}, ${address[0].city}`);
        }

        getPermissions();
    }, []);

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
                    source={images.boyImage}
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
                    <Text
                        style={{
                            ...FONTS.body4,
                            marginLeft:8,
                        }}
                    >
                        {address}
                    </Text>
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
            </View>
        </SafeAreaView>
    );
}


export default Profile;