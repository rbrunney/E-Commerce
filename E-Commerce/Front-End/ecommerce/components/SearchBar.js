import { useState } from 'react';
import { StyleSheet, View, TextInput, TouchableOpacity} from 'react-native';
import Icon from "react-native-vector-icons/Ionicons";

export default function SearchBar() {

    const [searchText, setText] = useState('');

    const getItemsFromApiAsync = () => {
        var url = `http://localhost:9000/ecommerce/getallitems`;

        fetch(url)
            .then(resp => resp.json())
            .then(data =>{
                console.log(data);
            }).catch(e => console.log(e));
    };

    return (
        <View style={styles.container}>
            <View style={styles.outerDivs}></View>
            <View style={styles.searchEntry}>
                <TextInput placeholder="Search for Item" onChangeText={newSearchText => setText(newSearchText)}/>
            </View>
            <TouchableOpacity onPress={() => getItemsFromApiAsync()}>
                <View style={styles.button}>
                    <Icon 
                        name="search"
                        color="#000"
                        size={25}
                    />
                </View>
            </TouchableOpacity>
            <View style={styles.outerDivs}></View>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center'
    },
    searchEntry: {
        flex: 2,
        height: 50,
        width: 20,
        alignItems: 'center',
        justifyContent: 'center',
        borderColor: "#000",
        borderWidth: 2,
        borderRadius: 5
    },
    cart: {
        flex: 0.5,
        alignItems: 'center',
        justifyContent: 'center',
        borderColor: '#000',
        borderWidth: 5
    },
    outerDivs: {
        flex: 0.2
    },
    button: {
        alignItems: "center",
        backgroundColor: "#DDDDDD",
        borderRadius: 5,
        padding: 10,
        marginLeft: 10
    }
});