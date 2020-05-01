import React, { useState, useEffect } from 'react';
import axiosInstance from '../../../../config/axiosInstance';
import {MDBTable, MDBTableHead, MDBTableBody, MDBRow, MDBCol, MDBCard, MDBModal, MDBModalBody, MDBModalHeader, MDBModalFooter, MDBCardBody, MDBIcon, MDBCardHeader, MDBBtn, MDBContainer} from 'mdbreact'
import BreadcrumSection from '../../sections/BreadcrumSection';
import CreateOrEdit from './actions/createOrEdit';
import { useDispatch, useSelector } from 'react-redux';
import { toast } from 'react-toastify';
import DeleteConfirmation from './actions/deleteOnfirmation';

const StationList = () => {
    const dispatch = useDispatch();
    const stations = useSelector(state => state.stations);
    const [modal, setModal] = useState(false);
    const [edit, setEdit] = useState(false);
    const [editedItem, setEditedItem] = useState({})

    const toggle = () => {
       
      setModal(!modal)
      if(edit) setEdit(!edit)
    }

    const notify = (value) => {
      toast(<DeleteConfirmation getStations={getStations} id={value.id}/>)
    }

    const renderStations = () => {
      return(
        stations && stations.length > 0 ?
        stations.map((value, index)=> {
          return(
            <tr>
              <td>{index+1}</td>
              <td>{value.name}</td>
              <td>{value.preStationId}</td>
              <td>{value.postStationId}</td>
              <td>{value.organizationId}</td>
              <td>
                <MDBIcon className="action-icons edit" onClick={() => {setEdit(true); toggle(); setEditedItem(value)}} icon="edit"/>
                <MDBIcon className="action-icons delete" onClick={() => {notify(value)}} icon="trash"/>
              </td>
            </tr>
          )
        })
        :<tr>موردی یافت نشد</tr>  
      )
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
        getStations();
    },[])
    return(
      <MDBContainer>
      <MDBRow>
      <MDBCol md="12">
      <BreadcrumSection title= 'ایحاد ایستگاه' openModal={toggle} />

        <MDBCard className="mt-2">
          <MDBCardBody>
        <MDBTable>
              <MDBTableHead color="primary-color">
                <tr>
                  <th>#</th>
                  <th>نام</th>
                  <th>postStationId</th>
                  <th>preStationId</th>
                  <th>سازمان</th>
                  <th>عملیات</th>
                </tr>
              </MDBTableHead>
              <MDBTableBody>
                {renderStations()}
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
                  <CreateOrEdit openModal={toggle} getStations={getStations} editItem={{edit:edit, item:editedItem }}/>
                </MDBModalBody>
              </MDBModal>
            </MDBContainer>
            
</MDBContainer>

          
            
    )
}
export default StationList;