import { View } from 'react-native'
import React from 'react'
import { FlatList } from 'react-native-gesture-handler'
import SliderItem from './SliderItem';
import { COLORS } from '@/constants';

type Data = {
  name: string,
  image: any,  
  description: string,
}

type Props = {
    data: Data[],
}

export default function Slider({data}: Props) {
  return (
    <View>
      <FlatList
        style={{
          backgroundColor: 'black',
        }}
        data={data}
        horizontal
        showsHorizontalScrollIndicator={false}
        pagingEnabled
        renderItem={({item}) => {
          return (
            <SliderItem
              item={item}
            />
          );
        }}
      />
    </View>
  )
}