import React, {useState, useEffect} from "react";
import GridContainer from "../../../components/Grid/GridContainer";
import GridItem from "../../../components/Grid/GridItem";
import CustomInput from "../../../components/CustomInput/CustomInput";
import Button from "../../../components/CustomButtons/Button";
import axiosInstance from 'config/axios/axiosInstance';
import {useDispatch, useSelector} from 'react-redux';
import {toast} from 'react-toastify';
import {useHistory} from 'react-router-dom';

const Login = () => {
  const dispatch = useDispatch();
  const token = useSelector(state => state.token);
  const history = useHistory();
  const [loginInfo, setLoginInfo] = useState({
    emailOrPhoneNumber: "",
    password: ""
  });
  const [emailError, setEmailError] = useState(false)
  const [passError, setPassError] = useState(false)

  const login = async () => {
    loginInfo.emailOrPhoneNumber === "" ? setEmailError(true) : setEmailError(false)
    loginInfo.password === "" ? setPassError(true) : setPassError(false)
    if(loginInfo.emailOrPhoneNumber !== "" && loginInfo.password !== "" ){
        try {
          const response =  await axiosInstance.post('/Public/v1/Auth/SignInAdmin',{
            emailOrPhoneNumber: loginInfo.emailOrPhoneNumber,
            password: loginInfo.password
          });
          debugger
          localStorage.setItem('user', `${response.data.data.client.name} ${response.data.data.client.lastname}`);
          dispatch({user: `${response.data.data.client.name} ${response.data.data.client.lastname}`, type: 'SET_USER'});        
          toast.success(response.data.message);
          localStorage.setItem('userToken', response.data.data.token);
          dispatch({token: response.data.data.token, type: 'SET_TOKEN'});
          history.push('/rtl/dashboard');
        } catch (error) {
          console.log(error);
          
        }
    }


  }
  useEffect(() => {
    if(token) history.push('/rtl/dashboard');
  },[])
  return(
      <React.Fragment>
        <GridContainer direction="row"
                       justify="center"
                       alignItems="center">
          <GridItem xs={12} sm={12} md={12}>
            <CustomInput
              labelText="ایمیل/شماره تماس"
              error={emailError}
              formControlProps={{
                fullWidth: true
              }}
              value={loginInfo.emailOrPhoneNumber}
             inputProps={{
               type: "text",
               onChange: (event) => {
                   setLoginInfo({
                     ...loginInfo,
                     emailOrPhoneNumber: event.target.value
                   })
                 }
               }}
            />

          </GridItem>
          <GridItem xs={12} sm={12} md={12}>
            <CustomInput
              labelText="رمز عبور"
              error={passError}
              formControlProps={{
                fullWidth: true
              }}
              value={loginInfo.password}
              inputProps={{
                type: "password",
                onChange: (event) => {
                  setLoginInfo({
                    ...loginInfo,
                    password: event.target.value
                  })
                }
              }}
            />
          </GridItem>
        </GridContainer>
        <Button color="primary" onClick={login}>ورود</Button>

      </React.Fragment>
  )
}
export default Login;
