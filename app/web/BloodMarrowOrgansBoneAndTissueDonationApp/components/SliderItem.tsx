import { View, Text, Image, Dimensions} from 'react-native'
import React from 'react'
import { COLORS } from '@/constants';
import {LinearGradient} from 'expo-linear-gradient';

type Data = {
  name: string,
  image: any,  
  description: string,
}

type Props = {
    item: Data
}

export default function SliderItem({item}: Props) {
  const {width, height} = Dimensions.get('screen');
  return (
    <View
      style={{
        height:height,
        width:width,
        backgroundColor:COLORS.black,
        borderRadius:20,
        alignItems:'center',
        justifyContent:'center',
        marginTop:-80,
        gap:20
      }}
    >
      <Image
        source={item.image}
        style={{
          width:width,
          height:550,
          borderRadius:20
        }}
      />
      <LinearGradient 
        colors={['transparent', 'rgba(0,0,0,0.8)']}
        style={{
          position:'absolute',
          width:width,
          height:550,
          padding:20,
          borderRadius:20,
        }}
      >
        <View
          style={{
            justifyContent:'space-between',
            width: width - 44,
            marginVertical: 100
          }}
        >
          <Text
            style={{
              color:"white",
              fontSize:18,
              fontWeight:'bold',
              letterSpacing:1.5,
              gap: 10,
            }}
          >{item.name}</Text> 
          <Text
            style={{
              color:"white",
              fontSize:16,
              fontWeight:'600',
              letterSpacing:1.2,
            }}
          >
            {item.description.replace(/\\n/g, '\n')}
          </Text> 
        </View>
      </LinearGradient>
    </View>
  )
}