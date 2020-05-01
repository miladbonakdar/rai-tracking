import React, { Component, useState } from 'react';
import { MDBNavbar, MDBNavbarBrand, MDBNavbarNav, MDBNavbarToggler, MDBCollapse, MDBNavItem, MDBDropdown, MDBDropdownToggle, MDBDropdownMenu, MDBDropdownItem, MDBIcon } from 'mdbreact';
import { useDispatch, useSelector } from 'react-redux';
import { useHistory } from 'react-router-dom';

const TopNavigation =() => {
    const dispatch = useDispatch();
    const user = useSelector(state => state.user);
    const history = useHistory();
    const [dropdownOpen, setDropdwonOpen] = useState(false)
    const [collapse, setCollapse] = useState(false);
    const onClick = () => {
        setCollapse(!collapse)
    }

    const toggle = () => {
        setDropdwonOpen(!dropdownOpen);
    }
    const logoutUser = () => {
        localStorage.removeItem('user');
        dispatch({user: '', type: 'SET_USER'});
        localStorage.removeItem('userToken');
        dispatch({token: '', type: 'SET_TOKEN'});
        history.push('/');
    }


        return (
            <MDBNavbar className="flexible-navbar" light expand="md" scrolling>
                <MDBNavbarBrand href="/">
                    <strong>راه آهن</strong>
                </MDBNavbarBrand>
                <MDBNavbarToggler onClick = { onClick } />
                <MDBCollapse isOpen = { collapse } navbar>
                    <MDBNavbarNav left>
                        <MDBNavItem>
                                <div className="notification">
                                <MDBIcon className="bell-icon" icon="bell" />
                                <span className="badge badge-danger badge-num ml-2">9</span>
                                </div>
                        </MDBNavItem>
                    </MDBNavbarNav>
                    <MDBNavbarNav right>
                    
                        <MDBNavItem>
                            
                        <MDBDropdown>
                            <MDBDropdownToggle>
                            <div className="user-icon">
                            <MDBIcon className="icons text-icons" icon="angle-down" />
                                <span>{user}</span>
                            <MDBIcon className="icons text-icons" icon="user"/>
                            
                            </div>
                            </MDBDropdownToggle>
                            <MDBDropdownMenu basic>
                                <MDBDropdownItem><MDBIcon className="icons text-icons" icon="columns"/><span className="text-icons">پروفایل</span></MDBDropdownItem>
                                <MDBDropdownItem divider />
                                <MDBDropdownItem onClick={() => {logoutUser()}}><MDBIcon className="icons text-icons" icon="sign-out-alt"/><span className="text-icons">خروج</span></MDBDropdownItem>
                            </MDBDropdownMenu>
                        </MDBDropdown>
                        </MDBNavItem>
                        <MDBNavItem>
                    </MDBNavItem>
                    <MDBNavItem>
                    </MDBNavItem>
                    </MDBNavbarNav>
                </MDBCollapse>
            </MDBNavbar>
        );
}

export default TopNavigation;