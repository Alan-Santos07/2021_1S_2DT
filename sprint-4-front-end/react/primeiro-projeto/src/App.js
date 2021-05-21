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

  pausar() {    
    console.log(`Relógio ${this.timerID} pausado!`)
    clearInterval(this.timerID)
  }

  voltar()
  {
    this.timerID = setInterval( () => 
    {
      this.ticTac()
    }, 1000)
    console.log(`Relógio ${this.timerID} retomado! Agora eu sou o Relógio ${this.timerID}`)
  }

  render()
  {
    return(
    <div>
      <h1> Relógio Mágico </h1>
      <Hora date={this.state.date} />
      <button onClick={() => this.pausar()} 
        style=
        {{
          color: "#FFF5F7", 
          backgroundColor: "#FF4242",
          fontWeight: "600",
          margin: "20px",
          padding: "10px 10px",
          border: "none",
          outline: "none",
        }}
      > Pausar Relógio {this.timerID}  </button>
      <button onClick={() => this.voltar()}
      style=
      {{
        color: "#FFF5F7", 
        backgroundColor: "#338F4D",
        fontWeight: "600",
        margin: "20px",
        padding: "10px 10px",
        border: "none",
        outline: "none",
      }}
      > Retomar Relógio {this.timerID} </button>
    </div>
    ) 
  }

}

function App() 
{
  return(
    <div className="App">
      <header className="App-header">
        <Relogio />        
        <Relogio />
      </header>
    </div>
  );
}

export default App;
