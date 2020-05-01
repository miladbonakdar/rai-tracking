import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {useHistory} from 'react-router-dom';
import {toast} from 'react-toastify';
import {MDBContainer,MDBBtn, MDBRow, MDBCol, MDBTabPane, MDBTabContent, MDBNav, MDBNavItem, MDBNavLink, MDBIcon } from "mdbreact";

import axiosInstance from '../../../../../config/axiosInstance';
const CreateOrEdit = (props) => {
        const dispatch = useDispatch();
        const adminTypes = useSelector(state => state.adminTypes);
        const organizations = useSelector(state=> state.organizations);
        const [createForm, setCreateForm] = useState({
          name: '',
          lastname: '',
          email: '',
          phoneNumber: '',
          password: '',
          number: '',
          adminType: 'UserType.Monitor', // select
          organizationId: 1, //select
        });

        const [repeatPassword, setRepeatPassword] = useState('');
        const [repeatError, setRepeatError] = useState(false);
        
        const create = async () => {
          dispatch({loading: true, type: 'SHOW_LOADING'})
          try {
            const response = await axiosInstance.post('/Admins/v1/Admin',createForm);
            debugger
            toast.success(response.data.message);
            props.getAdmins();
            props.openModal();
          } catch (error) {
            console.log(error);
          }  
          dispatch({loading: false, type: 'SHOW_LOADING'})

        }

        const edit = async () => {
          dispatch({loading: true, type: 'SHOW_LOADING'})
          const data = createForm;
          data['id'] = props.editItem.item.id;
            try {
                const response = await axiosInstance.put('/Admins/v1/Admin', createForm);
                toast.success(response.data.message);
                props.getAdmins();
            props.openModal();

            } catch (error) {
                console.log(error);
                
            }
            dispatch({loading: false, type: 'SHOW_LOADING'})
        }

        const submitHandler = event => {
          event.preventDefault();
          event.target.className += " was-validated";
        };
      
        const changeHandler = event => {
          setCreateForm({ 
            ...createForm,
            [event.target.name]: event.target.value
           });
        };
       
       
        const getAdmin = () => {
            setCreateForm({
                ...createForm,
                name: props.editItem.item.name,
                lastname: props.editItem.item.lastname,
                password: '12345678',
                email: props.editItem.item.email,
                phoneNumber: props.editItem.item.phoneNumber,
                number: props.editItem.item.number,
                adminType:  adminTypes.filter(i=> i.key === props.editItem.item.adminType)[0].key,
                organizationId: organizations.filter(i=> i.id === props.editItem.item.organizationId)[0].id
            });
        }

    useEffect(() =>{
        if(props.editItem.edit) getAdmin();
    },[])

          return (
            <div>

      <MDBContainer>
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
                      value={createForm.name}
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
                      value={createForm.lastname}
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
                      value={createForm.email}
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
                      value={createForm.phoneNumber}
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
                      value={createForm.number}
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
                   </MDBRow>
               {
                  !props.editItem.edit ? 
                  <MDBRow>
                  <MDBCol md="4" className="mb-3">
                      <label
                        htmlFor="defaultFormRegisterPasswordEx4"
                        className="grey-text"
                      >
                        رمزعبور
                      </label>
                      <input
                        value={createForm.password}
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
                            if(event.target.value !== createForm.password){
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
                      
                  </MDBRow>
                : null  
              }
               <MDBRow>
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
                      value={createForm.adminType}
                           onChange={(event) => {
                            setCreateForm({
                              ...createForm,
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
                      value={createForm.organizationId}
                          onChange={(event) => {
                            debugger
                            setCreateForm({
                              ...createForm,
                              organizationId: Number(event.target.value)
                            })
                          }}>
                      {
                          organizations.map((org) => {
                            return(
                            <option value={org.id}>{org.name}</option>
                            )
                          })
                        }
                      </select>
                      <div className='invalid-feedback'>
                      این فیلد اجباری است.
                      </div>
                    </MDBCol>
                    
                </MDBRow>
                
                <MDBBtn onClick={props.editItem.edit ? edit : create} color="primary" type="submit">
                  {props.editItem.edit ? 'ویرایش' : 'ایجاد'}
                </MDBBtn>
                <MDBBtn onClick={() => {props.openModal()}} color="primary" type="submit">
                  خروج
                </MDBBtn>
              </form>
            
      </MDBContainer>


             </div>
          );
        }
      

export default CreateOrEdit;