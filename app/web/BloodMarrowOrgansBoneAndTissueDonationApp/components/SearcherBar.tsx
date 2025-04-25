
import { View, TouchableOpacity } from 'react-native'
import React from 'react'
import { Ionicons, MaterialCommunityIcons } from '@expo/vector-icons';
import { COLORS, SIZES } from '@/constants';
import { TextInput } from 'react-native-gesture-handler';

type Props = {
    search: string,
    handleSearch: (data: string) => void
}

const SearcherBar = ({search, handleSearch}: Props) => {
    return(
        <View
            style={{
                flexDirection: 'row',
                alignItems:'center',
                backgroundColor:COLORS.secondaryWhite,
                height:48,
                marginVertical:22,
                paddingHorizontal:22,
                borderRadius:4
            }}
        >
            <Ionicons
                name="search-outline"
                size={24}
                color={COLORS.black}
            />
            <TextInput
                style={{
                    height:'100%',
                    marginHorizontal:12,
                    width:SIZES.width - 144
                }}
                placeholder='Search'
                value={search}
                onChangeText={handleSearch}
            />
            <TouchableOpacity
                style={{
                    height:48,
                    width:48,
                    borderRadius:8,
                    alignItems:'center',
                    justifyContent:'center',
                    backgroundColor:COLORS.primary
                }}
                onPress={()=>{}}
            >
                <MaterialCommunityIcons
                    name="swap-vertical"
                    size={24}
                    color={COLORS.white}
                />
            </TouchableOpacity>
        </View>
    );
}

export default SearcherBar;