import React, { useState } from 'react';
import logo from "../assets/mdb-react.png";
import { MDBListGroup, MDBListGroupItem, MDBIcon,MDBCollapse, MDBBtn } from 'mdbreact';
import { NavLink, history, useHistory } from 'react-router-dom';
import routes from '../config/routes';

const TopNavigation = () => {
    const history = useHistory();
    const [collapseID, setCollapseId] = useState({
        id: ''
    })
    const toggleCollapse = (collapseid) => {
        setCollapseId({
            ...collapseID,
            id: collapseID.id !== collapseid ? collapseid : '' 
        });
      }
    return (
        <div className="sidebar-fixed position-fixed">
            <a href="#!" className="logo-wrapper waves-effect">
                <img alt="MDB React Logo" className="img-fluid" src={logo}/>
            </a>
            <MDBListGroup className="list-group-flush">
               {routes.map((route, idx) => {

                   return(
                    route.child && route.child.length > 0 ? 
                    <div>
                        <MDBListGroupItem 
                            onClick={() => {toggleCollapse(route.path) }}>
                            <MDBIcon icon="exclamation" className="mr-3" 
                                />
                            {route.perName}
                        </MDBListGroupItem>{
                        route.child.map((child, index) => {
                            return(
                                <MDBCollapse id={route.path} isOpen={collapseID.id}>
                                    <NavLink to={child.path}  activeClassName={history.location.pathname === child.path ? 'activeClass' : ''}>
                                                                <MDBListGroupItem>
                                                                    <MDBIcon icon="exclamation" className="mr-3"/>
                                                                    {child.perName}
                                                                </MDBListGroupItem>
                                    </NavLink>
                                </MDBCollapse>
                               
                            )
                        })
                       }
                    </div>
                    :
                    <NavLink to={route.path}  activeClassName={history.location.pathname === route.path ? 'activeClass' : ''}>
                        <MDBListGroupItem>
                            <MDBIcon icon="exclamation" className="mr-3"/>
                            {route.perName}
                        </MDBListGroupItem>
                    </NavLink>
                   )
               })}
            </MDBListGroup>
        </div>
    );
}

export default TopNavigation;