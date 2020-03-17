import React from "react";
import CustomTabs from "components/CustomTabs/CustomTabs";
import Login from "./login/login";
import GridContainer from "../../components/Grid/GridContainer";
import GridItem from "../../components/Grid/GridItem";
import Register from "./register/register";
import {Person, PersonAdd} from "@material-ui/icons";

const Auth = () => {
  return(
   <React.Fragment>
     <GridContainer direction="row"
                    justify="center"
                    alignItems="center">
       <GridItem sm={12} md={6} xs={12}>
         <CustomTabs

           headerColor="primary"
           rtlActive
           tabs={[
             {
               tabName: "ورود",
               tabIcon: Person,
               tabContent: (
                 <Login/>
               )
             },
             {
               tabName: "ثبت‌نام",
               tabIcon: PersonAdd,
               tabContent: (
                 <Register/>
               )
             }
           ]}
         />
       </GridItem>
     </GridContainer>
   </React.Fragment>
  )
}
export default Auth;
