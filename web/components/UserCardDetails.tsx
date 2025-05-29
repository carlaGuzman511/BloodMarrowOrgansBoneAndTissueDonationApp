import { View, Text, Image, Modal } from 'react-native'
import React from 'react'
import { EvilIcons, MaterialCommunityIcons, MaterialIcons } from '@expo/vector-icons';
import { COLORS, FONTS, SIZES } from '@/constants';
import { TouchableWithoutFeedback } from 'react-native';
import { User } from '@/models/App.types';
import { SafeAreaView } from 'react-native-safe-area-context';

type Props = {
    item: User,
    modalVisible: boolean,
    setModalVisible: (data: boolean) => void
}

const UserCardDetails = ({item, modalVisible, setModalVisible}: Props) => {
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
                                source={{uri: item.image}}
                                resizeMode='contain'
                                style={{
                                    height:150,
                                    width: 150,
                                    borderRadius: 50,
                                    position:'absolute',
                                    top:-100,
                                    backgroundColor: COLORS.black,
                                }}
                            />
                            <View
                                style={{
                                    marginTop: 30,
                                    maxWidth: 320,
                                }}
                            >
                                <Text
                                    style={{
                                        ...FONTS.h3,
                                        marginTop:24,
                                        maxWidth: 320,
                                        textAlign:'center',

                                    }}
                                >
                                    {item.fullName}
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
                                    <Text
                                        style={{
                                            ...FONTS.body4,
                                            marginLeft:8,
                                            maxWidth: 320,
                                            textAlign:'center',
                                        }}
                                    >
                                        {item.address}
                                    </Text>
                                </View>
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
                                            {item.city}
                                        </Text>
                                    </View>
                                </View>
                            </View>
                        </View>
                    </View>
                </TouchableWithoutFeedback>
            </Modal>
        </SafeAreaView>  
    );
}
export default UserCardDetails;