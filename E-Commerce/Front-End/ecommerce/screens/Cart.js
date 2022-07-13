import { StyleSheet, Text, SafeAreaView, View} from 'react-native';

export default function Cart() {
    return (
        <SafeAreaView style={styles.container}>
            <View style={styles.header}>
                <Text style={styles.headertext}>Cart</Text>
            </View>
            <View style={styles.body}>
                <Text>Hello form Cart Screen</Text>
            </View>
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
    body: {
      flex: 8,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'center',
      marginTop: 20
    },
    headertext: {
      fontSize: 30
    }
});