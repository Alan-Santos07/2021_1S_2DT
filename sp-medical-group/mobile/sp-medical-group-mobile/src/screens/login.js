import { StatusBar } from 'expo-status-bar';
import React, { Component } from 'react';
import { TextInput, TouchableOpacity, StyleSheet, Text, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api'

export default class Login extends Component{
    constructor(props){
        super(props)
        this.state = {
            email : '',
            senha : ''
        }
    }

    realizarLogin = async () => {
        const resposta = await api.post('/Login', {
            email : this.state.email,
            senha : this.state.senha,
        })
        
        const token = resposta.data.token 
        
        await AsyncStorage.setItem('userToken', token)

        console.log(token)

        this.props.navigation.navigate('Main')
    }

    render(){
        return(
        <View style={styles.container}>
            <TextInput
                style={styles.inputLogin}
                placeholder="E-mail"
                keyboardType="email-address"
                onChangeText={email => this.setState({ email })}
            />
            <TextInput
                style={styles.inputLogin}
                placeholder="Senha"
                secureTextEntry={true}
                onChangeText={senha => this.setState({ senha })}
            />
            <TouchableOpacity
                style={styles.btnLogin}
                onPress={this.realizarLogin}
            >
                <Text style={styles.loginText}>Login</Text>  
            </TouchableOpacity>
        </View>
        )
    }
}

const styles = StyleSheet.create({
  container: {
    width: "100%",
    height: "100%",
    backgroundColor: '#F9FFF9',
    alignItems: 'center',
    justifyContent: 'center',
  },

  btnLogin: {
    alignItems: "center",
    justifyContent: "center",
    height: 90,
    width: 296,
    backgroundColor: '#113C59',
  },

  inputLogin: {
    padding: 20,
    color: '#113C59',
    marginBottom: 20,
    backgroundColor: '#CFF4D2',
    fontSize: 16,
  },
  
  loginText: {
    color: '#F9FFF9',
    fontSize: 34,
    textTransform: 'uppercase',
  }
});
