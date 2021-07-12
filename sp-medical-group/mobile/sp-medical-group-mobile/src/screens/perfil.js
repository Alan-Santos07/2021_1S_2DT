import React, { Component } from 'react';
import { FlatList, StyleSheet, Text, View } from 'react-native';

import api from '../services/api'

export default class Perfil extends Component{

  render(){
    return(
      <View style={styles.container}>
          <Text>Perfil</Text>
      </View>
    )
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    // backgroundColor: 'black',
    alignItems: 'center',
    justifyContent: 'center',
  }
});
