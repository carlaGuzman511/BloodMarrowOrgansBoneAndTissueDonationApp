import { View } from 'react-native'
import React, { useState } from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { donors } from '@/constants';
import { FlatList } from 'react-native-gesture-handler';
import Header from '@/components/Header';
import SearcherBar from '@/components/SearcherBar';
import DonorCard from '@/components/DonorCard';
import { User } from '@/models/App.types';

const Search = () =>{
    const [search, setSearch] = useState('');
    const [filteredDonors, setFilteredDonors] = useState(donors);
    
    //search by location add more filters.
    const handleSearch = (data: string) => {
        setSearch(data);
        const filteredData = donors.filter((donor: User) => {
            return donor.location.toLowerCase().includes(data.toLowerCase());
        })
        setFilteredDonors(filteredData);
    }
    
    const renderDonorList = () => {
        return(
            <View>
                <FlatList
                    data={filteredDonors}
                    renderItem={(item: any) => (<DonorCard item={item.item}/>)}
                    keyExtractor={(item: User) => item.id.toString()}
                    contentContainerStyle={{
                        flexGrow: 1,
                    }}
                />
            </View>
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
                    marginBottom:200
                }}
            >
                <Header
                    name='Search'   
                    onPress={onPressHeader}
                />
                {<SearcherBar search={search} handleSearch={handleSearch}/>}
                {renderDonorList()}
            </View>
        </SafeAreaView>
    )
}

export default Search;