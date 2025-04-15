import {View, Text, Image} from 'react-native'
import React from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { COLORS, images, FONTS, SIZES } from '@/constants';
import Button from '@/components/Button';

const GetStarted = () => {
    return(
        <SafeAreaView
            style={{
                flex: 1,
                backgroundColor: COLORS.black,
            }}
        >
            <View
                style={{
                    flex: 1,
                    marginHorizontal: 22,
                    alignItems: 'center',
                }}
            >
                <Image
                    source={images.give4life3}
                    style={{
                        width: 250,
                        height: 250,
                        marginVertical: 22,
                    }}
                />
                <View
                    style={{
                        flexDirection: 'row',
                        alignItems: 'center',
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.h1,
                            color: COLORS.white,
                            marginRight: 22,
                            fontWeight: 'bold',
                            textAlign: 'center',
                            fontFamily: 'sans-serif'
                        }}
                    >
                        Give4Life
                    </Text>
                </View>
                <View
                    style={{
                        marginVertical: 20,
                        alignItems: 'center',
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.h4,
                            color: COLORS.white,
                            textAlign: 'center',
                            fontFamily: 'sans-serif-light',
                        }}
                    >
                        Puedes donar a quienes lo necesitan y solicitar sangre, medula osea y organos si es necesario.
                    </Text>
                </View>
                <Button 
                        title='LOGIN'
                        onPress={()=>{}}
                        style={{
                            marginVertical: 10,
                            width : '100%',
                            marginBotton : SIZES.padding
                        }}
                    />
                    <Button 
                        title='REGISTER'
                        onPress={()=>{}}
                        filled
                        style={{
                            width : '100%',
                            marginBotton : SIZES.padding
                        }}
                    />
            </View>
        </SafeAreaView>
    )
}

export default GetStarted