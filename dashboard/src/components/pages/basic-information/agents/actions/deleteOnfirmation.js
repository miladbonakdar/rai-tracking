import React from 'react';
import {Button} from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
const DeleteConfirmation = (props) => {
    const deleteAgent = async () => {
        try {
            const response = await axiosInstance.delete(`/Admins/v1/Agent/${props.id}`);
            props.getAgents();
        } catch (error) {
            console.log(error)
        }        
    }
    return(
        <React.Fragment>
            <p>آیا از حذف اطمینان دارید؟</p>
            <Button onClick={deleteAgent}>بله</Button>
            <Button>خیر</Button>
        </React.Fragment>
        )
}
export default DeleteConfirmation;