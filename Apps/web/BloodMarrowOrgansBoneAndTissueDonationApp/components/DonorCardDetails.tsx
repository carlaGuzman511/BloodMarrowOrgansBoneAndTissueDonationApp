import { View, Text, TouchableOpacity, Image, Modal } from 'react-native'
import React from 'react'
import { Ionicons, EvilIcons, MaterialCommunityIcons, MaterialIcons, Entypo } from '@expo/vector-icons';
import { COLORS, FONTS, SIZES, images } from '@/constants';
import { TouchableWithoutFeedback, Keyboard } from 'react-native';
import { User } from '@/models/App.types';
import { SafeAreaView } from 'react-native-safe-area-context';
// import MapView from 'react-native-maps';

type Props = {
    item: User,
    modalVisible: boolean,
    setModalVisible: (data: boolean) => void
}

const DonorCardDetails = ({item, modalVisible, setModalVisible}: Props) => {
    console.log(item?.image);
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
                                alignItems:'center'
                            }}
                        >
                            <Image
                                source={images.manImage}
                                resizeMode='contain'
                                style={{
                                    height:120,
                                    width: 120,
                                    borderRadius: 10,
                                    position:'absolute',
                                    top:-80
                                }}
                            />
                            <View
                                style={{
                                    marginTop: 30
                                }}
                            >
                                <Text
                                    style={{
                                        ...FONTS.h3,
                                        marginTop:24,

                                    }}
                                >
                                    {item.name}
                                </Text>
                                <View
                                    style={{
                                        flexDirection:'row',
                                        marginVertical:SIZES.padding
                                    }}
                                >
                                    <EvilIcons
                                        name="location"
                                        size={24}
                                        color={COLORS.primary}
                                    />
                                </View>
                                <Text
                                    style={{
                                        ...FONTS.body4,
                                        marginLeft:8,

                                    }}
                                >
                                    {item.location}
                                </Text>
                            </View>
                            <View
                                style={{
                                    justifyContent:'space-between',
                                    flexDirection:'row',
                                    width: '100%',
                                    paddingHorizontal:22,
                                    marginVertical:22
                                }}
                            >
                                <View
                                    style={{
                                        alignItems:'center',
                                        flexDirection:'column'
                                    }}
                                >   
                                    <MaterialCommunityIcons
                                        size={48}
                                        name="hand-heart-outline"
                                        color={COLORS.primary}
                                    />
                                    <View
                                        style={{
                                            marginTop:12,
                                            flexDirection:'row'
                                        }}
                                    >  
                                        <Text
                                            style={{
                                            ...FONTS.body3,
                                            color:COLORS.primary,
                                            marginRight:6 
                                            }}
                                        >
                                            6
                                        </Text>
                                        <Text
                                            style={{
                                            ...FONTS.body3,
                                            color:COLORS.secondaryBlack 
                                            }}
                                        >
                                            Times Donated
                                        </Text>
                                    </View>
                                </View>
                                <View
                                    style={{
                                        alignItems:'center',
                                        flexDirection:'column'
                                    }}
                                >   
                                    <MaterialIcons
                                        size={48}
                                        name="approval"
                                        color={COLORS.primary}
                                    />
                                    <View
                                        style={{
                                            marginTop:12,
                                            flexDirection:'row'
                                        }}
                                    >  
                                        <Text
                                            style={{
                                            ...FONTS.body3,
                                            color:COLORS.primary,
                                            marginRight:6 
                                            }}
                                        >
                                            Blood Type
                                        </Text>
                                        <Text
                                            style={{
                                            ...FONTS.body3,
                                            color:COLORS.secondaryBlack 
                                            }}
                                        >
                                            {item.bloodType}
                                        </Text>
                                    </View>
                                </View>
                            </View>
                            {/* <View
                                style={{
                                    marginHorizontal:22,
                                    borderRadius:60
                                }}
                            >
                                <MapView
                                    style={{
                                        height: 200,
                                        width: SIZES.width - 44,
                                        marginVertical:22
                                    }}
                                    initialRegion={{
                                        latitude:17.78825,
                                        longitude:-122.4324,
                                        latitudeDelta:0.09222,
                                        longitudeDelta:0.0421
                                    }}
                                />
                            </View> */}
                        </View>
                    </View>
                </TouchableWithoutFeedback>
            </Modal>
        </SafeAreaView>  
    );
}
export default DonorCardDetails;