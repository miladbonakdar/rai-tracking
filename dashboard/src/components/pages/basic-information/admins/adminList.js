import React, { useState, useEffect } from 'react';
import axiosInstance from '../../../../config/axiosInstance';
import {MDBTable, MDBTableHead, MDBTableBody, MDBRow, MDBCol, MDBCard, MDBModal, MDBModalBody, MDBModalHeader, MDBModalFooter, MDBCardBody, MDBIcon, MDBCardHeader, MDBBtn, MDBContainer} from 'mdbreact'
import BreadcrumSection from '../../sections/BreadcrumSection';
import CreateOrEdit from './actions/createOrEdit';
import { useDispatch, useSelector } from 'react-redux';
import { toast } from 'react-toastify';
import DeleteConfirmation from './actions/deleteOnfirmation';
import ChangePass from './actions/changePass';

const AdminList = () => {
    const dispatch = useDispatch();
    const admins = useSelector(state => state.admins);
    const [modal, setModal] = useState(false);
    const [passModal, setPassModal] = useState(false);
    const [edit, setEdit] = useState(false);
    const [editedItem, setEditedItem] = useState({})

    const toggle = () => {
      debugger
      setModal(!modal)
      if(edit) setEdit(!edit)
    }

    const toggleModal = () => {
      setPassModal(!passModal);
    }
    const notify = (value) => {
      toast(<DeleteConfirmation getAdmins={getAdmins} id={value.id}/>)
    }

    const renderAdmins = () => {
      return(
        admins && admins.length > 0 ?
        admins.map((value, index)=> {
          return(
            <tr>
              <td>{index+1}</td>
              <td>{value.name} {value.lastname}</td>
              <td>{value.phoneNumber}</td>
              <td>{value.email}</td>
              <td>{value.organizationId}</td>
              <td>{value.adminType}</td>
              <td>
                <MDBIcon onClick={() => {setEdit(true); toggle(); setEditedItem(value)}} icon="edit"/>
                <MDBIcon onClick={() => {toggleModal()}} icon="lock"/>
                <MDBIcon onClick={() => {notify(value)}} icon="trash"/>
              </td>
            </tr>
          )
        })
        :<tr>No Item</tr>  
      )
    }
    
    const getAdmins = async () => {
      dispatch({loading: true, type: 'SHOW_LOADING'})

        try {
        const response = await axiosInstance.get(`/Admins/v1/Admin/10/0`);
        dispatch({admins: response.data.data.list, type: 'SET_ADMINS'})
        
        } catch (error) {
            console.log(error);
        }
        dispatch({loading: false, type: 'SHOW_LOADING'})

      }
    useEffect(() => {
        getAdmins();
    },[])
    return(
      <MDBContainer>
      <MDBRow>
      <MDBCol md="12">
      <BreadcrumSection title={edit ? 'ویرایش ادمین':'ایحاد ادمین'} openModal={toggle} />

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
                {renderAdmins()}
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
                  <CreateOrEdit openModal={toggle} getAdmins={getAdmins} editItem={{edit:edit, item:editedItem }}/>
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
export default AdminList;