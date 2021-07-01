import { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export default class Listar extends Component{
    constructor(props){
        super(props)
        this.state = {
            listaConsultas : [],
            listaSituacoes : [],
            atualizaDescricao : '',
            atualizaSituacao : 0,
            idConsultaSelecionado : 0,
            idSituacaoSelecionado : 0,
        }
    }

    buscarSituacoes = () => {

        axios('http://localhost:5000/api/Situacao')

        .then(resposta => {

            if (resposta.status === 200) {

                this.setState({ listaSituacoes : resposta.data })

            }
        })
        .catch(erro => console.log(erro))
    }

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

    editarConsulta = (event) => {

        event.preventDefault();

        fetch('http://localhost:5000/api/Consulta/descricao/' + this.state.idConsultaSelecionado, {
            method : "PATCH",

            body : JSON.stringify({
                descricao : this.state.atualizaDescricao
            }),

            headers : {
                "Content-Type" : "application/json",
            }
        })

        .then(resposta => {
            if (resposta.status === 204) {
                console.log('Descrição alterada com sucesso')
            }
        })

        .catch(erro => {
            console.log(erro);
        })

        .then(this.buscarTodasConsultas)

        .then(this.limparCampos)
    }

    editarSituacao = (event) => {

        event.preventDefault();

        fetch('http://localhost:5000/api/Consulta/' + this.state.idSituacaoSelecionado, {
            method : "PATCH",

            body : JSON.stringify({
                situacao1 : this.state.atualizaSituacao
            }),

            headers : {
                "Content-Type" : "application/json",
            }
        })

        .then(resposta => {
            if (resposta.status === 204) {
                console.log('Situação alterada com sucesso')
            }
        })

        .catch(erro => {
            console.log(erro);
        })

        .then(this.buscarTodasConsultas)
        .then(this.limparCampos)

    }

    editarDescricao = (consulta) => {
        this.setState({

            idConsultaSelecionado : consulta.idConsulta,

            atualizaDescricao : consulta.descricao

        })
    }

    selecionarSituacao = (consulta) => {
        this.setState({

            idSituacaoSelecionado : consulta.idConsulta,

            atualizaSituacao : consulta.idSituacao

        })
    }

    componentDidMount(){
        this.buscarSituacoes()
        this.buscarTodasConsultas()
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    limparCampos = () => {
        this.setState({
            atualizaDescricao : '',
            idConsultaSelecionado : 0,
            atualizaSituacao : 0
        })
    }

    render(){
        return(
            <>
                <main>
                    <h1>Teste Listar Todas</h1>
                    <table style={{borderCollapse : "separate", borderSpacing : 30 }} >
                        <thead>
                            <tr>
                                <th>Médico</th>
                                <th>Especialidade</th>
                                <th>Paciente</th>
                                <th>Situação</th>
                                <th>Data Consulta</th>
                                <th>Hora Consulta</th>
                                <th>Descrição</th>
                                <th>Ação</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.listaConsultas.map((consulta) => {
                                    return(
                                        <tr key={consulta.idConsulta}>
                                            <td>{consulta.idMedicoNavigation.idUsuarioNavigation.nome}</td>
                                            <td>{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</td>
                                            <td>{consulta.idPacienteNavigation.idUsuarioNavigation.nome}</td>
                                            <td>{consulta.idSituacaoNavigation.situacao1}</td>
                                            <td>{consulta.dataConsulta}</td>
                                            <td>{consulta.horaConsulta}</td>
                                            <td>{consulta.descricao}</td>
                                            <td><button onClick={() => this.editarDescricao(consulta)} >Selecionar Descrição</button></td>
                                            <td><button onClick={() => this.selecionarSituacao(consulta)} >Selecionar Situação</button></td>
                                        </tr>
                                    )
                                } )
                            }
                        </tbody>
                    </table>
                    <div>
                        <form onSubmit={this.editarConsulta}>
                            <input
                            type="text"
                            name="atualizaDescricao"
                            value={this.state.atualizaDescricao}
                            onChange={this.atualizaStateCampo}
                            placeholder="Nova descrição..."
                            />
                            <button type="submit" disabled={this.state.idConsultaSelecionado === 0 ? 'none' : ''} >Editar Descrição</button>            
                        </form>
                    </div>
                    <div>
                        <form onSubmit={this.editarSituacao}>
                            <select
                            name="atualizaSituacao"
                            value={this.state.atualizaSituacao}
                            onChange={this.atualizaStateCampo}
                            >
                                <option value="0" disabled >Selecione uma Situação</option>
                                {
                                    this.state.listaSituacoes.map( elemento => {
                                        return(
                                            <option key={elemento.idSituacao} value={elemento.idSituacao}>
                                                {elemento.situacao1}
                                            </option>
                                        );
                                    } )
                                }
                            </select>
                            <button type="submit" disabled={this.state.idSituacaoSelecionado === 0 ? 'none' : ''} >Editar Situação</button>       
                        </form>
                    </div>
                </main>
            </>
        )
    }
}