import {View, Image, Text, TouchableOpacity} from 'react-native'
import React from 'react'
import { SafeAreaView } from 'react-native-safe-area-context';
import { images, FONTS, COLORS } from '@/constants';
import { MaterialIcons, FontAwesome } from '@expo/vector-icons';
import Input from '@/components/Input';
import Button from '@/components/Button';

const Login = () => {
    return(
        <SafeAreaView
            style={{
                flex: 1,
                marginHorizontal: 22,
                alignItems: 'center',
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
                        marginVertical: 48,
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
                    }}
                >
                    <Input
                        icon="email"  
                        id="email"  
                        iconPack={MaterialIcons}
                        placeholder="Enter your email"
                        keyboardType="email-address"
                    />
                    <Input
                        icon="lock"  
                        id="password"
                        iconPack={FontAwesome}
                        placeholder="Enter your password"
                        autocapitalize="none"
                        secureTextEntry
                    />
                </View>
                <View
                    style={{
                        flex:1,
                    }}
                >
                    <Button
                        title="LOGIN"
                        filled
                        onPress={()=>{}}
                        style={{
                            width : '100%',
                        }}
                    />
                    <TouchableOpacity
                        onPress={()=>{}}
                    >
                        <Text
                            style={{
                                ...FONTS.body3,
                                color: COLORS.secondaryGray,
                                marginVertical: 23,
                            }}
                        >
                            Olvidaste tu Contraseña?
                        </Text>
                    </TouchableOpacity>
                    <View
                        style={{
                            flexDirection: 'row',
                            marginVertical: 20,
                        }}
                    >
                        <Text
                            style={{
                                ...FONTS.body3,
                                color: COLORS.secondaryGray,
                            }}
                        >
                            No tienes cuenta? {" "}
                        </Text>
                        <TouchableOpacity
                            onPress={()=>{}}

                        >
                            <Text
                                style={{
                                    ...FONTS.body3,
                                    color: COLORS.green,
                                }}
                            >
                                Registrarse
                            </Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </View>
        </SafeAreaView>
    )
}

export default Login;