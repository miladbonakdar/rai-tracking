import React, {useState} from 'react';
import {MDBNav, MDBNavItem, MDBNavLink, MDBIcon, MDBContainer, MDBTabContent, MDBTabPane, MDBBtn} from 'mdbreact';
import Register from './register';
import Login from './login';
const Auth = () => {
    const [activeItemJustified , setActiveItemJustified ] = useState('1');
    const toggleJustified = (tab) => {
        if (activeItemJustified !== tab) {
          setActiveItemJustified(tab);
        }
      };
    return(
        <MDBContainer>
            <MDBNav tabs className="nav-justified nav-auth">
            <MDBNavItem >
                <MDBNavLink link to="#" active={activeItemJustified === "1"} onClick={() => {toggleJustified('1')}} role="tab" >
                <MDBIcon icon="user" /> ثبت نام
                </MDBNavLink>
            </MDBNavItem>
            <MDBNavItem>
                <MDBNavLink link to="#" active={activeItemJustified === "2"} onClick={() => {toggleJustified("2")}} role="tab" >
                <MDBIcon icon="heart" /> ورود
                </MDBNavLink>
            </MDBNavItem>
            </MDBNav>
            <MDBTabContent
            className="card"
            activeItem={activeItemJustified}
        >
                <MDBTabPane tabId="1" role="tabpanel">
                    <Register/>
                </MDBTabPane>
                <MDBTabPane tabId="2" role="tabpanel">
                    <Login/>
                </MDBTabPane>
            </MDBTabContent>
        </MDBContainer>
    )
}
export default Auth;