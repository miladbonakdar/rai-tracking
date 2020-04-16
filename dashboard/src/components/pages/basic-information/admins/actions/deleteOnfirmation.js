import React from 'react';
import {Button} from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
import { useDispatch } from 'react-redux';
const DeleteConfirmation = (props) => {
    const dispatch = useDispatch();
    const deleteAdmin = async () => {
        dispatch({loading: true, type: 'SHOW_LOADING'})

        try {
            const response = await axiosInstance.delete(`/Admins/v1/Admin/${props.id}`);
            props.getAdmins();
        } catch (error) {
            console.log(error)
        }
        dispatch({loading: false, type: 'SHOW_LOADING'})

    }
    return(
        <React.Fragment>
            <p>آیا از حذف اطمینان دارید؟</p>
            <Button onClick={deleteAdmin}>بله</Button>
            <Button>خیر</Button>
        </React.Fragment>
        )
}
export default DeleteConfirmation;