import React, {useState} from "react";
import './register.css';
import GridItem from "../../../components/Grid/GridItem";
import GridContainer from "../../../components/Grid/GridContainer";
import CustomInput from "../../../components/CustomInput/CustomInput";
import Button from "../../../components/CustomButtons/Button";
import {Select, MenuItem, InputLabel} from "@material-ui/core";

const Register = () => {
  const [regInfo, setRegInfo] = useState({
    name: "",
    lastName: "",
    email: "",
    phoneNumber: "",
    password: "",
    number: "",
    adminType: 0,
    organization: 0,
    rootUsername: "",
    rootPass: ""
  });
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
      rootPass: false
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
    if(regInfo.rootPass === "") {
      setError({...error, rootUsername: true});
      setHasError(true);
    }
    if(hasError === true)
      return false;
    else
      return true;
  }
  const register = () => {
    if(checkValidations()){
      // register();
    }
  }
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
            error={error.rootUsername}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  rootUsername: event.target.value
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
            error={error.rootPass}
            inputProps={{
              onChange: (event) => {
                setRegInfo({
                  ...regInfo,
                  rootPass: event.target.value
                })
              }
            }
            }
          />
        </GridItem>
      </GridContainer>
      <Button color="primary" onClick={register()}>ثبت‌نام</Button>
    </React.Fragment>
  )
}
export default Register;
