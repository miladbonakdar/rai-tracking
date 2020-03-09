import React from "react";
import {TextField, Box, Button} from "@material-ui/core";

const Login = () => {
  return(
      <React.Fragment>
        <form className='form-fields' autoComplete="off">

          <TextField id="standard-password-input"
                     label="ایمیل / شماره تماس"
                     type="email"
                     defaultValue=""
                     helperText="Some important text" />
          <TextField id="standard-password-input"
                     label="رمزعبور"
                     type="password"/>
          <Box component="span" m={1}>
              <Button variant="contained" color="primary" disableElevation>
                ورود
              </Button>
          </Box>

        </form>

      </React.Fragment>
  )
}
export default Login;
