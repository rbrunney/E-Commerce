import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, SafeAreaView, ScrollView} from 'react-native';
import SearchBar from '../components/SearchBar';
import ItemCard from '../components/ItemCard'


export default function Home() {

    // This needs to be replaced with an actual API call from the catalog service
    let itemsTest = [
      {"Name": "IPhone", "Description": "Cool Tech", "Price": "3,000"}, 
      {"Name": "Chicken", "Description": "Yummmmy", "Price": "3.75"},
      {"Name": "MTNDEW", "Description": "Mustard Water", "Price": "0.50"},
      {"Name": "Tractor", "Description": "Cowboy go yeee", "Price": "10,000"},
      {"Name": "Rocket", "Description": "To the MOON!!!!!", "Price": "2,500,000"},
      {"Name": "Wii", "Description": "Nice Console, Have Fun Like EEEEEE", "Price": "6,500,000"}
    ]

    let itemList = []

    // Need a way to find how to pass in properties into elements
    // itemsTest.forEach((item) => {
    //   itemList.push(
    //     <View style={styles.scrollRow}>
    //       <ItemCard name={item["Name"]} descripiton={item["Description"]} price={item["Price"]} />
    //     </View>
    //   )
    // }) 

    return (
        <SafeAreaView style={styles.container}>
          <View style={styles.header}>
              <Text style={styles.headertext}>E-Commerce App</Text>
          </View>
          <View style={styles.search}>
              <SearchBar />
          </View>
          <View style={styles.body}>
            <ScrollView>
              {/* {itemList} */}
            </ScrollView>
          </View>
          <StatusBar style="auto" />
        </SafeAreaView>
    );
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'center',
    },
    header: {
      flex: 1,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'center'
    },
    search: {
      flex: 0.5,
      justifyContent: 'center',
      alignItems: 'center'
    },
    body: {
      flex: 9,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'center',
      marginTop: 20
    },
    headertext: {
      fontSize: 30
    },
    scrollRow: {
      margin: 10,
      flexDirection: 'row',
      width: 375
    },
    spacer: {
      flex: 0.5
    }
});