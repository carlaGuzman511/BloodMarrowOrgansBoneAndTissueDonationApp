import { TouchableOpacity, Text, StyleSheet } from 'react-native'
import React from 'react'
import { SIZES, COLORS, FONTS } from '@/constants'

type Props = {
    onPress: () => void,
    style: any,
    title: string,
    color?: string,
    filled?: boolean,
}
export default function Button({onPress, style, title, color, filled}: Props) {
    const filledBgColor = color || COLORS.green;
    const outlinedBgColor = COLORS.secondaryWhite;
    const bgColor = filled ? filledBgColor : outlinedBgColor;
    const textColor = filled ? COLORS.white : COLORS.secondaryBlack;

    return (
        <TouchableOpacity
            style={{
                ...styles.btn,
                ...style,
                ...{backgroundColor: bgColor},
            }}
            onPress={onPress}
        >
            <Text
                style={{
                    ...FONTS.body2,
                    ...{color: textColor},
                }}
            >
                {title}
            </Text>
        </TouchableOpacity>
    )
}

const styles = StyleSheet.create({
    btn: {
        paddingHorizontal: SIZES.padding,
        paddingVertical: SIZES.padding2,
        alignItems: 'center',
        justifyContent: 'center',
        borderRadius: SIZES.padding,
        color: COLORS.white,
        borderColor: COLORS.green,
        borderWidth: 2,
    }
})