import React, { useState, useEffect } from 'react';
import axiosInstance from '../../../../config/axiosInstance';
import {MDBTable, MDBTableHead, MDBTableBody, MDBRow, MDBCol, MDBCard, MDBModal, MDBModalBody, MDBModalHeader, MDBModalFooter, MDBCardBody, MDBIcon, MDBCardHeader, MDBBtn, MDBContainer} from 'mdbreact'
import BreadcrumSection from '../../sections/BreadcrumSection';
import CreateOrEdit from './actions/createOrEdit';
import { useDispatch, useSelector } from 'react-redux';
import { toast } from 'react-toastify';
import DeleteConfirmation from './actions/deleteOnfirmation';
import ChangePass from './actions/changePass';

const AgentList = () => {
    const dispatch = useDispatch();
    const depos = useSelector(state => state.depos);
    const permissions = useSelector(state => state.permissions);
    const agents = useSelector(state => state.agents);
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
  

    const renderAgents = () => {
      return(
        agents && agents.length > 0 ?
        agents.map((value, index)=> {
          if(depos.length > 0 )
          {
            
           value['depoValue'] = depos.filter(i => i.id === value.depoId);
          }
          return(
            <tr>
              <td>{index+1}</td>
              <td>{value.name} {value.lastname}</td>
              <td>{value.phoneNumber}</td>
              <td>{value.email}</td>
              <td>{value.depoValue ? value.depoValue[0].name : ''}</td>
              <td>
                <MDBIcon onClick={() => { checkAccess('update',value)}} icon="edit"/>
                <MDBIcon onClick={() => { checkAccess('resetPassword', value)}} icon="lock"/>
                <MDBIcon onClick={() => {checkAccess('delete', value)}} icon="trash"/>
              </td>
            </tr>
          )
        })
        :<tr>No Item</tr>  
      )
    }
    
    const getAgents = async () => {
        try {
        const response = await axiosInstance.get(`/Admins/v1/Agent/10/0`);
        dispatch({agents: response.data.data.list, type: 'SET_AGENTS'})
        
        } catch (error) {
            console.log(error);
        }
    }
    const notify = (value) => {
      permissions.permission.agent.delete ? 
      toast(<DeleteConfirmation getAgents={getAgents} id={value.id}/>)
      : toast.error('شما به این بخض دسترسی ندارید')
    }
    const showAccessError = () => {
      toast.error('شما دسترسی به این بخش ندارید')
    }
    const showUpdateElements = (value) => {
      debugger
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
          permissions.permission.agent.delete ? 
          notify(value) : showAccessError()

          break;
        case 'resetPassword':
          permissions.permission.agent.resetPassword ?
          setEditItems(value) : showAccessError()
          break;

        case 'update':
          permissions.permission.agent.update ? 
          showUpdateElements(value) 
          :showAccessError()
          break;
      
        default:
          break;
      }
    }
    const getDepos = async () => {
      const response = await axiosInstance.get('/Admins/v1/Depo/100/0');
      dispatch({depos: response.data.data.list, type: 'SET_DEPOS'});
    }
    useEffect(() => {
        getAgents();
        if(depos.length === 0) getDepos();
    },[])
    return(
      <MDBContainer>
      <MDBRow>
      <MDBCol md="12">
      <BreadcrumSection title={edit ? 'ویرایش تعمیرکار':'ایحاد تعمیر کار'} openModal={toggle} />

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
                  <th>عملیات</th>
                </tr>
              </MDBTableHead>
              <MDBTableBody>
                {renderAgents()}
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
                  <CreateOrEdit openModal={toggle} getAgents={getAgents} editItem={{edit:edit, item:editedItem }}/>
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
export default AgentList;