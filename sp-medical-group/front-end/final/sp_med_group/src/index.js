import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import reportWebVitals from './reportWebVitals';

import Listar from './pages/listar/listar';
import Home from './pages/home/home';
import Login from './pages/login/login';
import Cadastrar from './pages/cadastrar/cadastro';
import NotFound from './pages/notFound/notfound';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/listar" component={Listar} />
        <Route path="/login" component={Login} />
        <Route path="/agendar" component={Cadastrar} />
        <Route exact path="/notfound" component={NotFound} />
        <Redirect to = "/notfound" />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

reportWebVitals();
