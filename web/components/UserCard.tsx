import React, {useState}from 'react'
import { User } from '@/models/App.types';
import UserCardDetails from './UserCardDetails';
import { SafeAreaView } from 'react-native-safe-area-context';
import { View, Text, TouchableOpacity, Image } from 'react-native'
import { COLORS, FONTS } from '@/constants';
import { MaterialCommunityIcons,EvilIcons } from '@expo/vector-icons';

type Props = {
    item: User
}

const UserCard = ({item}: Props) => {
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
                    source={{uri: item.image}}
                    resizeMode='contain'
                    style={{
                        width:85,
                        height:85,
                        borderRadius:50,
                        marginRight:16,
                        marginLeft:4,
                        backgroundColor: COLORS.black,
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
                        {item.fullName}
                    </Text>
                    <View
                        style={{
                            flexDirection:'row',
                            justifyContent:'center'
                        }}
                    >
                        <MaterialCommunityIcons
                            name='blood-bag'
                            size={24}
                            color={COLORS.primary}
                        />
                        <Text
                            style={{
                                // marginLeft:8,
                                ...FONTS.body4
                            }}
                        >
                            {item.bloodTypeId}
                        </Text>
                        
                    </View>
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
                            {item.address}
                        </Text>

                    </View>
                </View>
            </TouchableOpacity>
            {modalVisible ? <UserCardDetails item={item} modalVisible={modalVisible} setModalVisible={setModalVisible}/> : null}
        </SafeAreaView>
    );
};

export default UserCard;