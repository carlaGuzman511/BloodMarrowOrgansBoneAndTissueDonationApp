import { View, Text, TouchableOpacity } from 'react-native'
import React from 'react'
import { COLORS, FONTS } from '@/constants';
import { MaterialIcons, Feather } from '@expo/vector-icons';

type Props = {
    name: string,
    onPress: () => void,
    editable?: boolean,
    onPressEditable?: () => void
}   

const Header = ({ name, onPress, editable, onPressEditable }: Props) => {
    return(
        <View
            style={{
                flexDirection:'row',
                justifyContent:'space-between',
                alignItems:'center'
            }}
        >
            <TouchableOpacity
                onPress={onPress}
                style={{
                    height: 44,
                    width: 44,
                    borderRadius: 4,
                    backgroundColor: COLORS.secondaryWhite,
                    alignItems:'center'
                }}
            >
                <MaterialIcons
                    name="keyboard-arrow-left"
                    size={24}
                    color={COLORS.black}
                />
            </TouchableOpacity>
            <Text
                style={{
                    ...FONTS.h4
                }}
            >
                {name}
            </Text>
            {editable ? (
                <TouchableOpacity
                    onPress={onPressEditable}    
                >
                    <Feather
                        name="edit"
                        size={24}
                        color={COLORS.black}
                    />
                </TouchableOpacity>
            ) : <></>}
        </View>
    );
};

export default Header;