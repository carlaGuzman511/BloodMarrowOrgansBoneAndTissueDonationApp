import { View, Text , StyleSheet} from 'react-native'
import React from 'react'
import { TextInput } from 'react-native-gesture-handler'
import { COLORS, SIZES } from '@/constants';
import { MaterialIcons } from '@expo/vector-icons';

type Props = {
    id: string,
    icon?: any | undefined,
    iconPack: any,
    placeholder: string,
    onChangeText?: (text: string) => void,
    value?: string,
    errorText?: string[],
    keyboardType?: string,
    autocapitalize?: string,
    secureTextEntry?: boolean,
}

export default function Input(props: Props) {
  return (
    <View
        style={{
            ...styles.container,
        }}
    >
        <View
            style={{
                ...styles.inputContainer,
            }}
        >
            {
                props.icon && 
                (<MaterialIcons
                    name={props.icon}
                    size={24}
                    style={styles.icon}
                />)
            }
            <TextInput
                style={styles.input}
                placeholder={props.placeholder}
                onChangeText={props.onChangeText}
                value={props.value}
                placeholderTextColor={COLORS.secondaryBlack}
            >
                {
                    props.errorText && 
                    (
                    <View
                        style={{
                            ...styles.errorContainer,
                        }}
                    >
                        <Text
                            style={{
                                ...styles.errorText,
                            }}
                        >
                            {props.errorText[0]}
                        </Text>
                    </View>)
                }
            </TextInput>
        </View>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    width: '100%',
  },
  inputContainer: {
    width: '100%',
    // backgoundColor: COLORS.gray,
    paddingVertical: SIZES.padding,
    paddingHorizontal: SIZES.padding,
    borderRadius: 12,
    borderColor: COLORS.secondaryGray,
    borderWidth: 1,
    flexDirection: 'row',
    marginVertical: 5,
  },
  input: {
    color: COLORS.secondaryGray,
    flex: 1,
    fontFamily: 'sans-serif-light',
    paddingTop: 0,
    fontSize: 16,
  },
  icon: {
    marginRight: 10,
    color: COLORS.secondaryGray,
  },
  errorContainer: {
    marginVertical: 2,
  },
  errorText:{
    color: "red",
    fontSize: 12,
  }
})