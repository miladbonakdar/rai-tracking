import React, { useState } from 'react';
import { MDBContainer, MDBRow, MDBCol, MDBBtn } from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
import { toast } from 'react-toastify';
import { useDispatch } from 'react-redux';
const ChangePass = (props) => {
    const dispatch = useDispatch();
    const [change, setChange] = useState({
        oldPassword: '',
        newPassword: '',
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
    const changePassFunc = async () => {
        dispatch({loading: true, type: 'SHOW_LOADING'})
        try {
          const data = change;
          data['domainId']=props.editItem.item.id
            const response = await axiosInstance.patch('/Admins/v1/Admin/UpdatePassword', data );
            toast.success(response.data.message);
            props.openModal();
        } catch (error) {
            console.log(error)
        }
        dispatch({loading: false, type: 'SHOW_LOADING'})

    }
    return(
        <MDBContainer>
            <div>
           <p className="h4 text-center py-4">فرم ورود</p>
          <form
                className="needs-validation p-3"
                onSubmit={submitHandler}
                noValidate
              >
                <MDBRow>
                  <MDBCol md="12" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterNameEx"
                      className="grey-text"
                    >
                         رمز عبور فعلی
                    </label>
                    <input
                      value={change.oldPassword}
                      name="oldPassword"
                      onChange={changeHandler}
                      type="text"
                      id="defaultFormRegisterNameEx"
                      className="form-control"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">این فیلد اجباری است.</div>
                  </MDBCol>
                  <MDBCol md="12" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterEmailEx2"
                      className="grey-text"
                    >
                      رمز عبور جدید
                    </label>
                    <input
                      value={change.newPassword}
                      name="newPassword"
                      onChange={changeHandler}
                      type="text"
                      id="defaultFormRegisterEmailEx2"
                      className="form-control"
                      placeholder=""
                      required
                    />
                    <div className="invalid-feedback">این فیلد اجباری است.</div>
                  </MDBCol>
                  </MDBRow>
                  <MDBBtn onClick={changePassFunc} color="primary" type="submit">
                  ثبت
                </MDBBtn>
              </form>
           </div>
           
        </MDBContainer>
    )
}
export default ChangePass;