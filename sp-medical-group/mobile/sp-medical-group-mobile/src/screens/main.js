import React, { Component } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Perfil from './perfil';
import Consultas from './consultas';

const bottomTab = createBottomTabNavigator();

export default class Main extends Component{
    render(){
        return(
            <View style={styles.main}>
                <bottomTab.Navigator>
                    <bottomTab.Screen name='Consultas' component={Consultas} />
                    <bottomTab.Screen name='Perfil' component={Perfil} />
                </bottomTab.Navigator>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: '#F1F1F1'
    },
    container: {
      flex: 1,
      backgroundColor: '#F9FFF9',
      alignItems: 'center',
      justifyContent: 'center',
    },
  });