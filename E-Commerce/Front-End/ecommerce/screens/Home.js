import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, SafeAreaView, ScrollView} from 'react-native';
import SearchBar from '../components/SearchBar';
import ItemCard from '../components/ItemCard'
import { useEffect, useState } from 'react';


export default function Home() {

  const [itemData, setData] = useState([])

  const getItems = async () => {
    try {
     const response = await fetch('http://locahost:80/ecommerce/getallitems');
     const json = await response.json();
     setData(json);
     console.log(json)
   } catch (error) {
     console.error(error);
   }
 }

  // This needs to be replaced with an actual API call from the catalog service
  useEffect(() => {
    getItems();
  }, []);
  
  
  let itemList = [];
  // Need a way to find how to pass in properties into elements
  itemData.forEach((item) => {
    itemList.push(
      <View style={styles.scrollRow}>
        <ItemCard name={item["name"]} descripiton={item["description"]} price={item["unitPrice"]} />
      </View>
    )
  }) 

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
            {itemList}
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