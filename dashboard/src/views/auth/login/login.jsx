import React, {useState} from "react";
import GridContainer from "../../../components/Grid/GridContainer";
import GridItem from "../../../components/Grid/GridItem";
import CustomInput from "../../../components/CustomInput/CustomInput";
import Button from "../../../components/CustomButtons/Button";

const Login = () => {
  const [loginInfo, setLoginInfo] = useState({
    email: "",
    password: ""
  });
  const [emailError, setEmailError] = useState(false)
  const [passError, setPassError] = useState(false)

  const login = () => {
    loginInfo.email === "" ? setEmailError(true) : setEmailError(false)

    loginInfo.password === "" ? setPassError(true) : setPassError(false)
  }
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
              value={loginInfo.email}
             inputProps={{
               type: "text",
               onChange: (event) => {
                   setLoginInfo({
                     ...loginInfo,
                     email: event.target.value
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
