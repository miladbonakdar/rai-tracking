import React from 'react';
import {Button} from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
const DeleteConfirmation = (props) => {
    const deleteAdmin = async () => {
        try {
            const response = await axiosInstance.delete(`/Admins/v1/Admin/${props.id}`);
            props.getAdmins();
        } catch (error) {
            console.log(error)
        }

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