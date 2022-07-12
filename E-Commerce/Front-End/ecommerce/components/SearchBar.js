import { StyleSheet, View, TextInput, TouchableHighlight} from 'react-native';
import Icon from "react-native-vector-icons/Ionicons";

export default function SearchBar() {
    return (
        <View style={styles.container}>
            <View style={styles.outerDivs}></View>
            <View style={styles.searchEntry}>
                <TextInput placeholder="Search for Item" />
            </View>
            <TouchableHighlight onPress={()=>{console.log('What the nut')}}>
                <View style={styles.button}>
                    <Icon name="search"
                        color="#ccc"
                        size={25}/>
                </View>
            </TouchableHighlight>
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
        padding: 10
    }
});