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
    const permissions = useSelector(state => state.permissions);
    const admins = useSelector(state => state.admins);
    const [modal, setModal] = useState(false);
    const [passModal, setPassModal] = useState(false);
    const [edit, setEdit] = useState(false);
    const [editedItem, setEditedItem] = useState({});
    const organizations = useSelector(state => state.organizations);
    const adminTypes = useSelector(state => state.adminTypes);


    const toggle = () => {
       
      setModal(!modal)
      if(edit) setEdit(!edit)
    }

    const toggleModal = () => {
      setPassModal(!passModal);
    }
    const notify = (value) => {
       
      permissions.permission.admin.delete ? 
      toast(<DeleteConfirmation getAdmins={getAdmins} id={value.id}/>)
      : toast.error('شما به این بخض دسترسی ندارید')
    }
    const showAccessError = () => {
      toast.error('شما دسترسی به این بخش ندارید')
    }
    const showUpdateElements = (value) => {
      setEdit(true)
      toggle() 
      setEditedItem(value)
    }
    const setEditItems = (value) => {
      setEditedItem(value);
      toggleModal();
    }
    const checkAccess = (key,value) => {
      switch (key) {
        case 'delete':
          permissions.permission.admin.delete ? 
          notify(value) : showAccessError()

          break;
        case 'updatePassword':
          permissions.permission.admin.updatePassword ?
          setEditItems(value) : showAccessError()
          break;

        case 'update':
          permissions.permission.admin.update ? 
          showUpdateElements(value) 
          :showAccessError()
          break;
      
        default:
          break;
      }
    }

    const renderAdmins = () => {
      return(
        admins && admins.length > 0 ?
        admins.map((value, index)=> {
          if(adminTypes.length >0 && organizations.length > 0 )
          {
            value['adminTypeValue'] = adminTypes.filter(i => i.key === value.adminType);
          value['organizationValue'] = organizations.filter(i => i.id === value.organizationId);
           
          }
          else {
            value['adminTypeValue'] = '';
            value['organizationValue'] = '';
          }
          return(
            <tr>
              <td>{index+1}</td>
              <td>{value.name} {value.lastname}</td>
              <td>{value.phoneNumber}</td>
              <td>{value.email}</td>
              <td>{value.organizationValue[0].name}</td>
              <td>{value.adminTypeValue[0].value}</td>
              <td>
                <MDBIcon onClick={() => { checkAccess('update',value)}} icon="edit"/>
                <MDBIcon onClick={() => { checkAccess('updatePassword', value)}} icon="lock"/>
                <MDBIcon onClick={() => {checkAccess('delete', value)}} icon="trash"/>
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
        
          <BreadcrumSection title= 'ایحاد ادمین' openModal={toggle} />
        
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