import React, { useState } from 'react';
import {MDBContainer, MDBRow, MDBCol, MDBBtn} from 'mdbreact';
import axiosInstance from '../../../config/axiosInstance';
import { useDispatch, useSelector } from 'react-redux';
import {toast} from 'react-toastify';
import {useHistory} from 'react-router-dom';
const Login = () => {
    const dispatch = useDispatch();
    const history = useHistory();
    const loading = useSelector(state => state.loading);
    const [loginForm, setLoginForm] = useState({
        emailOrPhoneNumber: '',
        password: ''
    });
    const submitHandler = event => {
        event.preventDefault();
        event.target.className += " was-validated";
      };
    
      const changeHandler = event => {
        setLoginForm({ 
          ...loginForm,
          [event.target.name]: event.target.value
         });
      };
      const checkValidation = () => {
        if(loginForm.emailOrPhoneNumber === '' || loginForm.password === '' )
        return false;
        else return true;
      }
      const login = async () => {
          dispatch({loading: true, type: 'SHOW_LOADING'});
          try {
              if(checkValidation()){
                const response = await axiosInstance.post('/Public/v1/Auth/SignInAdmin', loginForm);
                localStorage.setItem('user', `${response.data.data.client.name} ${response.data.data.client.lastname}`);
                dispatch({user: `${response.data.data.client.name} ${response.data.data.client.lastname}`, type: 'SET_USER'});
                toast.success(response.data.message);
                localStorage.setItem('userToken', response.data.data.token);
                dispatch({token: response.data.data.token, type: 'SET_TOKEN'});
                history.push('/dashboard');
              }
          dispatch({loading: false, type: 'SHOW_LOADING'});

          
          } catch (error) {
          }
      }
    return(
        <MDBContainer>
           <div>
           <p className="h4 text-center py-4">فرم ورود</p>
          <form
                className="needs-validation p-3"
                onSubmit={submitHandler}
                noValidate
              >
                <MDBRow>
                  <MDBCol md="4" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterNameEx"
                      className="grey-text"
                    >
                         نام کاربری یا ایمیل
                    </label>
                    <input
                      value={loginForm.emailOrPhoneNumber}
                      name="emailOrPhoneNumber"
                      onChange={changeHandler}
                      type="text"
                      id="defaultFormRegisterNameEx"
                      className="form-control"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">این فیلد اجباری است.</div>
                  </MDBCol>
                  <MDBCol md="4" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterEmailEx2"
                      className="grey-text"
                    >
                      رمز عبور
                    </label>
                    <input
                      value={loginForm.password}
                      name="password"
                      onChange={changeHandler}
                      type="text"
                      id="defaultFormRegisterEmailEx2"
                      className="form-control"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">این فیلد اجباری است.</div>
                  </MDBCol>
                  </MDBRow>
                  <MDBBtn onClick={login} color="primary" type="submit">
                  ورود
                </MDBBtn>
              </form>
           </div>
           
        </MDBContainer>
    )
}
export default Login;