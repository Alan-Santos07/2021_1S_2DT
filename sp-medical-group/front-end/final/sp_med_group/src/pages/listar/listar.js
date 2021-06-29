import { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export default class Listar extends Component{
    constructor(props){
        super(props)
        this.state = {
            listaConsultas : [],
            atualizaDescricao : '',
            atualizaSituacao : 0,
        }
    }

    // buscarTodasConsultas = () =>
    // {

    //     fetch('http://localhost:5000/api/Consulta')

    //     .then(awnser => awnser.json())

    //     .then(box => this.setState({ listaConsultas : box }))

    //     .catch( erro => console.log(erro) )
    // }

    // Função que vai listar todas as consultas para o Administrador
    buscarTodasConsultas = () => {

        axios('http://localhost:5000/api/Consulta')

        .then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaConsultas : resposta.data })
                console.log(this.state.listaConsultas)
            }
          })

        console.log("oieee")
    }

    componentDidMount(){
        this.buscarTodasConsultas()
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <>
                <main>
                    <h1>Teste Listar Todas</h1>
                    <table style={{borderCollapse : "separate", borderSpacing : 30 }} >
                        <thead>
                            <tr>
                                <th>Médico</th>
                                <th>Paciente</th>
                                <th>Situação</th>
                                <th>Data Consulta</th>
                                <th>Hora Consulta</th>
                                <th>Descrição</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.listaConsultas.map((consulta) => {
                                    return(
                                        <tr key={consulta.idConsulta}>
                                            <td>{consulta.idMedicoNavigation.idUsuarioNavigation.nome}</td>
                                            <td>{consulta.idPacienteNavigation.idUsuarioNavigation.nome}</td>
                                            <td>{consulta.idSituacaoNavigation.situacao1}</td>
                                            <td>{consulta.dataConsulta}</td>
                                            <td>{consulta.horaConsulta}</td>
                                            <td>{consulta.descricao}</td>
                                        </tr>
                                    )
                                } )
                            }
                        </tbody>
                    </table>
                </main>
            </>
        )
    }
}