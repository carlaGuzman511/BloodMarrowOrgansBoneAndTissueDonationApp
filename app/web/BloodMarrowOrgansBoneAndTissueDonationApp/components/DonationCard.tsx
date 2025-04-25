import { View, Text, Image, TouchableOpacity, ImageSourcePropType } from 'react-native'
import React from 'react'
import { COLORS, SIZES, FONTS } from '@/constants'
import { DonationPost } from '@/models/App.types';

type Props = {
    item: DonationPost,
    onPress: () => void,
}

export default function DonationCard({item , onPress}: Props) {
  return (
    <View>
        {/* <View>
            <View
                style={{
                    flexDirection:'column'
                }}
            >
                <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.black,
                        fontWeight: 500,
                        marginVertical: 2
                    }}
                >
                    {item.donationTypeId}
                </Text>
            </View>
            <View
                style={{
                    flexDirection:'row-reverse'
                }}
            >
                <Text
                    style={{
                        fontSize:14,
                        color: COLORS.secondaryBlack,
                        marginVertical:2
                    }}
                >
                    {item.createdAt}
                </Text>
            </View>
        </View> */}
        <View
            style={{
                width: SIZES.width - 44,
                height: 148,
                borderRadius: SIZES.padding,
                backgroundColor: COLORS.white,
                flexDirection: 'row',
                justifyContent:'space-between',
                paddingHorizontal: SIZES.padding,
                paddingVertical: SIZES.padding,
                marginVertical: 4,
                borderColor: COLORS.secondaryWhite,
                borderWidth: 1,
                elevation: 2,
                shadowColor: COLORS.secondaryWhite,
                shadowRadius: 3
            }}
        >
            {/* <View
                style={{
                    flexDirection:'column'
                }}
            >
                <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.secondaryBlack,
                        marginVertical: 2
                    }}
                >
                    Name
                </Text>
                <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.secondaryBlack,
                        marginVertical: 2
                    }}
                >
                    Tipo de Sangre
                </Text>
                <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.secondaryBlack,
                        marginVertical: 2
                    }}
                >
                    Location
                </Text>
            </View> */}
            <View
                style={{
                    flexDirection:'column'
                }}
            >
                <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.black,
                        fontWeight: 500,
                        marginVertical: 2
                    }}
                >
                    {item.createdAt}
                </Text>
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
                                
                {/* <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.black,
                        fontWeight: 500,
                        marginVertical: 2
                    }}
                >
                    {item.donationCenterId}
                </Text>
                <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.black,
                        fontWeight: 500,
                        marginVertical: 2
                    }}
                >
                    {item.userId}
                </Text> */}
                <Text
                    style={{
                        fontSize: 14,
                        color: COLORS.black,
                        fontWeight: 500,
                        marginVertical: 2
                    }}
                >
                    {item.description}
                </Text>
                {/* <Image
                    source={{uri:item.image}}
                    resizeMode='contain'
                    style={{
                        width: 120,
                        height: 120,
                        marginBottom:12,
                    }}
                />
                <TouchableOpacity
                    onPress={onPress}
                >
                    <Text
                        style={{
                            ...FONTS.h4,
                            color: COLORS.primary
                        }}
                    >
                        Donar
                    </Text>
                </TouchableOpacity> */}
            </View>
            <View
                style={{
                    flexDirection: "column",
                    alignItems: 'center'
                }}
            >
                <Image
                    source={{uri: item.image}}
                    resizeMode='contain'
                    style={{
                        width: 100,
                        height: 100,
                        marginBottom:12,
                    }}
                />
                <TouchableOpacity
                    onPress={onPress}
                >
                    <Text
                        style={{
                            ...FONTS.h4,
                            color: COLORS.primary
                        }}
                    >
                        Donar
                    </Text>
                </TouchableOpacity>
            </View>
        </View>
    </View>
  )
}