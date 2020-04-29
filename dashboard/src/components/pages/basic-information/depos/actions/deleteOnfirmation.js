import React from 'react';
import {Button} from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
import { useDispatch } from 'react-redux';
const DeleteConfirmation = (props) => {
    const dispatch = useDispatch();
    const deleteDepo = async () => {
        dispatch({loading: true, type: 'SHOW_LOADING'})

        try {
            const response = await axiosInstance.delete(`/Admins/v1/Depo/${props.id}`);
            props.getDepos();
        } catch (error) {
            console.log(error)
        }
        dispatch({loading: false, type: 'SHOW_LOADING'})

    }
    return(
        <React.Fragment>
            <p>آیا از حذف اطمینان دارید؟</p>
            <Button onClick={deleteDepo}>بله</Button>
            <Button>خیر</Button>
        </React.Fragment>
        )
}
export default DeleteConfirmation;