import './App.css';
import React from 'react';

function Hora(props)
{
  return <h2>Horário Atual : {props.date.toLocaleTimeString()}</h2>
} 

class Relogio extends React.Component
{
  constructor(props)
  {
    super(props)
    this.state =
    {
      date : new Date()
    }
  }

  render()
  {
    return(
    <div>
      <h1> Hora de Aventura </h1>
      <Hora date={this.state.date} />
    </div>
    ) 
  }

  componentDidMount()
  {
    this.timerID = setInterval( () => 
    {
      this.ticTac()
    }, 1000)
  }

  componentWillUnmount()
  {
    clearInterval(this.timerID)
  }

  ticTac()
  {
    this.setState(
      {
        date : new Date()
      }
    )
  }

  pausar()
  {
    this.state
  }
  

}

function App() 
{
  return(
    <div className="App">
      <header className="App-header">
        <Relogio />
        <input id='btn' type='button' value='Parar o Tempo' onclick={componentWillUnmount()}/>
        <Relogio />
        <input id='btn' type='button' value='Parar o Tempo' onclick={componentWillUnmount()}/>
      </header>
    </div>
  );
}

export default App;
