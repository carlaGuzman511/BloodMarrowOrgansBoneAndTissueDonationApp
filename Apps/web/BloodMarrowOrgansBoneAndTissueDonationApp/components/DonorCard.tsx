import React, {useState}from 'react'
import { User } from '@/models/App.types';
import DonorCardDetails from './DonorCardDetails';
import { SafeAreaView } from 'react-native-safe-area-context';
import { View, Text, TouchableOpacity, Image } from 'react-native'
import { COLORS, FONTS, icons } from '@/constants';
import { EvilIcons } from '@expo/vector-icons';

type Props = {
    item: User
}

const DonorCard = ({item}: Props) => {
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
                    height: 110
                }}
            >   
                <Image
                    source={item.image}
                    resizeMode='contain'
                    style={{
                        width:85,
                        height:85,
                        borderRadius:10,
                        marginRight:16,
                        marginLeft:4
                    }}
                />
                <View
                    style={{
                        flexDirection:'column',
                        alignItems:'flex-start',

                    }}
                >
                    <Text
                        style={{
                            ...FONTS.body4,
                            fontWeight:'bold',
                            marginLeft:4,
                            marginBottom:6
                        }}
                    >
                        {item.name}
                    </Text>
                    <View
                        style={{
                            flexDirection:'row',
                            justifyContent:'center'
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
                                ...FONTS.body4
                            }}
                        >
                            {item.location}
                        </Text>
                    </View>
                </View>
                <View
                    style={{
                        position:'absolute',
                        right:2
                    }}
                >
                    <Image
                        source={icons.bloodIcon}
                        resizeMode='contain'
                        style={{
                            width: 70,
                            height: 70
                        }}
                    />
                    <Text
                        style={{
                            ...FONTS.body3,
                            color: COLORS.black,
                            position:'absolute',
                            fontWeight:'bold',
                            top: 20,
                            left: -10
                        }}
                    >
                        {item.bloodType}
                    </Text>
                </View>
            </TouchableOpacity>
            {modalVisible ? <DonorCardDetails item={item} modalVisible={modalVisible} setModalVisible={setModalVisible}/> : null}
        </SafeAreaView>
    );
};

export default DonorCard;