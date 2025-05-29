import React, {useState}from 'react'
import { DonationCenter } from '@/models/App.types';
import DonationCenterCardDetails from './DonationCenterCardDetails';
import { SafeAreaView } from 'react-native-safe-area-context';
import { View, Text, TouchableOpacity, Image } from 'react-native'
import { COLORS, FONTS } from '@/constants';
import { EvilIcons } from '@expo/vector-icons';

type Props = {
    item: DonationCenter
}

const DonationCenterCard = ({ item }: Props) => {
    const [modalVisible, setModalVisible] = useState(false);

    return(
        <SafeAreaView>
            <TouchableOpacity
                onPress={() => setModalVisible(true)}
                key={item.id?.toString()}
                style={{
                    flexDirection:'row',
                    alignItems:'center',
                    borderRadius: 10,
                    borderWidth:1,
                    borderColor: COLORS.secondaryWhite,
                    height: 110,
                    backgroundColor: COLORS.white,
                }}
            >   
                <Image
                    source={{uri: item.image}}
                    resizeMode='contain'
                    style={{
                        width:75,
                        height:75,
                        borderRadius:50,
                        marginRight:16,
                        marginLeft:4,
                        backgroundColor: COLORS.black,
                    }}
                />
                <View
                    style={{
                        flexDirection:'column',
                        alignItems:'center',
                        maxWidth:300,
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.body4,
                            fontWeight:'bold',
                            marginLeft:4,
                            marginBottom:6,
                            textAlign: 'center',
                            maxWidth: 250
                        }}
                    >
                        {item.name}
                    </Text>
                    <View
                        style={{
                            flexDirection:'row',
                            justifyContent:'center',
                            maxWidth:200
                        }}
                    >
                        <EvilIcons
                            name='location'
                            size={24}
                            color={COLORS.primary}
                        />
                        <Text
                            style={{
                                // marginLeft:8,
                                ...FONTS.body4,
                                maxWidth:200,
                                textAlign:'center'
                            }}
                        >
                            {item.address}
                        </Text>
                    </View>
                    <View
                        style={{
                            flexDirection:'row',
                            justifyContent:'center'
                        }}
                    >
                        <Text
                            style={{
                                // marginLeft:8,
                                ...FONTS.body4
                            }}
                        >
                            {item.city}
                        </Text>
                    </View>
                </View>
            </TouchableOpacity>
            {modalVisible ? <DonationCenterCardDetails item={item} modalVisible={modalVisible} setModalVisible={setModalVisible}/> : null}
        </SafeAreaView>
    );
};

export default DonationCenterCard;