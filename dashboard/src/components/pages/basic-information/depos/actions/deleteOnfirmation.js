import React from 'react';
import {Button} from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
import { useDispatch } from 'react-redux';
const DeleteConfirmation = (props) => {
    const deleteDepo = async () => {

        try {
            const response = await axiosInstance.delete(`/Admins/v1/Depo/${props.id}`);
            props.getDepos();
        } catch (error) {
            console.log(error)
        }

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