import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, TouchableOpacity, View, ScrollView } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwt_decode from "jwt-decode";

import api from '../services/api';

export default class Consultas extends Component{
  constructor(props){
    super(props);
    this.state = {
      listaConsultas : [],
      nome: ''
    }
  }

  buscarDados = async () => {

    try {

      const valorToken = await AsyncStorage.getItem('userToken')

      if (valorToken !== null){

        this.setState({ nome : jwt_decode(valorToken).name })

      }

    } catch (error) {

      console.log(error)

    }
  }

  buscarConsultas = async () => {
    const resposta = await api.get('/consulta');
    const dadosDaApi = resposta.data;
    this.setState({ listaConsultas : dadosDaApi });
  };

  buscarMinhas = async () => {

  const valorToken = await AsyncStorage.getItem('userToken');

  const resposta = await api.get('/Consulta/minhas', {
    headers : {
      'Authorization' : 'Bearer ' + valorToken
    }
  })

  const dadosApi = resposta.data

  this.setState({ listaConsultas: dadosApi })
  }

  realizarLogout = async () => {
    try {
      await AsyncStorage.removeItem('userToken')
      this.props.navigation.navigate('Login')
    } catch (error) {
      console.log(error)
    }
  }

  autenticacaoConsultas = async () => {

    const valorToken = await AsyncStorage.getItem('userToken')

    if (jwt_decode(valorToken).role === "1") {

      this.buscarConsultas()

    } else {

      this.buscarMinhas()

    }
  }

  componentDidMount(){
    this.autenticacaoConsultas()
    this.buscarDados()
  }

  renderizaItem = ({item}) => (

    <View style={styles.flatItemLinha} >
      <View>
        <Text> {item.idMedicoNavigation.idUsuarioNavigation.nome} </Text>
        <Text> {item.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade} </Text>
        <Text> {item.idPacienteNavigation.idUsuarioNavigation.nome} </Text>
        <Text> {item.idSituacaoNavigation.situacao1} </Text>
        <Text> {item.dataConsulta} </Text>
        <Text> {item.horaConsulta} </Text>
        <Text> {item.descricao} </Text>
      </View>
    </View>

  )

  render(){
    return(
      <ScrollView>
        <View style={styles.container}>
          <Text>{'Consultas'.toUpperCase()}</Text>
          <Text>Bem Vindo {this.state.nome}</Text>
          <TouchableOpacity
              style={styles.btnLogout}
              onPress={this.realizarLogout}
            >
                <Text style={styles.btnLogoutText}>sair</Text>
            </TouchableOpacity>
          <View>
            <FlatList 
              contentContainerStyle={styles.conteudoBody} 
              data={this.state.listaConsultas} 
              keyExtractor={(item) => item.idConsulta.toString()}
              renderItem={this.renderizaItem}
            />
          </View>
        </View>
      </ScrollView>
    )
  }
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#F9FFF9',
    alignItems: 'center',
    justifyContent: 'center',
  },

  conteudoBody: {
    paddingRight: 30,
    paddingLeft: 30,
    paddingTop: 15,
    // backgroundColor: 'red'
  },

  flatItemLinha: {
    flexDirection: 'row',
    marginBottom: 15,
    flex: 1
  },

  btnLogout: {
    alignItems: "center",
    justifyContent: "center",
    height: 40,
    width: 150,
    backgroundColor: '#113C59',
  },

  btnLogoutText: {
    color: '#F9FFF9',
    fontSize: 20,
    textTransform: 'uppercase',
  }

});