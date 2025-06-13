import { View } from 'react-native'
import React, { useState, useEffect } from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { FlatList } from 'react-native-gesture-handler';
import Header from '@/components/Header';
import SearcherBar from '@/components/SearcherBar';
import UserCard from '@/components/UserCard';
import { User } from '@/models/App.types';
import axios from "axios";

const SearchUsers = () => {
    const USERS_API_URL = 'http://192.168.0.5:7140/api/users';
    const [search, setSearch] = useState('');
    const [users, setUsers] = useState<User[]>([]);
    const [filteredUsers, setFilteredUsers] = useState(users);
    
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

    useEffect(() => {
        fetchUsers();
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

    const renderUsersList = () => {
        return(
            <FlatList
                data={filteredUsers}
                renderItem={(item: any) => (<UserCard item={item.item}/>)}
                keyExtractor={(item: User) => item.id?.toString()}
                contentContainerStyle={{
                    flexGrow: 1,
                }}
                onEndReached={() => {}}
                onEndReachedThreshold={0.2}
                showsVerticalScrollIndicator={false}
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
                {<SearcherBar search={search} handleSearch={handleSearchUsersByName}/>}
                {renderUsersList()}
            </View>
        </SafeAreaView>
    )
}

export default SearchUsers;