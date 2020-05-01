import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {useHistory} from 'react-router-dom';
import {toast} from 'react-toastify';
import {MDBContainer,MDBBtn, MDBRow, MDBCol, MDBTabPane, MDBTabContent, MDBNav, MDBNavItem, MDBNavLink, MDBIcon } from "mdbreact";

import axiosInstance from '../../../../../config/axiosInstance';
const CreateOrEdit = (props) => {
        const dispatch = useDispatch();
        const organizations = useSelector(state=> state.organizations);
        const [createForm, setCreateForm] = useState({
         
          latitude: 0,
          longitude: 0,
          altitude: 0,
          preStationId: 0,
          postStationId: 0,
          organizationId: 0
        });

        
        const create = async () => {
          dispatch({loading: true, type: 'SHOW_LOADING'})
          try {
            const response = await axiosInstance.post('/Admins/v1/station',createForm);
             
            toast.success(response.data.message);
            props.getStations();
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
                const response = await axiosInstance.put('/Admins/v1/station', createForm);
                toast.success(response.data.message);
                props.getStations();
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
            [event.target.name]: event.target.name === "preStationId" || event.target.name === "postStationId" 
                                        ? Number(event.target.value) : event.target.value
           }) 

        };
       
       
        const getStation = () => {
            setCreateForm({
                ...createForm,
                name: props.editItem.item.name,
                latitude: props.editItem.item.latitude,
                longitude: props.editItem.item.longitude,
                altitude: props.editItem.item.altitude,
                preStationId: props.editItem.item.preStationId,
                postStationId: props.editItem.item.postStationId,
                organizationId: props.editItem.item.organizationId
            });
        }

    useEffect(() =>{
        if(props.editItem.edit) getStation();
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
                      postStationId                   </label>
                    <input
                      value={createForm.postStationId}
                      name="postStationId"
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
                      preStationId
                    </label>
                    <input
                      value={createForm.preStationId}
                      onChange={changeHandler}
                      type="preStationId"
                      id="defaultFormRegisterConfirmEx3"
                      className="form-control"
                      name="preStationId"
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
                        سازمان
                      </label>
                      <select 
                      required
                      className="browser-default custom-select"
                      value={createForm.organizationId}
                          onChange={(event) => {
                             
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