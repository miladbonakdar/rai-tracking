import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {useHistory} from 'react-router-dom';
import {toast} from 'react-toastify';
import {MDBContainer,MDBBtn, MDBRow, MDBCol, MDBTabPane, MDBTabContent, MDBNav, MDBNavItem, MDBNavLink, MDBIcon } from "mdbreact";
import './auth.css';
import axiosInstance from '../../../config/axiosInstance';
const Register = () => {
  const dispatch = useDispatch();
  const loading = useSelector(state => state.loading);
  const adminTypes = useSelector(state => state.adminTypes);
  const organizations = useSelector(state => state.organizations);
  const history = useHistory();
  const token = useSelector(state => state.token);
        const [regForm, setRegForm] = useState({
          name: '',
          lastname: '',
          email: '',
          phoneNumber: '',
          password: '',
          number: '',
          adminType: 'UserType.SysAdmin', // select
          organizationId: 1, //select
          adminEmailAddress: '',
          rootPassword: ''
        });

        const [repeatPassword, setRepeatPassword] = useState('')
        const [repeatError, setRepeatError] = useState(false)
        //return true : valid
        //return false: not valid
        const checkValidation = () => {
          if(regForm.name === '' || regForm.lastname === '' || regForm.password.length < 8
           || regForm.phoneNumber=== '' || regForm.number=== ''
            || regForm.email=== '' || !regForm.email.includes('@') || regForm.organizationId=== '' || regForm.adminType=== ''
             || regForm.adminEmailAddress=== '' || regForm.password!== repeatPassword)
             return false;
            else return true;
        }
        const register = async () => {
          dispatch({loading: true, type: 'SHOW_LOADING'});
          try {
            if(checkValidation())
            {
              const response = await axiosInstance.post('/Public/v1/Auth/SignUpAdmin',regForm);
              localStorage.setItem('user', `${response.data.data.client.name} ${response.data.data.client.lastname}`);
              dispatch({user: `${response.data.data.client.name} ${response.data.data.client.lastname}`, type: 'SET_USER'});
              toast.success(response.data.message);
              localStorage.setItem('userToken', response.data.data.token);
              dispatch({token: response.data.data.token, type: 'SET_TOKEN'});
            dispatch({loading: false, type: 'SHOW_LOADING'});

              history.push('/dashboard');
            }
            
          } catch (error) {
            console.log(error);
          }  
          dispatch({loading: false, type: 'SHOW_LOADING'});

        }

        const submitHandler = event => {
          event.preventDefault();
          event.target.className += " was-validated";
        };
      
        const changeHandler = event => {
          setRegForm({ 
            ...regForm,
            [event.target.name]: event.target.value
           });
        };
        
useEffect(() =>{
  if(token) 
     history.push('/dashboard');
},[])

          return (
            <div>

      <MDBContainer>
        
        
          <p className="h4 text-center py-4">فرم ثبت نام</p>
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
                      نام
                    </label>
                    <input
                      value={regForm.name}
                      name="name"
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
                      نام خانوادگی
                    </label>
                    <input
                      value={regForm.lastname}
                      name="lastname"
                      onChange={changeHandler}
                      type="text"
                      id="defaultFormRegisterEmailEx2"
                      className="form-control"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">این فیلد اجباری است.</div>
                  </MDBCol>
                  <MDBCol md="4" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterConfirmEx3"
                      className="grey-text"
                    >
                      ایمیل
                    </label>
                    <input
                      value={regForm.email}
                      onChange={changeHandler}
                      type="email"
                      id="defaultFormRegisterConfirmEx3"
                      className="form-control"
                      name="email"
                      placeholder=""
                      required
                    />
                    {/* <small id="emailHelp" className="form-text text-muted">
                      We'll never share your email with anyone else.
                    </small> */}
                    <div className="invalid-feedback">ایمیل واردشده معتبر نمیباشد.</div>
                  </MDBCol>
                </MDBRow>
                <MDBRow>
                  <MDBCol md="4" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterPasswordEx4"
                      className="grey-text"
                    >
                      شماره موبایل
                    </label>
                    <input
                      value={regForm.phoneNumber}
                      onChange={changeHandler}
                      type="text"
                      id="defaultFormRegisterPasswordEx4"
                      className="form-control"
                      name="phoneNumber"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">
                      این فیلد اجباری است.
                    </div>
                    {/* <div className="valid-feedback">Looks good!</div> */}
                  </MDBCol>
                  <MDBCol md="4" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterPasswordEx4"
                      className="grey-text"
                    >
                     شماره تماس
                    </label>
                    <input
                      value={regForm.number}
                      onChange={changeHandler}
                      type="text"
                      id="defaultFormRegisterPasswordEx4"
                      className="form-control"
                      name="number"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">
                    این فیلد اجباری است.
                    </div>
                    {/* <div className="valid-feedback">Looks good!</div> */}
                  </MDBCol>
                  <MDBCol md="4" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterPasswordEx4"
                      className="grey-text"
                    >
                      رمزعبور
                    </label>
                    <input
                      value={regForm.password}
                      onChange={changeHandler}
                      type="password"
                      id="defaultFormRegisterPasswordEx4"
                      className="form-control"
                      name="password"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">
                    این فیلد اجباری است.
                    </div>
                    {/* <div className="valid-feedback">Looks good!</div> */}
                  </MDBCol>
                </MDBRow>
                <MDBRow>
                    <MDBCol md="4" className="mb-3">
                      <label
                        htmlFor="defaultFormRegisterPasswordEx4"
                        className="grey-text"
                      >
                        تکرار رمز عبور
                      </label>
                      <input
                        value={repeatPassword}
                        onChange={(event) => {
                          setRepeatPassword(event.target.value)
                          if(event.target.value !== regForm.password){
                            setRepeatError(true)
                          }
                          else{
                            setRepeatError(false)
                          }
                        }}
                        type="password"
                        id="defaultFormRegisterPasswordEx4"
                        className="form-control"
                        name="repeatPassword"
                        placeholder=""
                        required
                      />
                      {
                        repeatError === true ? 
                        <div className={`invalid-feedback ${repeatError ? 'display-customize-feedback' : ''}`}>
                          <p>تکرار رمزعبور با رمز عبور واردشده مطابقت ندارد.</p>
                        </div>
                        :''
                      }
                    </MDBCol>
                    <MDBCol md="4" className="mb-3">
                      <label
                        htmlFor="defaultFormRegisterPasswordEx4"
                        className="grey-text"
                      >
                        نوع ادمین
                      </label>
                      <select
                      required
                      className="browser-default custom-select"
                      value={regForm.adminType}
                           onChange={(event) => {
                            setRegForm({
                              ...regForm,
                              adminType: event.target.value
                            })
                          }}>
                        {
                          adminTypes.map((type) => {
                            return(
                            <option value={type.key} key={type.key}>{type.value}</option>
                            )
                          })
                        }
                       
                      </select>

                      <div className="invalid-feedback">
                      این فیلد اجباری است.
                      </div>
                      {/* <div className="valid-feedback">Looks good!</div> */}
                    </MDBCol>
                    <MDBCol md="4" className="mb-3">
                      
                    <label
                        htmlFor="defaultFormRegisterPasswordEx4"
                        className="grey-text"
                      >
                        سازمان
                      </label>
                      <select 
                      required
                      className="browser-default custom-select"
                      value={regForm.organizationId}
                          onChange={(event) => {
                            setRegForm({
                              ...regForm,
                              organizationId: Number(event.target.value)
                            })
                          }}>
                      {
                          organizations.map((org) => {
                            return(
                            <option value={org.id} key={org.id}>{org.name}</option>
                            )
                          })
                        }
                      </select>
                      <div className='invalid-feedback'>
                      این فیلد اجباری است.
                      </div>
                    </MDBCol>
                    
                </MDBRow>
                <MDBRow>
                    <MDBCol md="4" className="mb-3">
                      <label
                        htmlFor="defaultFormRegisterPasswordEx4"
                        className="grey-text"
                      >
                        نام کاربری root
                      </label>
                      <input
                      required
                        value={regForm.adminEmailAddress}
                        onChange={changeHandler}
                        type="text"
                        id="defaultFormRegisterPasswordEx4"
                        className="form-control"
                        name="adminEmailAddress"
                        placeholder=""
                        required
                      />
                      <div className="invalid-feedback">
                      این فیلد اجباری است.
                      </div>
                      {/* <div className="valid-feedback">Looks good!</div> */}
                    </MDBCol>
                    <MDBCol md="4" className="mb-3">
                      <label
                        htmlFor="defaultFormRegisterPasswordEx4"
                        className="grey-text"
                      >
                        رمزعبور root
                      </label>
                      <input
                        value={regForm.rootPassword}
                        onChange={changeHandler}
                        type="password"
                        id="defaultFormRegisterPasswordEx4"
                        className="form-control"
                        name="rootPassword"
                        placeholder=""
                        required
                      />
                      <div className="invalid-feedback">
                      این فیلد اجباری است.
                      </div>
                      {/* <div className="valid-feedback">Looks good!</div> */}
                    </MDBCol>
                </MDBRow>
                
                <MDBCol md="4" className="mb-3">
                  <div className="custom-control custom-checkbox pl-3">
                    <input
                      className="custom-control-input"
                      type="checkbox"
                      value=""
                      id="invalidCheck"
                      required
                    />
                    <label className="custom-control-label" htmlFor="invalidCheck">
                      با قوانین و مقررات موافق هستم.
                    </label>
                    <div className="invalid-feedback">
                      شما قبل از ثبت نام باید موافقت خود را با قوانین و مقررات اعلام نمایید.
                    </div>
                  </div>
                </MDBCol>
                <MDBBtn onClick={register} color="primary" type="submit">
                  ثبت نام
                </MDBBtn>
              </form>
            
      </MDBContainer>


             </div>
          );
        }
      

export default Register;