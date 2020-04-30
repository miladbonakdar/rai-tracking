import React, { useState, useEffect } from 'react';
import axiosInstance from '../../../../config/axiosInstance';
import {MDBTable, MDBTableHead, MDBTableBody, MDBRow, MDBCol, MDBCard, MDBModal, MDBModalBody, MDBModalHeader, MDBModalFooter, MDBCardBody, MDBIcon, MDBCardHeader, MDBBtn, MDBContainer} from 'mdbreact'
import BreadcrumSection from '../../sections/BreadcrumSection';
import CreateOrEdit from './actions/createOrEdit';
import { useDispatch, useSelector } from 'react-redux';
import { toast } from 'react-toastify';
import DeleteConfirmation from './actions/deleteOnfirmation';
import ChangePass from './actions/updateLocation';

const DepoList = () => {
    const dispatch = useDispatch();
    const stations = useSelector(state => state.stations);
    const permissions = useSelector(state => state.permissions);
    const depos = useSelector(state => state.depos);
    const [modal, setModal] = useState(false);
    const [passModal, setPassModal] = useState(false);
    const [edit, setEdit] = useState(false);
    const [editedItem, setEditedItem] = useState({})

    const toggle = () => {
       
      setModal(!modal)
      if(edit) setEdit(!edit)
    }

    const toggleModal = () => {
      setPassModal(!passModal);
    }
    const notify = (value) => {
      permissions.permission.depo.delete ? 
      toast(<DeleteConfirmation getDepos={getDepos} id={value.id}/>)
      : toast.error('شما به این بخض دسترسی ندارید')
    }
    const showAccessError = () => {
      toast.error('شما دسترسی به این بخش ندارید')
    }
    const showUpdateElements = (value) => {
      setEdit(true);
      toggle();
      setEditedItem(value)
    }
    const setEditItems = (value) => {
      setEditedItem(value);
      toggleModal();
    }
    const checkAccess = (key,value) => {
      switch (key) {
        case 'delete':
          permissions.permission.depo.delete ? 
          notify(value) : showAccessError()

          break;
        case 'updateLocation':
          permissions.permission.depo.updateLocation ?
          setEditItems(value) : showAccessError()
          break;

        case 'update':
          permissions.permission.depo.update ? 
          showUpdateElements(value) 
          :showAccessError()
          break;
      
        default:
          break;
      }
    }
    const renderDepos = () => {
      return(
        depos && depos.length > 0 ?
        depos.map((value, index)=> {
          return(
            <tr>
              <td>{index+1}</td>
              <td>{value.name} {value.lastname}</td>
              <td>{value.phoneNumber}</td>
              <td>{value.email}</td>
              <td>{value.organizationId}</td>
              <td>{value.adminType}</td>
              <td>
                <MDBIcon onClick={() => { checkAccess('update',value)}} icon="edit"/>
                <MDBIcon onClick={() => { checkAccess('updateLocation', value)}} icon="lock"/>
                <MDBIcon onClick={() => {checkAccess('delete', value)}} icon="trash"/>
              </td>
            </tr>
          )
        })
        :<tr>No Item</tr>  
      )
    }
    
    const getDepos = async () => {
      dispatch({loading: true, type: 'SHOW_LOADING'})

        try {
        const response = await axiosInstance.get(`/Admins/v1/Depo/10/0`);
        dispatch({depos: response.data.data.list, type: 'SET_DEPOS'})
        
        } catch (error) {
            console.log(error);
        }
        dispatch({loading: false, type: 'SHOW_LOADING'})

      }

      const getStations = async () => {
        dispatch({loading: true, type: 'SHOW_LOADING'});
        try {
        const response = await axiosInstance.get(`/Admins/v1/Station/10/0`);
        dispatch({stations: response.data.data.list, type: 'SET_STATIONS'})
        
        } catch (error) {
            console.log(error);
        }
        dispatch({loading: false, type: 'SHOW_LOADING'})

      }
    useEffect(() => {
      if(stations.length === 0) getStations();
        getDepos();
    },[])
    return(
      <MDBContainer>
      <MDBRow>
      <MDBCol md="12">
      <BreadcrumSection title= 'ایحاد depo' openModal={toggle} />

        <MDBCard className="mt-2">
          <MDBCardBody>
        <MDBTable>
              <MDBTableHead color="primary-color">
                <tr>
                  <th>#</th>
                  <th>نام و نام خانوادگی</th>
                  <th>شماره تماس</th>
                  <th>ایمیل</th>
                  <th>سازمان</th>
                  <th>نوع ادمین</th>
                  <th>عملیات</th>
                </tr>
              </MDBTableHead>
              <MDBTableBody>
                {renderDepos()}
              </MDBTableBody>
            </MDBTable>
            </MDBCardBody>
            </MDBCard>
            </MDBCol>
            </MDBRow>
            <MDBContainer>
              <MDBModal size="lg" isOpen={modal} toggle={toggle}>
                <MDBModalHeader toggle={toggle}>{edit ? 'فرم ویرایش' : 'فرم ایجاد'}</MDBModalHeader>
                <MDBModalBody>
                  <CreateOrEdit openModal={toggle} getDepos={getDepos} editItem={{edit:edit, item:editedItem }}/>
                </MDBModalBody>
              </MDBModal>
            </MDBContainer>
            
            <MDBContainer>
              <MDBModal size="sm" isOpen={passModal} toggle={toggleModal}>
                <MDBModalHeader toggle={toggleModal}>تغییر رمز عبور</MDBModalHeader>
                <MDBModalBody>
                  <ChangePass openModal={toggleModal} editItem={{item:editedItem }}/>
                </MDBModalBody>
              </MDBModal>
            </MDBContainer>
    
</MDBContainer>

          
            
    )
}
export default DepoList;