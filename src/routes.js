import React from 'react';
import {Route, IndexRoute } from 'react-router';
import App from './App.js';
import RegisterView from './containers/RegisterView.js';
import LoginView from './containers/LoginView.js';

export default (
  <Route path="/" component={App}>
    <IndexRoute component={LoginView} />
    <Route path="login" component={LoginView}/>
    <Route path="register" component={RegisterView}/>
  </Route>
)

//<Route path="assessment/1" component={AssessmentView}/>
