import { View } from 'react-native'
import React from 'react'
import { donationRequests } from '@/constants';
import { ScrollView } from 'react-native-gesture-handler';
import DonationCard from '@/components/DonationCard';
import Header from '@/components/Header';
import { DonationRequest } from '@/models/App.types';

export default function DonationRequest() {
    const onPressHeader = () => {
        // navigation.navigate('Home');
    }
    const onPressEditable = () => {}

    const renderContent = () => {
        return(
            <ScrollView>
                {
                    donationRequests.map((donationRequest: DonationRequest, index: number) => (
                        <DonationCard
                            key={index}
                            item={donationRequest}
                            onPress={()=>{}}
                        />
                    ))
                }
            </ScrollView>
        );
    }
    return (
        <View 
            style={{
                flex:1
            }}>
            {/* <PageContainer>
            </PageContainer> */}
            <View
                style={{
                    marginHorizontal: 22
                }}
            >
                <Header
                    name='Donation Request'
                    onPress={onPressHeader}
                />
                {renderContent()}
            </View>
        </View>
    );
}