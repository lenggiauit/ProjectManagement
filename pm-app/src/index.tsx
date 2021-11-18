import React from 'react';
import ReactDOM from 'react-dom';
import Routes from './routes/';

import { Provider } from 'react-redux';
import { store } from './store';

import reportWebVitals from './reportWebVitals';
import { setAuthenticateUser } from './store/userSlice';
import { GlobalKeys } from './types/type';
import { decrypt, encrypt } from './utils/crypter';
import { getLoggedUser } from './utils/functions';


// const loggedUser = getLoggedUser()
// if (loggedUser) {
//   store.dispatch(setAuthenticateUser(loggedUser))
// }

ReactDOM.render(
  <Provider store={store} >
    <React.StrictMode>
      <Routes />
    </React.StrictMode >
  </Provider>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
