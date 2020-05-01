import React, { useState } from 'react';
import { MDBContainer, MDBBtn } from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
import { toast } from 'react-toastify';
import { useDispatch } from 'react-redux';
import Map from './Map/Map';
const UpdateLocation = (props) => {
    const dispatch = useDispatch();
    const [change, setChange] = useState({
        latitude: props.editItem.item.latitude,
        longitude: props.editItem.item.longitude,
        domainId: props.editItem.item.id
    });
    const submitHandler = event => {
        event.preventDefault();
        event.target.className += " was-validated";
      };
    const changeHandler = (event) => {
        setChange({ 
            ...change,
            [event.target.name]: event.target.value
           });
    }
    const updateLocFunc = async () => {
        dispatch({loading: true, type: 'SHOW_LOADING'})
        try {
            const response = await axiosInstance.patch('/Admins/v1/Depo/UpdateLocation', change );
            props.getDepos();
            toast.success(response.data.message);
            props.openModal();
        } catch (error) {
            console.log(error)
        }
        dispatch({loading: false, type: 'SHOW_LOADING'})

    }
    const setSelectedLocation = (loc) => {
      setChange({
        ...change,
        latitude: loc.latitude,
        longitude: loc.longitude
      });
    }
    return(
        <MDBContainer>
            <div>
          <form
                className="needs-validation p-3"
                onSubmit={submitHandler}
                noValidate
              >
                <Map setSelectedLocation={(loc)=>{setSelectedLocation(loc)}} editItem={props.editItem.item}/>
                <MDBBtn onClick={updateLocFunc} color="primary" type="submit">
                  ثبت
                </MDBBtn>
              </form>
           </div>
           
        </MDBContainer>
    )
}
export default UpdateLocation;