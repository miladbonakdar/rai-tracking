import React, { useState } from 'react';
import logo from "../assets/Logo.png";
import { MDBListGroup, MDBListGroupItem, MDBIcon,MDBCollapse, MDBBtn } from 'mdbreact';
import { NavLink, history, useHistory } from 'react-router-dom';
import routes from '../config/routes';

const TopNavigation = () => {
    const history = useHistory();
    const [collapseID, setCollapseId] = useState({
        id: ''
    })
    const [toggleIcon, setToggleIcon] = useState(false);
    const toggleCollapse = (collapseid) => {
        setCollapseId({
            ...collapseID,
            id: collapseID.id !== collapseid ? collapseid : '' 
        });
      }
      const handleToggle = (route) => {
        toggleCollapse(route.path);
        setToggleIcon(!toggleIcon);
      }
    return (
        <div className="sidebar-fixed position-fixed">
            <a href="#!" className="logo-wrapper waves-effect logo">
                <img alt="Rai Tracking" className="img-fluid" src={logo}/>
            </a>
            <MDBListGroup className="list-group-flush">
               {routes.map((route, idx) => {

                   if(!route.meta.needAuth)
                   return(
                    route.child && route.child.length > 0 ? 
                    <div>
                        <MDBListGroupItem 
                            onClick={() => {handleToggle(route) }}>
                            <MDBIcon icon={route.meta.icon} className="mr-3" 
                                />
                                <span className="parent-route">
                                    {route.perName}
                                </span>
                            <MDBIcon className="icons" icon={toggleIcon ? 'angle-up' : 'angle-down'}/>
                        </MDBListGroupItem>{
                        route.child.map((child, index) => {
                            return(
                                <MDBCollapse id={route.path} isOpen={collapseID.id}>
                                    <NavLink to={child.path}  activeClassName={history.location.pathname === child.path ? 'activeClass' : ''}>
                                                                <MDBListGroupItem>
                                                                    <MDBIcon icon={child.meta.icon} className="mr-3"/>
                                                                    <span className="child-route">{child.perName}</span>
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
                            <MDBIcon icon={route.meta.icon} className="mr-3"/>
                            <span className="parent-route">{route.perName}</span>
                        </MDBListGroupItem>
                    </NavLink>
                   )
                   else return null
               })}
            </MDBListGroup>
        </div>
    );
}

export default TopNavigation;