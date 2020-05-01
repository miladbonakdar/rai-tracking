import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {useHistory} from 'react-router-dom';
import {toast} from 'react-toastify';
import {MDBContainer,MDBBtn, MDBRow, MDBCol, MDBTabPane, MDBTabContent, MDBNav, MDBNavItem, MDBNavLink, MDBIcon } from "mdbreact";

import axiosInstance from '../../../../../config/axiosInstance';
const CreateOrEdit = (props) => {
        const dispatch = useDispatch();
        const depos = useSelector(state => state.depos);
        const [createForm, setCreateForm] = useState({
          name: '',
          lastname: '',
          email: '',
          phoneNumber: '',
          password: '',
          depoId: 1, //select
        });

        const [repeatPassword, setRepeatPassword] = useState('');
        const [repeatError, setRepeatError] = useState(false);
        
        const create = async () => {
          try {
            const response = await axiosInstance.post('/Admins/v1/Agent',createForm);
             
            toast.success(response.data.message);
            props.getAgents();
            props.openModal();
          } catch (error) {
            console.log(error);
          }  
        }

        const edit = async () => {
            try {
              const data = createForm;
              data['password'] = "12345678";
              data['id'] = props.editItem.item.id;
                const response = await axiosInstance.put('/Admins/v1/Agent', data);
                 debugger
                toast.success(response.data.message);
                props.getAgents();
                props.openModal();
            } catch (error) {
                console.log(error);
                
            }
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
       
       
        const getAgent = () => {
           
            setCreateForm({
                ...createForm,
                name: props.editItem.item.name,
                lastname: props.editItem.item.lastname,
                password: props.editItem.item.password,
                email: props.editItem.item.email,
                phoneNumber: props.editItem.item.phoneNumber,
                depoId: depos.filter(i=> i.id === props.editItem.item.depoId)[0].id
            });
        }
        const getDepos = async () => {
           
          const response = await axiosInstance.get('/Admins/v1/Depo/100/0');
          dispatch({depos: response.data.data.list, type: 'SET_DEPOS'});
        }

    useEffect(() =>{
      if(depos.length === 0){
        getDepos();
      }
      if(props.editItem.edit) getAgent();
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
                          depo
                        </label>
                        <select 
                        
                        className="browser-default custom-select"
                        value={createForm.depoId}
                            onChange={(event) => {
                               
                              setCreateForm({
                                ...createForm,
                                depoId: Number(event.target.value)
                              })
                            }}>

                        {
                            depos.map((depo) => {
                              return(
                              <option value={depo.id} key={depo.id}>{depo.name}</option>
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
               {
                  !props.editItem.edit ? 
                    <React.Fragment>
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
                
                    </React.Fragment>
                  : null  
              }
                  
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