import React from 'react';
import {Button} from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
const DeleteConfirmation = (props) => {
    const deleteStation = async () => {
        try {
            const response = await axiosInstance.delete(`/Admins/v1/Station/${props.id}`);
            props.getStation();
        } catch (error) {
            console.log(error)
        }
    }
    return(
        <React.Fragment>
            <p>آیا از حذف اطمینان دارید؟</p>
            <Button onClick={deleteStation}>بله</Button>
            <Button>خیر</Button>
        </React.Fragment>
        )
}
export default DeleteConfirmation;