import { View, Text, Image, Modal } from 'react-native'
import React from 'react'
import { EvilIcons } from '@expo/vector-icons';
import { COLORS, FONTS, SIZES } from '@/constants';
import { TouchableWithoutFeedback } from 'react-native';
import { DonationCenter } from '@/models/App.types';
import { SafeAreaView } from 'react-native-safe-area-context';
// import MapView from 'react-native-maps';

type Props = {
    item: DonationCenter,
    modalVisible: boolean,
    setModalVisible: (data: boolean) => void
}

const DonationCenterCardDetails = ({item, modalVisible, setModalVisible}: Props) => {
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
                                // justifyContent:'center'
                            }}
                        >
                            <Image
                                source={{uri: item.image}}
                                resizeMode='contain'
                                style={{
                                    height:150,
                                    width: 150,
                                    borderRadius: 50,
                                    backgroundColor: COLORS.black,
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
export default DonationCenterCardDetails;