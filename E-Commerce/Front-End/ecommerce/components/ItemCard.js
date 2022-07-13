import { StyleSheet, Text, TouchableOpacity, View} from 'react-native';

export default function ItemCard(props) { 
    return (
        <View style={styles.container}>
            <View style={styles.cardHeader}>
                <Text style={styles.cardTextTitle}>{props.name}</Text>
            </View>
            <View style={styles.cardDescription}>
                <Text>{props.descripiton}</Text>
            </View>
            <View style={styles.cardPrice}>
                <Text>${props.price}</Text>
            </View>
            <View style={styles.cardAddToCartBtn}>
                <TouchableOpacity style={styles.cardButton}>
                    <Text>Add to Cart</Text>
                </TouchableOpacity>
            </View>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        height: 150,
        backgroundColor: '#fff',
        alignItems: 'center',
        justifyContent: 'center',
        borderColor: "#000",
        borderWidth: 5,
        borderRadius: 5,
    },
    cardHeader: {
        flex: 0.5,
        alignItems: 'center',
        justifyContent: 'center'
    },
    cardTextTitle: {
        fontSize: 20
    },
    cardDescription: {
        flex: 1.5
    },
    cardPrice: {
        flex: 0.5,
        fontWeight: 30
    },
    cardButton: {
        width: 90,
        height: 30,
        borderRadius: 10,
        backgroundColor: '#90ee90',
        justifyContent: 'center',
        alignItems:'center'
    },
    cardAddToCartBtn: {
        flex: 1,
        alignContent: 'center',
        justifyContent: 'center'
    }
});