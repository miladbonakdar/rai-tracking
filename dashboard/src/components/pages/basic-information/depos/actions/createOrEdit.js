import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {useHistory} from 'react-router-dom';
import {toast} from 'react-toastify';
import {MDBContainer,MDBBtn, MDBRow, MDBCol, MDBTabPane, MDBTabContent, MDBNav, MDBNavItem, MDBNavLink, MDBIcon } from "mdbreact";

import axiosInstance from '../../../../../config/axiosInstance';
const CreateOrEdit = (props) => {

        const dispatch = useDispatch();
        const stations = useSelector(state => state.stations);
        const organizations = useSelector(state => state.organizations);
        const [location, setLocation] = useState({
          latitude: 0,
          longitude: 0
        });
        const [createForm, setCreateForm] = useState({
          name: '',
          stationId: 0,
          organizationId: 0, //select
        });

        const [repeatPassword, setRepeatPassword] = useState('');
        const [repeatError, setRepeatError] = useState(false);
        
        const create = async () => {
          const data = {
            location: location,
            name: createForm.name,
            organizationId: createForm.organizationId,
            stationId: createForm.stationId
          }
          debugger
          dispatch({loading: true, type: 'SHOW_LOADING'})
          try {
            const response = await axiosInstance.post('/Admins/v1/Depo',data);
            debugger
            toast.success(response.data.message);
            props.getDepos();
            props.openModal();
          } catch (error) {
            console.log(error);
          }  
          dispatch({loading: false, type: 'SHOW_LOADING'})

        }

        const edit = async () => {
          dispatch({loading: true, type: 'SHOW_LOADING'})
          const data = {
            id: props.editItem.item.id,
            location: location,
            name: createForm.name,
            organizationId: createForm.organizationId,
            stationId: createForm.stationId
          }
            try {
                const response = await axiosInstance.put('/Admins/v1/Depo', data);
                toast.success(response.data.message);
                props.getDepos();
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
       
       
        const getDepo = () => {
          setLocation({
            longitude: props.editItem.item.latitude,
            latitude: props.editItem.item.latitude
          })
            setCreateForm({
                ...createForm,
                name: props.editItem.item.name,
                stationId: props.editItem.item.stationId,
                organizationId: organizations.filter(i=> i.id === props.editItem.item.organizationId)[0]
            });
        }

    useEffect(() =>{
        if(props.editItem.edit) getDepo();
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
                      placeholder="علی"
                      required
                    />
                    <div className="invalid-feedback">این فیلد اجباری است.</div>
                  </MDBCol>
                  </MDBRow>
                
               <MDBRow>
                <MDBCol md="4" className="mb-3">
                      <label
                        htmlFor="defaultFormRegisterPasswordEx4"
                        className="grey-text"
                      >
                        نوع ایستگاه
                      </label>
                      <select
                      required
                      className="browser-default custom-select"
                      value={createForm.stationId}
                           onChange={(event) => {
                            setCreateForm({
                              ...createForm,
                              stationId: Number(event.target.value)
                            })
                          }}>
                        {
                          stations.map((station) => {
                            return(
                            <option value={station.id} key={station.key}>{station.name}</option>
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
                  close
                </MDBBtn>
              </form>
            
      </MDBContainer>


             </div>
          );
        }
      

export default CreateOrEdit;