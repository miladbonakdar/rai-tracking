import React, { useState } from 'react';
import { MDBContainer, MDBRow, MDBCol, MDBBtn } from 'mdbreact';
import axiosInstance from '../../../../../config/axiosInstance';
import { toast } from 'react-toastify';
const ChangePass = (props) => {
    const [change, setChange] = useState({
        password: '',
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
        
        try {
          if(change.password.length<8) toast.error('پسورد باید شامل 8 کاراکتر باشد.');
          else
            {
              const response = await axiosInstance.patch('/Admins/v1/Agent/ResetPassword', change );
             props.openModal();
            toast.success(response.data.message);
            }
        } catch (error) {
            console.log(error)
        }
    }
    return(
        <MDBContainer>
            <div>
          <form
                className="needs-validation p-3"
                onSubmit={submitHandler}
                noValidate
              >
                <MDBRow>
                  <MDBCol md="12" className="mb-3">
                    <label
                      htmlFor="defaultFormRegisterEmailEx2"
                      className="grey-text"
                    >
                      رمزعبور جدید
                    </label>
                    <input
                      value={change.password}
                      name="password"
                      onChange={changeHandler}
                      type="password"
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