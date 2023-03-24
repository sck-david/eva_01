import { View, Text, StyleSheet } from 'react-native';


function WorkoutScreen({ route }) {
    const catId = route.params.categoryId;

    return (
        <View style={styles.container}>
            <Text>Workout Overview Screen</Text>
        </View>
    );
}

export default WorkoutScreen;

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: 16,
    },
});