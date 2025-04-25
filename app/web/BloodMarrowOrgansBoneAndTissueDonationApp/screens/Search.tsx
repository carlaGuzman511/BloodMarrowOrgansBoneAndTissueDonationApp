import { View } from 'react-native'
import React, { useState, useEffect } from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { FlatList } from 'react-native-gesture-handler';
import Header from '@/components/Header';
import SearcherBar from '@/components/SearcherBar';
import UserCard from '@/components/UserCard';
import { DonationCenter, User } from '@/models/App.types';
import axios from "axios";
import DonationCenterCard from '@/components/DonationCenterCard';

const Search = () => {
    const USERS_API_URL = 'http://192.168.150.5:7140/users';
    const DONATION_CENTERS_API_URL = 'http://192.168.150.5:7140/donationCenters';
    const [search, setSearch] = useState('');
    const [users, setUsers] = useState<User[]>([]);
    const [donationCenters, setDonationCenters] = useState<DonationCenter[]>([]);
    const [filteredUsers, setFilteredUsers] = useState(users);
    const [filteredDonationCenters, setFilteredDonationCenters] = useState(donationCenters);

    const handleSearchUsersByName = (data: string) => {
        setSearch(data);
        const filteredData = users.filter((user: User) => {
            return user.fullName.toLowerCase().includes(data.toLowerCase());
        })
        setFilteredUsers(filteredData);
    }

    const handleSearchUsersByAddress = (data: string) => {
        setSearch(data);
        const filteredData = users.filter((user: User) => {
            return user.address.toLowerCase().includes(data.toLowerCase());
        })
        setFilteredUsers(filteredData);
    }

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
        fetchUsers();
        fetchDonationCenters();
    }, []);

    const fetchUsers = async () => {
        try {
            const response = await axios.get(USERS_API_URL);
            setUsers(response.data);
        }
        catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const fetchDonationCenters = async () => {
        try {
            const response = await axios.get(DONATION_CENTERS_API_URL);
            setDonationCenters(response.data);
        }
        catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    const renderUsersList = () => {
        return(
            <FlatList
                data={filteredUsers}
                renderItem={(item: any) => (<UserCard item={item.item}/>)}
                keyExtractor={(item: User) => item.id.toString()}
                contentContainerStyle={{
                    flexGrow: 1,
                }}
                onEndReached={() => {}}
                onEndReachedThreshold={0.2}
                showsVerticalScrollIndicator={false}
            />
        );
    }

    const renderDonationCentersList = () => {
        return(
            <FlatList
                data={filteredDonationCenters}
                renderItem={(item: any) => (<DonationCenterCard item={item.item}/>)}
                keyExtractor={(item: DonationCenter) => item.id.toString()}
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
                {/* {<SearcherBar search={search} handleSearch={handleSearchUsersByName}/>}
                {renderUsersList()} */}
                
                {<SearcherBar search={search} handleSearch={handleSearchDonationCentersByName}/>}
                {renderDonationCentersList()}
            </View>
        </SafeAreaView>
    )
}

export default Search;