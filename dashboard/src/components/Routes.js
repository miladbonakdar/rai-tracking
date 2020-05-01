import React from 'react';
import { Route, Switch } from 'react-router-dom';
import routes from '../config/routes';

const Routes = () => {
    return (
      <Switch>
          {
            routes.map((route, idx) => {
              return(
                route.child && route.child.length > 0 ?
                route.child.map((child, indx) => {
                    return(
                      <Route  
                          key={indx}
                          path={child.path}
                          exact={child.exact}
                          name={child.name}
                          render={props => (
                              <child.component {...props} />
                      )} />
                    );
                })
              :
              <Route  
                  key={idx}
                  path={route.path}
                  exact={route.exact}
                  name={route.name}
                  render={props => (
                      <route.component {...props} />
              )} />
              )
            })
          }
      </Switch>
    );
}

export default Routes;
