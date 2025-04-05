import {View, Image, Text, TouchableOpacity, FlatList } from 'react-native'
import React from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { categories, COLORS } from '@/constants'
import { Ionicons, MaterialCommunityIcons } from '@expo/vector-icons';
import { SIZES, FONTS } from '@/constants';

const Home = () => {
    
    const renderHeader = () => {
        return(
            <View
                style={{
                    flexDirection:'row',
                    justifyContent:'space-between',
                    marginVertical:22
                }}
            >
                <TouchableOpacity
                    onPress={()=>{}}
                >
                    <MaterialCommunityIcons
                        name="view-dashboard"
                        size={28}
                        color={COLORS.primary}
                    />
                </TouchableOpacity>
                <View>
                    <View
                        style={{
                            height:6,
                            width:6,
                            backgroundColor:COLORS.primary,
                            borderRadius:3,
                            position:'absolute',
                            right:5,
                            top:5
                        }}
                    >
                    
                    </View>
                    <TouchableOpacity
                        onPress={()=>{}}
                    >
                        <Ionicons
                            name='notifications-outline'
                            size={28}
                            color={COLORS.black}
                        />
                    </TouchableOpacity>
                </View>
            </View>
        );
    }

    const renderFeatures = () => {
        return(
            <View
                style={{
                    marginVertical: SIZES.padding,
                    width:'100%',
                    flexDirection:'row',
                    justifyContent:'space-between',
                    flexWrap:'wrap'
                }}
            >
                {categories.map((category, index) => (
                    <TouchableOpacity
                        key={index}
                        style={{
                            height:120,
                            width:120,
                            borderColor:COLORS.secondaryWhite,
                            borderWidth:2,
                            backgroundColor:COLORS.white,
                            borderRadius:10,
                            alignItems:'center',
                            justifyContent:'center',
                            marginBottom:22
                        }}
                    >
                        <Image
                            source={category.icon}
                            resizeMode='contain'
                            style={{
                                height:40,
                                width:40,
                                marginVertical:12
                            }}
                        />
                        <Text
                            style={{
                                ...FONTS.body3,
                                color:COLORS.secondaryBlack
                            }}
                        >
                            {category.title}
                        </Text>
                    </TouchableOpacity>
                ))}
            </View>
        )
    }
    
    return(
        <SafeAreaView
            style={{
                flex:1,
                backgroundColor:COLORS.white
            }}
        >
            <View
                style={{
                    marginHorizontal:22
                }}
            >
                {renderHeader()}
                {renderFeatures()}
            </View>
        </SafeAreaView>
    )
}

export default Home