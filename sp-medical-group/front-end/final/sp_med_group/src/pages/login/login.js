import { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export default class Login extends Component{
    constructor(props){
        super(props)
        this.state = {
            email : '',
            senha : '',
            erroMensagem : '',
        }
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <main>
                <h1>Login</h1>
                <section>
                    <div>
                        <form>
                            <input
                                type="text"
                                name="email"
                                value={this.state.email}
                                onChange={this.atualizaStateCampo}
                                placeholder="e-mail"
                            />    

                            <input
                            type="password"
                            name="senha"
                            value={this.state.senha}
                            onChange={this.atualizaStateCampo}
                            placeholder="senha"
                            />

                            <button  type="submit">Logar</button>
                        </form>
                    </div>
                </section>
            </main>
        )
    }
}