import { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export default class Cadastrar extends Component{
    constructor(props){
        super(props)
        this.state = {
            idPacienteNovo : 0,
            idMedicoNovo : 0,
            idSituacao : 1,
            dataConsulta : new Date(),
            horaConsulta : '',
            listaPacientes : [],
            listaMedicos : [],
        }
    }

    buscarPacientes = () => {

        axios('http://localhost:5000/api/Paciente')

        .then(resposta => {

            if (resposta.status === 200) {

                this.setState({ listaPacientes : resposta.data })

            }
        })
        .catch(erro => console.log(erro))
    }

    buscarMedicos = () => {

        axios('http://localhost:5000/api/Medico')

        .then(resposta => {

            if (resposta.status === 200) {

                this.setState({ listaMedicos : resposta.data })

            }
        })
        .catch(erro => console.log(erro))
    }

    limparCampos = () => {
        this.setState({
            dataConsulta : '',
            horaConsulta : '',
            idPacienteNovo : 0,
            idMedicoNovo : 0
        })
    }

    componentDidMount(){
        this.buscarPacientes()
        this.buscarMedicos()
    }

    cadastrarConsulta = (event) => {

        event.preventDefault();

        let consulta = {
            idPaciente : this.state.idPacienteNovo,
            idMedico : this.state.idMedicoNovo,
            dataConsulta : new Date( this.state.dataConsulta ),
            horaConsulta : this.state.horaConsulta,
            idSituacao : this.state.idSituacao,
            descricao : "" 
        };

        axios.post('http://localhost:5000/api/Consulta', consulta)

        .then(resposta => {

            if (resposta.status === 201) {

                console.log('Consulta Agendada')

            }
        })

        .catch(erro => {

            console.log(erro);

        })

        .then(console.log('A Consulta foi Agendada com Sucesso'))

        .then(this.limparCampos)
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <>
            <main>
                <h1>Agendamento de Consultas</h1>
                <div>
                    <form onSubmit={this.cadastrarConsulta}>
                        <div style={{ display : 'flex', flexDirection : 'column', width : '50vw' }}>

                        <select
                        name="idPacienteNovo"
                        value={this.state.idPacienteNovo}
                        onChange={this.atualizaStateCampo}
                        >
                            <option value="0" disabled > Selecione um Paciente </option>
                            {
                                this.state.listaPacientes.map( elemento => {
                                    return(
                                        <option key={elemento.idPaciente} value={elemento.idPaciente}>
                                            {elemento.idUsuarioNavigation.nome}
                                        </option>
                                    );
                                } )
                            }
                        </select>

                        <select
                        name="idMedicoNovo"
                        value={this.state.idMedicoNovo}
                        onChange={this.atualizaStateCampo}
                        >
                            <option value="0" disabled > Selecione um Médico </option>
                            {
                                this.state.listaMedicos.map( elemento => {
                                    return(
                                        <option key={elemento.idMedico} value={elemento.idMedico}>
                                            {elemento.idUsuarioNavigation.nome}
                                        </option>
                                    );
                                } )
                            }
                        </select>

                        <input 
                            required
                            type="date"
                            name="dataConsulta"
                            value={this.state.dataConsulta}
                            onChange={this.atualizaStateCampo}
                            placeholder="Data da Consulta"
                        />

                        <input 
                            required
                            type="time"
                            name="horaConsulta"
                            value={this.state.horaConsulta}
                            onChange={this.atualizaStateCampo}
                            placeholder="Hora da Consulta"
                        />

                        <button type="submit" > Agendar nova Consulta </button>
                        </div>
                    </form>
                </div>
            </main>
            </>
        )
    }
}