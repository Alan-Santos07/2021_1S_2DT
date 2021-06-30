import { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export default class Cadastrar extends Component{
    constructor(props){
        super(props)
        this.state = {
            idPaciente : 0,
            idMedico : 0,
            idSituacao : 1,
            dataConsulta : new Date(),
            horaConsulta : '',
            listaPacientes : [],
            listaMedicos : [],
        }
    }

    buscarPacientes = () => {

        axios('http://localhost:5000/api/Situacao')

        .then(resposta => {

            if (resposta.status === 200) {

                this.setState({ listaPacientes : resposta.data })

            }
        })
        .catch(erro => console.log(erro))
    }

    buscarMedicos = () => {

        axios('http://localhost:5000/api/Situacao')

        .then(resposta => {

            if (resposta.status === 200) {

                this.setState({ listaMedicos : resposta.data })

            }
        })
        .catch(erro => console.log(erro))
    }

    cadastrarEvento = (event) => {

        event.preventDefault();

        let consulta = {
            idPaciente : this.state.idPaciente,
            idMedico : this.state.idMedico,
            dataConsulta : new Date( this.state.dataConsulta ),
            horaConsulta : this.state.horaConsulta,
            idSituacao : this.state.idSituacao,
        };

        axios.post('http://localhost:5000/api/eventos', consulta)

        .then(resposta => {

            if (resposta.status === 201) {

                console.log('Consulta Agendada')

            }
        })

        .catch(erro => {

            console.log(erro);

        })

        .then(console.log('A Consulta foi Agendada com Sucesso'))
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
                    <form>
                        <div style={{ display : 'flex', flexDirection : 'column', width : '50vw' }}>
                        <select></select>
                        <select></select>
                        <input></input>
                        <input></input>
                        <button type="submit" > Agendar nova Consulta </button>
                        </div>
                    </form>
                </div>
            </main>
            </>
        )
    }
}