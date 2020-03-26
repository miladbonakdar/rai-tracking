import React, {useState, useEffect} from "react";
import './register.css';
import GridItem from "../../../components/Grid/GridItem";
import GridContainer from "../../../components/Grid/GridContainer";
import CustomInput from "../../../components/CustomInput/CustomInput";
import Button from "../../../components/CustomButtons/Button";
import {Select, MenuItem, InputLabel} from "@material-ui/core";
import {useHistory} from "react-router-dom";
import axiosInstance from "config/axios/axiosInstance";
import { toast } from "react-toastify";
import {useDispatch, useSelector} from "react-redux";

const Register = () => {
  const dispatch = useDispatch();
  const token = useSelector(state => state.token);
  const history = useHistory();
  const [regInfo, setRegInfo] = useState({
    name: "",
    lastName: "",
    email: "",
    phoneNumber: "",
    password: "",
    number: "",
    adminType: "UserType.SysAdmin",
    organizationId: 1,
    adminEmailAddress: "",
    rootPassword: ""
  });
  const [adminTypes, setAdminTypes] = useState({list: []});
  const [organizations, setOrganizations] = useState({list: []})

  const [repeatPass, setRepeatPass] = useState("");
  const [error, setError] = useState({
      name: false,
      lastName: false,
      email: false,
      password: false,
      matchedPass: false,
      adminType: false,
      organization: false,
      rootUsername: false,
      rootPassword: false
  });
  const [hasError, setHasError] = useState(false)
  const checkValidations = () => {
    if(regInfo.name === "") {
      setError({...error, name: true});
      setHasError(true);
    }
    if(regInfo.lastName === "") {
      setError({...error, lastName: true});
      setHasError(true);
    }
    if(regInfo.email === "") {
      setError({...error, email: true});
      setHasError(true);
    }
    if(regInfo.password === "" || regInfo.password !== repeatPass) {
      setError({...error, matchedPass: true});
      setHasError(true);
    }
    if(regInfo.adminType === 0) {
      setError({...error, adminType: true});
      setHasError(true);
    }
    if(regInfo.organization === 0) {
      setError({...error, organization: true});
      setHasError(true);
    }
    if(regInfo.rootUsername === "") {
      setError({...error, rootUsername: true});
      setHasError(true);
    }
    if(regInfo.rootPassword === "") {
      setError({...error, rootUsername: true});
      setHasError(true);
    }
    if(hasError === true)
      return false;
    else
      return true;
  }
  const register = async () => {
    debugger;
    if(checkValidations()){
      try {
        const response = await axiosInstance.post('/Public/v1/Auth/SignUpAdmin',regInfo);
        debugger
        localStorage.setItem('user', `${response.data.data.client.name} ${response.data.data.client.lastname}`);
        dispatch({user: `${response.data.data.client.name} ${response.data.data.client.lastname}`, type: 'SET_USER'});
        toast.success(response.data.message);
        localStorage.setItem('userToken', response.data.data.token);
        dispatch({token: response.data.data.token, type: 'SET_TOKEN'});
        history.push('/rtl/dashboard');
      } catch (error) {
        console.log(error);
        toast.error(error.response.data.Message)
      }      
    }
  }
  const getAdminTypes = async () => {
    const response = await axiosInstance.get('/Public/v1/Auth/AdminTypes');
    setAdminTypes({
      ...adminTypes,
      list: response.data.data
    });
  }
  const getOrganizations = async () => {
  }
  useEffect(()=>{
    (token) ?
     history.push('/rtl/dashboard')
    :
    getAdminTypes();
    getOrganizations();
  },[])
  return(
    <React.Fragment>
      <GridContainer>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="نام"
            formControlProps={{
              fullWidth: true
            }}
            error={error.name}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  name: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="نام خانوادگی"
            formControlProps={{
              fullWidth: true
            }}
            error={error.lastName}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  lastName: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="ایمیل"
            formControlProps={{
              fullWidth: true
            }}
            error={error.email}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  email: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="شماره تماس"
            formControlProps={{
              fullWidth: true
            }}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  phoneNumber: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="رمزعبور"
            formControlProps={{
              fullWidth: true
            }}
            error={error.password}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  password: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="تکرار رمز عبور"
            formControlProps={{
              fullWidth: true
            }}
            error={error.password}
            inputProps={{
              onChange: (event) => {
                setRepeatPass(event.target.value)
              }
            }
            }
          />
        </GridItem>
      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="شماره"
            formControlProps={{
              fullWidth: true
            }}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  number: event.target.value
                })
              }
            }
            }
          />
        </GridItem>

      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={6}>
          <InputLabel id="demo-simple-select-label">نوع ادمین</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
          >
            <MenuItem value={10}>Ten</MenuItem>
            <MenuItem value={20}>Twenty</MenuItem>
            <MenuItem value={30}>Thirty</MenuItem>
          </Select>
        </GridItem>
        <GridItem xs={12} sm={12} md={6}>
          <InputLabel id="demo-simple-select-label">سازمان</InputLabel>
          <Select
          >
            <MenuItem value={10}>Ten</MenuItem>
            <MenuItem value={20}>Twenty</MenuItem>
            <MenuItem value={30}>Thirty</MenuItem>
          </Select>
        </GridItem>
      </GridContainer>
      <GridContainer>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="نام کاربری root"
            formControlProps={{
              fullWidth: true
            }}
            error={error.adminEmailAddress}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  adminEmailAddress: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
        <GridItem xs={12} sm={12} md={6}>
          <CustomInput
            labelText="رمزعبور root"
            formControlProps={{
              fullWidth: true
            }}
            error={error.rootPassword}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  rootPassword: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
      </GridContainer>
      <Button color="primary" onClick={register}>ثبت‌نام</Button>
    </React.Fragment>
  )
}
export default Register;
