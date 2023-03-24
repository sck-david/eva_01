import React, { Component } from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import './App.css';

import WorkoutScreen from './Screens/WorkoutScreen';

const Stack = createNativeStackNavigator();

export default function App(){
    return (
        <>
            <StatusBar style="dark" />
            <NavigationContainer>
                <Stack.Navigator>
                    <Stack.Screen name="Workouts" component={WorkoutScreen} />
                </Stack.Navigator>
            </NavigationContainer>
        </>
    );
    }

    //async populateWeatherData() {
    //    const response = await fetch('weatherforecast');
    //    const data = await response.json();
    //    this.setState({ forecasts: data, loading: false });
    //}

const styles = StyleSheet.create({
    container: {},
});

