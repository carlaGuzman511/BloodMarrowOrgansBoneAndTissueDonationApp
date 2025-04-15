import React from 'react'
import {View, Image, Text, TouchableOpacity} from 'react-native'
import { SafeAreaView } from 'react-native-safe-area-context';
import { images, FONTS, COLORS } from '@/constants';
import { MaterialIcons, FontAwesome } from '@expo/vector-icons';
import Input from '@/components/Input';
import Button from '@/components/Button';
import { DateTimePickerAndroid } from '@react-native-community/datetimepicker';

const Register = () => {
        
    // DateTimePickerAndroid.open(params: AndroidNativeProps)
    // DateTimePickerAndroid.dismiss(mode: AndroidNativeProps['mode'])
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
                        width: 180,
                        height: 180,
                        marginVertical: 48,
                    }}
                />
            </View>
            <View
                style={{
                    marginVertical: 20,
                }}
            >
                <Input
                    icon="person"  
                    id="person"  
                    iconPack={MaterialIcons}
                    placeholder="Ingresa tu nombre completo"
                    keyboardType='default'
                />
                <Input
                    icon="phone"  
                    id="phone"  
                    iconPack={MaterialIcons}
                    placeholder="Ingresa tu numero de telefono"
                    keyboardType='numeric'
                />
                <Input
                    icon="today"  
                    id="today"  
                    iconPack={MaterialIcons}
                    placeholder="Ingresa tu fecha de nacimiento"
                />
                <Input
                    icon="person"  
                    id="person"  
                    iconPack={MaterialIcons}
                    placeholder="Ingresa tu nombre completo"
                />
                <Input
                    icon="email"  
                    id="email"  
                    iconPack={MaterialIcons}
                    placeholder="Ingresa tu correo electronico"
                    keyboardType="email-address"
                />
                <Input
                    icon="lock"  
                    id="password"
                    iconPack={FontAwesome}
                    placeholder="Ingresa tu password"
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
                    title="REGISTRARSE"
                    filled
                    onPress={()=>{}}
                    style={{
                        width : '100%',
                    }}
                />
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
                        Ya tienes una cuenta? {" "}
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
                            Iniciar Sesion
                        </Text>
                    </TouchableOpacity>
                </View>
        </View>
    </SafeAreaView>
    )
}

export default Register