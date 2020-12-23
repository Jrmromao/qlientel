import React from 'react';
import ReactDOM from 'react-dom';
import '../src/app/styles/index.css';
import * as serviceWorker from './serviceWorker';
import { Router } from 'react-router';
import {createBrowserHistory} from 'history';
import 'react-widgets/dist/css/react-widgets.css';
import dateFnsLocalizer from 'react-widgets-date-fns';
import App from './app/layout/common/App';

 dateFnsLocalizer();

export const history = createBrowserHistory();
ReactDOM.render(
  <Router history={history}>
 {/* <React.StrictMode>     </React.StrictMode> */}
    

      <App/>
 
  </Router>,
  document.getElementById("root")
);
serviceWorker.unregister();
