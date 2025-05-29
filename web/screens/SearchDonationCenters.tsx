import { ListRenderItem, View } from 'react-native'
import React, { useState, useEffect } from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { FlatList } from 'react-native-gesture-handler';
import Header from '@/components/Header';
import SearcherBar from '@/components/SearcherBar';
import { DonationCenter, User } from '@/models/App.types';
import axios from "axios";
import DonationCenterCard from '@/components/DonationCenterCard';

const SearchDonationCenters = () => {
    const DONATION_CENTERS_API_URL = 'http://192.168.150.5:7140/api/donation-centers';
    const [search, setSearch] = useState('');
    const [donationCenters, setDonationCenters] = useState<DonationCenter[]>([]);
    const [filteredDonationCenters, setFilteredDonationCenters] = useState(donationCenters);

    const handleSearchDonationCentersByName = (data: string) => {
        setSearch(data);
        const filteredData = donationCenters.filter((donationCenter: DonationCenter) => {
            return donationCenter.name.toLowerCase().includes(data.toLowerCase());
        })
        setFilteredDonationCenters(filteredData);
    }

    const handleSearchDonationCentersByAddress = (data: string) => {
        setSearch(data);
        const filteredData = donationCenters.filter((donationCenter: DonationCenter) => {
            return donationCenter.address.toLowerCase().includes(data.toLowerCase());
        })
        setFilteredDonationCenters(filteredData);
    }

    useEffect(() => {
        fetchDonationCenters();
    }, []);

    const fetchDonationCenters = async () => {
        try {
            const response = await axios.get(DONATION_CENTERS_API_URL);
            setDonationCenters(response.data);
        }
        catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const renderDonationCentersList = () => {
        return(
            <FlatList
                data={filteredDonationCenters}
                renderItem={(item: any) => (<DonationCenterCard item={item.item}/>)}
                keyExtractor={(item: DonationCenter) => item.id?.toString()}
                contentContainerStyle={{
                    flexGrow: 1,
                }}
            />
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
                    marginHorizontal:22,
                    flex:1,
                }}
            >
                <Header
                    name='Search'
                    onPress={onPressHeader}
                />
                {<SearcherBar search={search} handleSearch={handleSearchDonationCentersByName}/>}
                {renderDonationCentersList()}
            </View>
        </SafeAreaView>
    )
}

export default SearchDonationCenters;