import { View, Text, Image, Button } from 'react-native'
import React from 'react'
import { SafeAreaView } from 'react-native-safe-area-context';
import { EvilIcons } from '@expo/vector-icons';
import { COLORS, FONTS, icons, features, SIZES } from '@/constants';
import { FlatList } from 'react-native-gesture-handler';
import { Header } from 'react-native/Libraries/NewAppScreen';

type Props = {
    item: any,
    index: any
}
export default function Report() {
    const renderItem = ({ item, index }: Props) => {
        return(
            <View
                key={index}
                style={{
                    flexDirection:'column',
                    justifyContent:'center',
                    alignItems:'center',
                    marginBottom:10,
                    borderRadius:8,
                    height:74,
                    width:110,
                    borderColor:COLORS.secondaryWhite,
                    borderWidth:1
                }}
            >
                <Text
                    style={{
                        ...FONTS.body3,
                        fontWeight:'bold',
                    }}
                >
                    {item.volume}
                </Text>
                <Text
                    style={{
                        ...FONTS.body4
                    }}
                >
                    {item.substance}
                </Text>
        </View>
        );
    };

    const renderContent = () => {
        return(
            <>
                <View
                    style={{
                        alignItems:'center',
                        marginVertical:22
                    }}
                >
                    <View
                        style={{
                            flexDirection:'row'
                        }}
                    >
                        <EvilIcons
                            name='location'
                            size={24}
                            color={COLORS.primary}
                        />
                        <Text
                            style={{
                                ...FONTS.body4,
                                marginVertical:10
                            }}
                        >
                            Research Center
                        </Text>
                    </View>
                    <Text
                        style={{
                            ...FONTS.body4,
                            marginVertical:10
                        }}
                    >
                        Djaka Medical College, Dhaka
                    </Text>
                </View>
                <View
                    style={{
                        alignItems:'center'
                    }}
                >
                    <Image
                        style={{
                            marginRight:30,
                            width:250,
                            height:250
                        }}
                        source={icons.bloodTestIcon}
                        resizeMode='contain'
                    />
                </View>
                <FlatList
                    numColumns={3}
                    columnWrapperStyle={{
                        justifyContent:'space-between'
                    }}
                    data={features}
                    style={{
                        marginTop: SIZES.padding * 2
                    }}
                    keyExtractor={item => `${item.id}`}
                    renderItem={renderItem}
                />
                <Button
                    // style={{
                    //     marginTop:SIZES.padding
                    // }}
                    title='My Report'
                    // filled
                />
            </>
        );
    }

    const onPressHeader = () => {
        // navigation.navigate('Home');
    }

    return (
        <SafeAreaView
            style={{
                flex:1
            }}
        >
            <View
                style={{
                    marginHorizontal:22
                }}
            >
                <Header
                    name='Report'   
                    onPress={onPressHeader}
                />
                {renderContent()}
            </View>
        </SafeAreaView>
    )
}